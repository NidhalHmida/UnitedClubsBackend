using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using UnitedClubsApi.DTO;

namespace UnitedClubsApi.Models
{
    public class Evenement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Id_Evenement")]
        public string Id_Evenement { get; set; }

        [BsonElement("Nom_Evenement")]
        public string Nom_Evenement { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Domaine")]
        public string Domaine { get; set; }

        [BsonElement("Région")]
        public string Région { get; set; }

        [BsonElement("Date_début_inscription")]
        public string Date_début_inscription { get; set; }

        [BsonElement("Date_fin_inscription")]
        public string Date_fin_inscription { get; set; }

        [BsonElement("Date_validation")]
        public string Date_validation { get; set; }

        [BsonElement("Date_réalisation")]
        public string Date_réalisation { get; set; }

        [BsonElement("Durée")]
        public string Durée { get; set; }

        [BsonElement("Nom_université")]
        public string Nom_université { get; set; }

        [BsonElement("Nom_Ecole")]
        public string Nom_Ecole { get; set; }

        [BsonElement("Id_Club")]
        public string Id_Club { get; set; }

        [BsonElement("Nom_Club")]
        public string Nom_Club { get; set; }

        [BsonElement("nombreInscrit")]
        public int nombreInscrit { get; set; }

        [BsonElement("Affiche")]
        public byte[] Affiche { get; set; }

        [BsonElement("Etudiant")]
        public List<EtudiantProfile> etudiants { get; set; }

        public Evenement() { }

        public Evenement(string id_Evenement, string nom_Evenement, string description, string domaine, string région, string date_début_inscription, string date_fin_inscription, string date_validation, string date_réalisation, string durée, byte[] affiche)
        {
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
            Affiche = affiche;
        }
    }
}
