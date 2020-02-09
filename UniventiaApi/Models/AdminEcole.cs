using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UnitedClubsApi.Models
{
    public class AdminEcole
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nom_Admin")]
        public string Nom_Admin { get; set; }

        [BsonElement("Prénom_Admin")]
        public string Prénom_Admin { get; set; }

        [BsonElement("Email_Admin")]
        public string Email_Admin { get; set; }

        [BsonElement("Mot_de_passe_Admin")]
        public string Mot_de_passe_Admin { get; set; }

      
        [BsonElement("Nom_Ecole_Administration")]
        public string Nom_Ecole_Administration { get; set; }

        [BsonElement("Departement")]
        public string Departement { get; set; }

        [BsonElement("Fonction_Adminstration")]
        public string Fonction_Adminstration { get; set; }

        [BsonElement("Image")]
        public byte[] Image { get; set; }

        public string Role { get; set; }

        public AdminEcole()  {}

        public AdminEcole(string nom_Admin, string prénom_Admin, string email_Admin, string mot_de_passe_Admin, string nom_Ecole_Administration, string departement, string fonction_Adminstration,byte[] image)
        {
            Nom_Admin = nom_Admin;
            Prénom_Admin = prénom_Admin;
            Email_Admin = email_Admin;
            Mot_de_passe_Admin = mot_de_passe_Admin;
            Nom_Ecole_Administration = nom_Ecole_Administration;
            Departement = departement;
            Fonction_Adminstration = fonction_Adminstration;
            Image = image;
        }
    }
   
}

