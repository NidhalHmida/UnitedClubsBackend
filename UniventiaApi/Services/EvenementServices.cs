using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnitedClubsApi.DTO;
using UnitedClubsApi.IRepository;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.Services
{
    public class EvenementServices : IEvenementRepository
    {

        private readonly IMongoCollection<Evenement> _evenement;

        private readonly IMongoCollection<Club> _club;

        private readonly IMongoCollection<Etudiant> _etudiant;

        private readonly IMapper _mapper;

        public EvenementServices(IConfiguration Config, IMapper mapper)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UnitedClubsDB");
            _evenement = database.GetCollection<Evenement>("Evenement");
            _club = database.GetCollection<Club>("Club");
            _etudiant = database.GetCollection<Etudiant>("Etudiant");
            _mapper = mapper;
        }

        public Evenement verifEvenement(Evenement e)

        {
            return _evenement.Find(evenement => evenement.Id_Evenement == e.Id_Evenement || evenement.Nom_Evenement == e.Nom_Evenement && evenement.Nom_université == e.Nom_université && evenement.Nom_Ecole == e.Nom_Ecole).FirstOrDefault<Evenement>();
        }

        public List<Evenement> verifEvenementDate(Evenement e)

        {
            return _evenement.Find(evenement => evenement.Id_Club == e.Id_Club && evenement.Nom_Club == e.Nom_Club && evenement.Date_réalisation == e.Date_réalisation).ToList<Evenement>();
        }


        public Evenement verifEvenementById(String id)

        {
            return _evenement.Find(evenement => evenement.Id == id).FirstOrDefault<Evenement>();
        }


      /*  public Boolean verifEtudiantInscrit(EtudiantProfile e)

        {


                if (etudiants.ElementAt(i).Email == e.Email && etudiants.ElementAt(i).Cin == e.Cin)
                    return true;
          
            return false;
        }*/

        public dynamic addEvenement(Evenement E)
        {

       

            Club c = _club.Find(Club => Club.Nom_Club == E.Nom_Club && Club.Id_Club == E.Id_Club).FirstOrDefault<Club>();

            if (c != null)
            {

                if (verifEvenement(E) == null && verifEvenementDate(E).Count == 0)
                {
                    _evenement.InsertOne(E);
                    return new { response = " nouveau  élément  ajouté" };

                }

                return new { response = " vérifiez les informations saisies" };
            }



            return new { response = "club n'existe pas" };
        }

        public dynamic updateEvenement(Evenement e)
        {
            if (verifEvenementById(e.Id) != null)
            {
                _evenement.ReplaceOne(evenement => evenement.Id == e.Id, e);
                return new { response = "les informations de l'évenement sont mis à jour avec succées" };
            }
            return new { response = "vous devez vérifier les  informations saisies" };
        }

        public dynamic SupprimerEvenement(string id)
        {
            if (verifEvenementById(id) != null)
            {
                _evenement.DeleteOne(evenement => evenement.Id == id);

                return new { response = "l'événement est supprimé" };
            }

            return new { response = "l'événement n'est pas supprimé" };
        }


        public dynamic inscriptionEvenementEtudiant(EtudiantInscriptionEvenementRequest I)
        {   
            if(_etudiant.Find(etudiant => etudiant.Cin == I.etudiant.Cin && etudiant.Email == I.etudiant.Email).FirstOrDefault<Etudiant>()==null)
                return new { response = "vous n'etes inscrit à votre application" };
            Evenement e = verifEvenementById(I.Id_Evenement);
            if (e != null)
            {
                if (e.etudiants == null)
                {
                    e.etudiants = new List<EtudiantProfile>();
                }
                else
                {


                    EtudiantProfile e2 = I.etudiant;
                    if (e.etudiants.FindLast(delegate (EtudiantProfile e1)
            {
                if (e1.Email == I.etudiant.Email && e1.Cin == I.etudiant.Cin)
                    return true;
                return false;
            })!=null)
                        return new { response = "vous etes inscrit" };
                }

                e.etudiants.Add(I.etudiant);
                e.nombreInscrit = e.nombreInscrit + 1;
                _evenement.ReplaceOne(evenement => evenement.Id == e.Id, e);

                return new { response = "inscription est effectuée avec succés" };
            }
            return new { response = "évenement non disponible" };
        }


        public List<Evenement> listerTousEvenements()
        {
          /*  List<EvenementInfos> evenemetsRetour = new List<EvenementInfos>();*/
            List<Evenement> evenements = _evenement.Find(evenement=>true).ToList<Evenement>();
      
            return evenements;
        }

        public List<EvenementInfos> listerTousEvenementsSelonRegion(String région)
        {
             List<EvenementInfos> evenemetsRetour = new List<EvenementInfos>();
            List<Evenement> evenements = _evenement.Find(evenement => evenement.Région==région).ToList<Evenement>();
               evenemetsRetour = _mapper.Map<List<EvenementInfos>>(evenements );
            return evenemetsRetour;
        }

        public List<EvenementInfos> listerTousEvenementsSelonDomaine(String domaine)
        {
            List<EvenementInfos> evenemetsRetour = new List<EvenementInfos>();
            List<Evenement> evenements = _evenement.Find(evenement => evenement.Domaine == domaine).ToList<Evenement>();
            evenemetsRetour = _mapper.Map<List<EvenementInfos>>(evenements);
            return evenemetsRetour;
        }

        public List<EvenementInfos> listerTousEvenementsSelonUniversité(String universite)
        {
            List<EvenementInfos> evenemetsRetour = new List<EvenementInfos>();
            List<Evenement> evenements = _evenement.Find(evenement => evenement.Nom_université == universite).ToList<Evenement>();
            evenemetsRetour = _mapper.Map<List<EvenementInfos>>(evenements);
            return evenemetsRetour;
        }

        public List<EvenementInfos> listerTousEvenementsSelonEcole(String ecole)
        {
            List<EvenementInfos> evenemetsRetour = new List<EvenementInfos>();
            List<Evenement> evenements = _evenement.Find(evenement => evenement.Nom_Ecole == ecole).ToList<Evenement>();
            evenemetsRetour = _mapper.Map<List<EvenementInfos>>(evenements);
            return evenemetsRetour;
        }

        public List<EvenementInfos> listerTousEvenementsSelonClub(String club)
        {
            List<EvenementInfos> evenemetsRetour = new List<EvenementInfos>();
            List<Evenement> evenements = _evenement.Find(evenement => evenement.Nom_Club == club).ToList<Evenement>();
            evenemetsRetour = _mapper.Map<List<EvenementInfos>>(evenements);
            return evenemetsRetour;
        }

        public List<EvenementInfos> listerTousEvenementsSelonDate(String date)
        {
            List<EvenementInfos> evenemetsRetour = new List<EvenementInfos>();
            List<Evenement> evenements = _evenement.Find(evenement => evenement.Date_réalisation == date.Replace("-", "/")).ToList<Evenement>();
            evenemetsRetour = _mapper.Map<List<EvenementInfos>>(evenements);
            return evenemetsRetour;
        }

        public List<EtudiantProfile> listerEtudiantsInscrits(EtudiantInscriptionEvenementRequest E)
        {
            List<EtudiantProfile> etudiants = new List<EtudiantProfile>();
           Evenement evenement = _evenement.Find(e => e.Id == E.Id_Evenement).FirstOrDefault<Evenement>();
            if (evenement != null)
            {      if(evenement.etudiants!=null)
                  etudiants = evenement.etudiants;
            }
            return etudiants;
     }

        public List<EvenementInfos> listerEvenementsEtudiant(EtudiantProfile E)
        {
            List<EvenementInfos>  evenements= new List<EvenementInfos>();
            if (_etudiant.Find(etudiant => etudiant.Cin == E.Cin && etudiant.Email ==E.Email).FirstOrDefault<Etudiant>() == null)
                return evenements;
            List<Evenement> e = _evenement.Find(evenement => evenement.nombreInscrit != 0).ToList<Evenement>();

            if(e==null)
                return evenements;

            for (var i=0;i<e.Count;i++)
            {

               if(e.ElementAt(i).etudiants.FindLast(delegate (EtudiantProfile e1) {
                    return e1.Email == E.Email && e1.Cin == E.Cin;
                }) != null)
                    evenements.Add(_mapper.Map<EvenementInfos>(e.ElementAt(i)));
            }
               
           
            return evenements;
        }


        public List<EvenementInfos> listerEvenementInscriptionValide()
        {
           List<EvenementInfos> evenements= _mapper.Map < List < EvenementInfos >>( _evenement.Find(evenement => true).ToList<Evenement>());
            List<EvenementInfos> evenementsValide = new List<EvenementInfos>();
            for (var i=0;i<evenements.Count;i++)
            {
                DateTime dt1 = DateTime.Parse(evenements.ElementAt(i).Date_fin_inscription);
                DateTime dt2 = DateTime.Now;
                if (DateTime.Compare(dt1, dt2) > 0)
                {
                    evenementsValide.Add(evenements.ElementAt(i));
                }

            }
            return evenementsValide;
        }

        public List<EvenementInfos> listerEvenementRecommandations(String date)
        {

            List<EvenementInfos> evenements = _mapper.Map<List<EvenementInfos>>(_evenement.Find(evenement => true).ToList<Evenement>());
            List<EvenementInfos> evenementsValide = new List<EvenementInfos>();
            for (var i = 0; i < evenements.Count; i++)
            {
                DateTime dt1 = DateTime.Parse(evenements.ElementAt(i).Date_réalisation);
                DateTime dt2 = DateTime.Parse(date.Replace("-","/")); 

                
                if ((dt1 - dt2).TotalDays < 21 && (dt1 - dt2).TotalDays > -7 && DateTime.Compare(dt1, DateTime.Now) > 0)
                {
                    evenementsValide.Add(evenements.ElementAt(i));
                }

            }
            return evenementsValide;
        }


    }
}
