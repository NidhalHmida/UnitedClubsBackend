using System;
using System.Collections.Generic;
using System.Linq;
using UnitedClubsApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.IO;
using UnitedClubsApi.DTO;
using AutoMapper;
using UnitedClubsApi.IRepository;
using System.Diagnostics;

namespace UnitedClubsApi.Services
{
    public class EcoleServices : IEcoleRepository
    {

        private readonly IMongoCollection<Université> _université;
        private readonly IMongoCollection<Club> _club;
        private readonly IMongoCollection<Evenement> _evenement;

        private readonly IMapper _mapper;

        public EcoleServices(IConfiguration Config, IMapper mapper)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UnitedClubsDB");
            _université = database.GetCollection<Université>("Université");
            _club = database.GetCollection<Club>("Club");
            _evenement = database.GetCollection<Evenement>("Evenement");
            _mapper = mapper;
        }

        public Boolean verifEcole(Ecole E,List<Ecole> Ecoles)

        {
           
            if (Ecoles != null)
            {
                for (var i = 0; i < Ecoles.Count; i++)
                {
                    if (Ecoles.ElementAt(i).Id_Ecole == E.Id_Ecole || Ecoles.ElementAt(i).Nom_Ecole == E.Nom_Ecole)
                        return true;
                }
            }
            return false;
        }

        public int getEcole(Ecole E, List<Ecole> Ecoles)

        {
            
            if (Ecoles != null)
            {
                for (var i = 0; i < Ecoles.Count; i++)
                {
                    if (Ecoles.ElementAt(i).Id_Ecole == E.Id_Ecole && Ecoles.ElementAt(i).Nom_Ecole == E.Nom_Ecole)
                        return (i);
                }
            }
            return -1;
        }
        public dynamic addEcole(EcoleRequest E)
        {
           
             Université U = _université.Find(Université => Université.Nom_Université == E.nomUniversité).FirstOrDefault<Université>();
            if (!verifEcole(E.ecole,U.Ecoles))
            {
                if(U.Ecoles == null)
                {
                    U.Ecoles = new List<Ecole>();       
                }
                U.Ecoles.Add(E.ecole);
                 _université.ReplaceOne(Université => Université.Id == U.Id, U);
                return new { response = " nouvelle école ajoutée" };
            }
            return new { response = "vous avez déja ajouté  cette école" };
        }

        public dynamic updateEcole(EcoleRequest E)
        {
         
            Université U = _université.Find(Université => Université.Nom_Université == E.nomUniversité).FirstOrDefault<Université>();
            if (U == null)
                return new { response = "université n'existe pas dans la base de données" };
            int indice = getEcole(E.ecole, U.Ecoles);
            if(indice == -1)
            return new { response = "école  n'existe pas dans la base de données" };
            U.Ecoles.RemoveAt(indice);
            U.Ecoles.Insert(indice, E.ecole);
            _université.ReplaceOne(Université => Université.Id == U.Id, U);
            return new { response = "les informations cette école sont mis à jour avec succés" };
        }

        public List<EcoleResponse> GetAllEcoles(EcoleRequest E)
        {

            List<EcoleResponse> Ecolesretour = new List<EcoleResponse>();
           
            Université U = _université.Find(Université => Université.Nom_Université == E.nomUniversité).FirstOrDefault<Université>();
            Ecolesretour = _mapper.Map<List<EcoleResponse>>(U.Ecoles);
            return Ecolesretour;
        }


        public dynamic deleteEcole(EcoleRequest E)
        {
           
            Université U = _université.Find(Université => Université.Nom_Université == E.nomUniversité).FirstOrDefault<Université>();
            if (U == null)
                return new { response = "université n'existe pas dans la base de données" };
            int indice = getEcole(E.ecole, U.Ecoles);
            if (indice == -1)
                return new { response = "école  n'existe pas dans la base de données" };    
           
            _club.DeleteOne(Club => Club.Nom_Ecole == U.Ecoles.ElementAt(indice).Nom_Ecole);
            _evenement.DeleteOne(Evenement => Evenement.Nom_Ecole == U.Ecoles.ElementAt(indice).Nom_Ecole);
            _université.ReplaceOne(Université => Université.Id_Université == U.Id_Université && Université.Nom_Université == U.Nom_Université,U);

            U.Ecoles.RemoveAt(indice);
            return new { response = "cette école est supprimé" };
        }
    }
}
