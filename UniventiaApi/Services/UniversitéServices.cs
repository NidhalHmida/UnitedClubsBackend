using System;
using System.Collections.Generic;
using System.Linq;
using UnitedClubsApi.Models;
using MongoDB.Driver;
using System.IO;
using UnitedClubsApi.DTO;
using AutoMapper;
using UnitedClubsApi.IRepository;
using System.Diagnostics;

namespace UnitedClubsApi.Services
{
    public class UniversitéServices : IUniversitéRepository
    {
        private readonly IMongoCollection<Université> _université;

        private readonly IMongoCollection<Club> _club;

        private readonly IMongoCollection<Evenement> _evenement;

        private readonly IMapper _mapper;

        public UniversitéServices( IMapper mapper)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UnitedClubsDB");
            _université = database.GetCollection<Université>("Université");
            _club = database.GetCollection<Club>("Club");
            _evenement = database.GetCollection<Evenement>("Evenement");
            _mapper = mapper;
        }


        public Université verifUniversité(Université U)

        {
            return _université.Find(Université => Université.Id_Université == U.Id_Université || Université.Nom_Université == U.Nom_Université).FirstOrDefault<Université>();
        }

        public Université getUniversité(string Id)

        {
            return _université.Find(Université =>  Université.Id == Id).FirstOrDefault<Université>();
        }

        public dynamic addUniversité(Université U)
        {
     
         
            if (verifUniversité(U) == null)
            {
                _université.InsertOne(U);
                return new { response = " nouvelle université ajoutée" };
            }
            return new { response = "vous avez déja ajouté  cette université" };
        }
        public dynamic UpdateUniversité(Université U)
        {
            

            if (getUniversité(U.Id) != null)
            {
                _université.ReplaceOne(Université => Université.Id == U.Id, U);
                return new { response = "les informations de l'université sont mis à jour avec succées" };
            }

            return new { response = "l'université n'existe pas dans la base de données" };

        }

        public dynamic DeleteUniversité(String id)
        {
            Université u = getUniversité(id);
            if ( u!= null)
            {
                _université.DeleteOne(Université => Université.Id ==id);
                _club.DeleteOne(Club=> Club.Nom_université  == u.Nom_Université);
                _evenement.DeleteOne(Evenement => Evenement.Nom_université == u.Nom_Université);

                return new { response = "l'université est supprimée" };
            }

            return new { response = "l'université n'existe pas dans la base de données" };
        }

        public List<UniversitéResponse> GetAllUniversities() {

            List<UniversitéResponse> universitiesRetour = new List<UniversitéResponse>();
           List < Université > universities= _université.Find(Université => true).ToList();
           universitiesRetour = _mapper.Map<List<UniversitéResponse>>(universities);
            return universitiesRetour;
        }
    }
}
