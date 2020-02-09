using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UnitedClubsApi.Models
{
    public class Club
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Id_Club")]
        public string Id_Club { get; set; }

        [BsonElement("Nom_Club")]
        public string Nom_Club { get; set; }

        [BsonElement("Téléphone_Club")]
        public string Téléphone_Club { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Nombre_Membres")]
        public string Nombre_Membres { get; set; }

        [BsonElement("Date_Création")]
        public string Date_Création { get; set; }

        [BsonElement("Email_Club")]
        public string Email_Club { get; set; }

        [BsonElement("Passowrd_Club")]
        public string Passowrd_Club { get; set; }


        [BsonElement("Nom_université")]
        public string Nom_université { get; set; }

        [BsonElement("Nom_Ecole")]
        public string Nom_Ecole { get; set; }

        [BsonElement("nombreSignalement")]
        public int NombreSignalement { get; set; }

        [BsonElement("Image")]
        public byte[] Image { get; set; }

        public string Role { get; set; }

        public List<Signalement> signalements { get; set; }

        public Club() { }
        public Club(string id_Club, string nom_Club, string téléphone_Club, string description, string nombre_Membres, string date_Création, string email_Club, string passowrd_Club, string nom_université, string nom_Ecole, int nombreSignalement,byte[] image)
        {
            Id_Club = id_Club;
            Nom_Club = nom_Club;
            Téléphone_Club = téléphone_Club;
            Description = description;
            Nombre_Membres = nombre_Membres;
            Date_Création = date_Création;
            Email_Club = email_Club;
            Passowrd_Club = passowrd_Club;
            Nom_université = nom_université;
            Nom_Ecole = nom_Ecole;
            NombreSignalement = nombreSignalement;
            Image = image;
        }
    }
}
