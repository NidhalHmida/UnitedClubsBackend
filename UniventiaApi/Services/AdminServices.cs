
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
using System.Collections.Generic;
using AutoMapper;
using UnitedClubsApi.DTO;
using UnitedClubsApi.IRepository;

namespace UnitedClubsApi.Services
{

 
    public class AdminServices : IAdminEcoleRepository
    {
        private readonly IMongoCollection<AdminEcole> _AdminEcole;

        private readonly IMapper _mapper;

        public AdminServices(IConfiguration Config, IMapper mapper)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UnitedClubsDB");
            _AdminEcole = database.GetCollection<AdminEcole>("AdminEcole");
            _mapper = mapper;

        }

        public AdminEcole verifAdminById(String id)

        {
            return _AdminEcole.Find(admin => admin.Id == id).FirstOrDefault<AdminEcole>();
        }

        public AdminEcole getInformationsAdminEcole(AdminEcole a)

        {
            AdminEcole a1= _AdminEcole.Find(admin => admin.Email_Admin == a.Email_Admin && admin.Mot_de_passe_Admin == a.Mot_de_passe_Admin).FirstOrDefault<AdminEcole>();
            if (verifPassword(a.Mot_de_passe_Admin, a1.Mot_de_passe_Admin))
                return a1;
            return null;
        }

        public AdminEcole verifAccountAdminEcole(AdminEcole a)

        {
            return _AdminEcole.Find(AdminEcole => AdminEcole.Email_Admin == a.Email_Admin || AdminEcole.Nom_Ecole_Administration == a.Nom_Ecole_Administration).FirstOrDefault<AdminEcole>();
        }

        private string GenerateToken(AdminEcole a)
        {


            var token = new JwtSecurityToken(
                claims: new Claim[] { new Claim(ClaimTypes.Name, a.Prénom_Admin+" "+a.Nom_Admin) , new Claim(ClaimTypes.Role, a.Role) },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(7)).DateTime,
                signingCredentials: new SigningCredentials(JwtSettings.SIGNING_KEY, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GeneratePassword(int Length, char[] Chars)
        {
            string Password = string.Empty;
            System.Random rnd = new System.Random();
            for (int i = 0; i < Length; i++)
                Password += Chars[rnd.Next(Chars.Length)];
            return Password;
        }

        public String SendEmailAdmin(AdminEcole a)
        {
            MailMessage email = new MailMessage();
        email.From = new System.Net.Mail.MailAddress("eventiaclub@gmail.com");

                email.To.Add(new MailAddress(a.Email_Admin));
                email.IsBodyHtml = true;
                email.Subject = "Confirmation de compte";
            String mot = GeneratePassword(8, "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
            a.Mot_de_passe_Admin = mot;
            email.Body = "Pour terminer la configuration de votre compte, utilisez le mot de passe suivant pour accédez à votre compte \n  :" + mot + "\n Merci,L’équipe UnitedClubs";

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("eventiaclub@gmail.com", "hello.net");
                try
                {
                    smtp.Send(email);
                   return("message envoyée");            
                 
                }
                catch (SmtpException ex)
                {
                    
                    return ("Probléme d'envoi de mail de vérification" + ex.Message);

                }
            }

        public bool verifPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);

        }

        public dynamic addAdmin(AdminEcole a)
        {

          

            if (verifAccountAdminEcole(a) == null)
            {

                if (SendEmailAdmin(a) == "message envoyé")
                {
                    a.Mot_de_passe_Admin = BCrypt.Net.BCrypt.HashPassword(a.Mot_de_passe_Admin);
                    _AdminEcole.InsertOne(a);
                    return  new { response = "Nouveau admin ajouté" }; 
                }

                return new { response = "probléme technique Serveur" };
            }

            return new { response = "vous avez déja ajouté un admin pour cette école" };
        }

        public dynamic SignInAdminEcole(AdminEcoleRequestAuthentification a)
        {

            AdminEcole A = getInformationsAdminEcole(_mapper.Map<AdminEcole>(a));
            
            if (A == null)
                return new { response = "vous devez créer  vérifiez vos informations de connexion" };
            else
            {
               
               AdminEcoleProfile A1 = _mapper.Map<AdminEcoleProfile>(A);
                return new { token = GenerateToken(A), response = A1 };


            }
        }
        public dynamic UpdateAdmin(AdminEcole  a)
        {

            AdminEcole a1 = verifAdminById(a.Id);


            if ( a1!= null)
            {
                if(!verifPassword(a.Mot_de_passe_Admin,a1.Mot_de_passe_Admin))
                    a.Mot_de_passe_Admin = BCrypt.Net.BCrypt.HashPassword(a.Mot_de_passe_Admin);

                _AdminEcole.ReplaceOne(AdminEcole => AdminEcole.Id == a.Id, a);
                return new { response = "les informations d'admin sont mis à jour avec succées" };
            }
            return new { response = "vous devez vérifier les informations saisies" };
        }

        public dynamic DeleteAdmin(String id)
        {
            if (verifAdminById(id) != null)
            {
                _AdminEcole.DeleteOne(AdminEcole => AdminEcole.Id == id);

                return new { response = "compte admin est désactivé" };
            }
            return new { response = "vous devez vérifier les informations saisies" };
        }

        public List<AdminEcoleProfile> GetAllAdmins()
        {
            List<AdminEcoleProfile> adminsProfile = new List<AdminEcoleProfile>();
            List<AdminEcole> admins = _AdminEcole.Find(AdminEcole => true).ToList();
            adminsProfile = _mapper.Map<List<AdminEcoleProfile>>(admins);
            return adminsProfile;
        }
    }
}
