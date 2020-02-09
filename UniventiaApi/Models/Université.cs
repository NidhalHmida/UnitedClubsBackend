using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace UnitedClubsApi.Models
{

   
    public class Université
    {
      
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Id_Université")]
        public string Id_Université { get; set; }

        [BsonElement("Nom_Université")]
        public string Nom_Université { get; set; }

        [BsonElement("Région")]
        public string Région { get; set; }

        [BsonElement("Téléphone_Université")]
        public string Téléphone_Université { get; set; }

        [BsonElement("Adresse_Université")]
        public string Adresse_Université { get; set; }

        [BsonElement("Email_Université")]
        public string Email_Université { get; set; }

        [BsonElement("Image")]
        public byte[] Image { get; set; }

        [BsonElement("Ecoles")]
        public List<Ecole> Ecoles { get; set; }

       public Université() { }

        public Université( string id_Université, string nom_Université, string région, string téléphone_Université, string adresse_Université, string email_Université, byte[] image, List<Ecole> ecoles)
        {
            
            Id_Université = id_Université;
            Nom_Université = nom_Université;
            Région = région;
            Téléphone_Université = téléphone_Université;
            Adresse_Université = adresse_Université;
            Email_Université = email_Université;
            Ecoles = ecoles;
            Image = image;
        }
    }
}
