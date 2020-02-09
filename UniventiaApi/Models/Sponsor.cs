using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace UnitedClubsApi.Models
{
    public class Sponsor 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Matricule_Sponsor")]
        public string Matricule_Sponsor { get; set; }

        [BsonElement("Nom_Sponsor")]
        public string Nom_Sponsor { get; set; }

        [BsonElement("Email_Sponsor")]
        public string Email_Sponsor { get; set; }

        [BsonElement("Téléphone_Sponsor")]
        public string Téléphone_Sponsor { get; set; }

        [BsonElement("Adresse_Sponsor")]
        public string Adresse_Sponsor { get; set; }

        [BsonElement("Mot_de_passe_Sponsor")]
        public string Mot_de_passe_Sponsor { get; set; }

        [BsonElement("Etat_compte")]
        public string Etat_compte { get; set; }

        [BsonElement("Image")]
        public byte[] Image { get; set; }

       
        public string Role { get; set; }

        public List<Poke> pokes{ get; set; }

        public Sponsor()  {}

        public Sponsor(string matricule_Sponsor, string nom_Sponsor, string email_Sponsor, string téléphone_Sponsor, string adresse_Sponsor, string mot_de_passe_Sponsor, string etat_compte_Sponsor,byte[] image)
        {
            Matricule_Sponsor = matricule_Sponsor;
            Nom_Sponsor = nom_Sponsor;
            Email_Sponsor = email_Sponsor;
            Téléphone_Sponsor = téléphone_Sponsor;
            Adresse_Sponsor = adresse_Sponsor;
            Mot_de_passe_Sponsor = mot_de_passe_Sponsor;
            Etat_compte = etat_compte_Sponsor;
            Image = image;
        }
    }
}
