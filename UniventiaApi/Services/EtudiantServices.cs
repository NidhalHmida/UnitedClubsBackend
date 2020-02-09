using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using UnitedClubsApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Net.Mail;
using System.IO;
using UnitedClubsApi.Dto;
using AutoMapper;
using UnitedClubsApi.IRepository;
using System.Diagnostics;
using UnitedClubsApi.DTO;

namespace UnitedClubsApi.Services
{
    public class EtudiantServices :IEtudiantRepository
    {

        private readonly IMongoCollection<Etudiant> _etudiant;

        private readonly IMapper _mapper;


        public EtudiantServices(IConfiguration Config, IMapper mapper)
        {
            var client = new MongoClient();
            _mapper = mapper;
            var database = client.GetDatabase("UnitedClubsDB");
            _etudiant = database.GetCollection<Etudiant>("Etudiant");
         
        }

        private string GenerateToken(Etudiant e)
        {
            Debug.Write(e.Nom_Etudiant);

            var token = new JwtSecurityToken(
                claims: new Claim[] { new Claim(ClaimTypes.Name, e.Prénom_Etudiant + " " + e.Nom_Etudiant) , new Claim(ClaimTypes.Role, e.Role) },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(7)).DateTime,
                signingCredentials: new SigningCredentials(JwtSettings.SIGNING_KEY, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public String SendEmailEtudiant(Etudiant e)
        {

            Random aleatoire = new Random();
            int Code = aleatoire.Next(10000000, 100000000);
            MailMessage email = new MailMessage();
            email.From = new System.Net.Mail.MailAddress("eventiaclub@gmail.com");
            e.Etat_compte = ""+ Code;
            email.To.Add(new MailAddress(e.Email));
            email.IsBodyHtml = true;
            email.Subject = "Confirmation d'adresse éléctronique";
            email.Body = "Pour terminer la configuration de votre compte , il nous reste à vérifier que cette adresse e-mail est bien la vôtre.Utilisez le code suivant pour vérifier votre adresse \n e - mail :" + Code + "\n Merci,L’équipe d'eventia club";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("eventiaclub@gmail.com", "hello.net");
            try
            {
                smtp.Send(email);
                return "message envoyé";
               
            }
            catch (SmtpException ex)
            {
               
                return ("Probléme d'envoi de mail de vérification" + ex.Message);

            }
        }

         public bool verifPassword(string password,string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);

        }

        public Etudiant verifEtudiantById(String id)

        {
            return _etudiant.Find(etudiant => etudiant.Id == id ).FirstOrDefault<Etudiant>();
        }
        public Etudiant getInformationsEtudiant(Etudiant e)

        {
        
            Etudiant e1= _etudiant.Find(etudiant => etudiant.Email == e.Email ).FirstOrDefault<Etudiant>();
            if (verifPassword(e.Mot_de_passe, e1.Mot_de_passe))
                return e1;
            return null;
        }

        public Etudiant verifAccountEtudiant(Etudiant e)

        {
            return _etudiant.Find(etudiant => etudiant.Cin == e.Cin || etudiant.Email == e.Email).FirstOrDefault<Etudiant>();
        }


        public dynamic SignUpStudent(Etudiant e)
        {
            
            if (verifAccountEtudiant(e) == null)
            { 
              if(SendEmailEtudiant(e)== "message envoyé")
                {
                    e.Mot_de_passe = BCrypt.Net.BCrypt.HashPassword(e.Mot_de_passe);
                    
                    _etudiant.InsertOne(e);
                
                   return  new { response = "Inscription avec succés" };
                }

                return new { response = "probléme technique Serveur" };
            }

            return new { response = "vous etes déja inscrit" };
        }


        public dynamic SignInEtudiant(EtudiantRequestAuthentification e)
        {
           
            Etudiant E = getInformationsEtudiant(_mapper.Map<Etudiant>(e));
            
            if ( E== null)
                return ("vous devez créer tout d'abord un compte ou vérifiez vos informations");
            else
            {
                    if (E.Etat_compte != "verifié")
                        return new { response = "vous devez saisir le code envoyé à votre courrier éléctornique" };
                EtudiantProfile E1 = _mapper.Map<EtudiantProfile>(E);
                return new { token = GenerateToken(E), response = E1 };
                    

            }
        }

        public dynamic SignInEtudiantrVerification(EtudiantRequestAuthentification e)
        {
        
            Etudiant E = getInformationsEtudiant(_mapper.Map<Etudiant>(e));
    
                if (E == null)
                return new { response = "vous devez créer tout d'abord un compte ou vérifiez vos informations" };
            else
            {
                if (E.Etat_compte ==e.Etat_compte)
                {

                    E.Etat_compte = "verifié";
                        _etudiant.ReplaceOne(etudiant =>  etudiant.Email == E.Email, E);
                    EtudiantProfile E1 = _mapper.Map<EtudiantProfile>(E);
                    return new { token = GenerateToken(E), response = E1 };
                  

                }
                else
                    return new { response = "votre code est erroné, vous devez le ressaisir" };

            }
        }

        public dynamic UpdateEtudiant(Etudiant e)
        {

            Etudiant e1 = verifEtudiantById(e.Id);

            if (e1!=null)
            {
                if (!verifPassword( e.Mot_de_passe,e1.Mot_de_passe))
                    e.Mot_de_passe = BCrypt.Net.BCrypt.HashPassword(e.Mot_de_passe);
                _etudiant.ReplaceOne(etudiant => etudiant.Id == e.Id , e);
              return  new { response= "vos informations sont mis à jour avec succées" };
            }

            return new { response = "vous devez vérifier vos informations " };
        }


        public dynamic DeleteEtudiant(String id)
        {
            if (verifEtudiantById(id) != null)
            {
             
                _etudiant.DeleteOne(etudiant => etudiant.Id == id);
                return new { response = "Votre compte est désactivé" };
            }
            return new { response = "vous devez vérifier vos informations " };          
        }
    }
}
