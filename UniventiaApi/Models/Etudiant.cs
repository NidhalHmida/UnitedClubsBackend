using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace UnitedClubsApi.Models
{
    public class Etudiant 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Cin")]
        public string Cin { get; set; }

        [BsonElement("Nom_Etudiant")]
        public string Nom_Etudiant { get; set; }

        [BsonElement("Prénom_Etudiant")]
        public string Prénom_Etudiant { get; set; }

        [BsonElement("Date_naissance")]
        public string Date_naissance { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Téléphone")]
        public string Téléphone { get; set; }

        [BsonElement("Adresse_Etudiant")]
        public string Adresse_Etudiant{ get; set; }

        [BsonElement("SexeU")]
        public string Sexe { get; set; }

        [BsonElement("Mot_de_passe")]
        public string Mot_de_passe { get; set; }

        [BsonElement("Etat_compte")]
        public string Etat_compte { get; set; }

        [BsonElement("Num_Inscription")]
        public string Num_Inscription { get; set; }

        [BsonElement("Niveau_universitaire")]
        public string Niveau_universitaire { get; set; }

        [BsonElement("Nom_Ecole_Etudiant")]
        public string Nom_Ecole_Etudiant { get; set; }

        [BsonElement("Image")]
        public byte[] Image { get; set; }

        public string Role { get; set; }
        public Etudiant() { }

        public Etudiant(string cin, string nom_Etudiant, string prénom_Etudiant, string date_naissance, string email, string téléphone, string adresse_Etudiant, string sexe, string mot_de_passe, string etat_compte, string num_Inscription, string niveau_universitaire, string nom_Ecole_Etudiant,byte[] image)
        {
            Cin = cin;
            Nom_Etudiant = nom_Etudiant;
            Prénom_Etudiant = prénom_Etudiant;
            Date_naissance = date_naissance;
            Email = email;
            Téléphone = téléphone;
            Adresse_Etudiant = adresse_Etudiant;
            Sexe = sexe;
            Mot_de_passe = mot_de_passe;
            Etat_compte = etat_compte;
            Num_Inscription = num_Inscription;
            Niveau_universitaire = niveau_universitaire;
            Nom_Ecole_Etudiant = nom_Ecole_Etudiant;
            Image = image;
        }

    }
}
