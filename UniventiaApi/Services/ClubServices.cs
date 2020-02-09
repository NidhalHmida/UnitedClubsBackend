using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UnitedClubsApi.DTO;
using UnitedClubsApi.IRepository;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.Services
{
    public class ClubServices : IClubRepository
    {

        private readonly IMongoCollection<Club> _club;

        private readonly IMapper _mapper;

        public ClubServices(IConfiguration Config, IMapper mapper)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UnitedClubsDB");
            _club = database.GetCollection<Club>("Club");
            _mapper = mapper;

        }

        private string GenerateToken(Club c)
        {


            var token = new JwtSecurityToken(
                claims: new Claim[] { new Claim(ClaimTypes.Name, c.Id_Club + " " + c.Nom_Club), new Claim(ClaimTypes.Role, c.Role) },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(7)).DateTime,
                signingCredentials: new SigningCredentials(JwtSettings.SIGNING_KEY, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool verifPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);

        }


        public Club getInformationsAccountClub(Club c)

        {
           Club c1= _club.Find(club => club.Email_Club == c.Email_Club && club.Passowrd_Club == c.Passowrd_Club).FirstOrDefault<Club>();
            if (verifPassword(c.Passowrd_Club, c1.Passowrd_Club))
                return c1;
            return null;
        }

        public Club verifAccountClub(Club c)

        {
            return _club.Find(club => club.Email_Club == c.Email_Club || club.Nom_Club == c.Nom_Club && club.Nom_université == c.Nom_université && club.Nom_Ecole == c.Nom_Ecole).FirstOrDefault<Club>();
        }

        public Club verifAccountClubById(String id)

        {
            return _club.Find(club => club.Id == id).FirstOrDefault<Club>();
        }
        public dynamic Connexion(ClubRequestAuthentification club)
        {
            Debug.WriteLine(_mapper.Map<Club>(club));
            Club C = getInformationsAccountClub(_mapper.Map<Club>(club));

            if (C == null)
                return new { response = "vous devez créer  vérifiez vos informations de connexion" };
            else
            {

                ClubResponse C1 = _mapper.Map<ClubResponse>(C);
                return new { token = GenerateToken(C), response = C1 };


            }
        }

        public dynamic deactiverClub(string id)
        {
            if (verifAccountClubById(id) != null)
            {
                _club.DeleteOne(club => club.Id == id);

                return new { response = "votre compte est désactivé" };
            }

            return new { response = "vous devez vérifiez vos informations" };
        }


        public dynamic Inscription(Club club)
        {

            if (verifAccountClub(club) == null)
            {
               club.Passowrd_Club = BCrypt.Net.BCrypt.HashPassword(club.Passowrd_Club);
                _club.InsertOne(club);
                return new { response = "Inscription avec succés" };

            }

            return new { response = "vous etes déja inscrit" };

        }

        public List<ClubResponse> listerTousClubs(ClubRequest clubs)
        {
            List<ClubResponse> clubsRetour = new List<ClubResponse>();
            List<Club> clubs1 = _club.Find(club => club.Nom_université == clubs.nomUniversité && club.Nom_Ecole == clubs.nomEcole).ToList();
            clubsRetour = _mapper.Map<List<ClubResponse>>(clubs1);
            return clubsRetour;
        }


        public List<ClubResponse> listerTousClubsAdmin()
        {
            List<ClubResponse> clubsRetour = new List<ClubResponse>();
            List<Club> clubs1 = _club.Find(club => true).ToList();
            clubsRetour = _mapper.Map<List<ClubResponse>>(clubs1);
            return clubsRetour;
        }

        public dynamic updateClub(Club c)
        {
           Club c1 = verifAccountClubById(c.Id);
            if (c1 != null)
            {
                if(!verifPassword(c.Passowrd_Club,c1.Passowrd_Club))
               c.Passowrd_Club = BCrypt.Net.BCrypt.HashPassword(c.Passowrd_Club);

                _club.ReplaceOne(club => club.Id == c.Id, c);
                return new { response = "vos informations sont mis à jour avec succées" };
            }
            return new { response = "vous devez vérifier vos informations " };
        }

        public dynamic signalerClub(SignalementClubRequest request)
        {
            Club c1 = verifAccountClubById(request.idClub);
            if (c1 != null)
            {
                c1.NombreSignalement++;
                if (c1.signalements == null)
                    c1.signalements = new List<Signalement>();
                c1.signalements.Add(new Signalement(request.etudiant,request.date,request.raison));

                _club.ReplaceOne(club => club.Id == c1.Id, c1);

                return new { response = "club signalé" };
            }

            return new { response = "club inexistant" };
        }


        public dynamic listerSignalementClub(string id)
        {
            Club c1 = verifAccountClubById(id);
            if (c1 != null)
            {
               
                if (c1.signalements != null)
                    return c1.signalements;
                return null;
            }
            return new { response = "club inexistant" };
        }


        public dynamic supprimerClubSignalement(string id)
        {

            Club c1 = verifAccountClubById(id);

            if ( c1 != null)
            {
                if(c1.NombreSignalement > 25)
                { 
                _club.DeleteOne(club => club.Id == id);
                return new { response = "le club est supprimé" };
                }

                return new { response = "le nombre de signalement n'a pas dépasse le 25 " };

            }

            return new { response = "club inexistant" };
        }
    }

}
