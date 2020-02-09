using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.DTO
{
    public class EvenementInfos
    {
        
        public string Id { get; set; }
        public string Id_Evenement { get; set; }
        public string Nom_Evenement { get; set; }
        public string Description { get; set; }
        public string Domaine { get; set; }
        public string Région { get; set; }
        public string Date_début_inscription { get; set; }
        public string Date_fin_inscription { get; set; }    
        public string Date_validation { get; set; }  
        public string Date_réalisation { get; set; }
        public string Durée { get; set; }  
        public long nombreInscrit { get; set; }
        public byte[] Affiche { get; set; }

        public EvenementInfos()
        {
        }

        public EvenementInfos(string id, string id_Evenement, string nom_Evenement, string description, string domaine, string région, string date_début_inscription, string date_fin_inscription, string date_validation, string date_réalisation, string durée, long nombreInscrit, byte[] affiche)
        {
            Id = id;
            Id_Evenement = id_Evenement;
            Nom_Evenement = nom_Evenement;
            Description = description;
            Domaine = domaine;
            Région = région;
            Date_début_inscription = date_début_inscription;
            Date_fin_inscription = date_fin_inscription;
            Date_validation = date_validation;
            Date_réalisation = date_réalisation;
            Durée = durée;
            this.nombreInscrit = nombreInscrit;
            Affiche = affiche;
        }
    }
}
