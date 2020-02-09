using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
namespace UnitedClubsApi.Models
{
    public class Ecole
    {
      
        [BsonElement("Id_Ecole")]
        public string Id_Ecole { get; set; }

        [BsonElement("Nom_Ecole")]
        public string Nom_Ecole { get; set; }

        [BsonElement("Téléphone_Ecole")]
        public string Téléphone_Ecole { get; set; }

        [BsonElement("Adresse_Ecole")]
        public string Adresse_Ecole { get; set; }

        [BsonElement("Email_Ecole")]
        public string Email_Ecole { get; set; }

        [BsonElement("Image")]
        public byte[] Image { get; set; }

       
    


        public Ecole() { }
        
        public Ecole( string id_Ecole, string nom_Ecole, string téléphone_Ecole, string adresse_Ecole, string email_Ecole,byte[] image)
        {
            Id_Ecole = id_Ecole;
            Nom_Ecole = nom_Ecole;
            Téléphone_Ecole = téléphone_Ecole;
            Adresse_Ecole = adresse_Ecole;
            Email_Ecole = email_Ecole;
            Image = image;
        }


    }
}
