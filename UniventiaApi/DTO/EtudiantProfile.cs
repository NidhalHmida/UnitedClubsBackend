using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class EtudiantProfile
    {

        public string Id { get; set; }

  
        public string Cin { get; set; }

 
        public string Nom_Etudiant { get; set; }

      
        public string Prénom_Etudiant { get; set; }

    
        public string Date_naissance { get; set; }

  
        public string Email { get; set; }


        public string Téléphone { get; set; }

       
        public string Adresse_Etudiant { get; set; }

     
        public string Sexe { get; set; }

      
        public string Num_Inscription { get; set; }

      
        public string Niveau_universitaire { get; set; }

      
        public string Nom_Ecole_Etudiant { get; set; }

      
        public byte[] Image { get; set; }

        public EtudiantProfile()
        {
        }

        public EtudiantProfile(string id, string cin, string nom_Etudiant, string prénom_Etudiant, string date_naissance, string email, string téléphone, string adresse_Etudiant, string sexe, string num_Inscription, string niveau_universitaire, string nom_Ecole_Etudiant, byte[] image)
        {
            Id = id;
            Cin = cin;
            Nom_Etudiant = nom_Etudiant;
            Prénom_Etudiant = prénom_Etudiant;
            Date_naissance = date_naissance;
            Email = email;
            Téléphone = téléphone;
            Adresse_Etudiant = adresse_Etudiant;
            Sexe = sexe;
            Num_Inscription = num_Inscription;
            Niveau_universitaire = niveau_universitaire;
            Nom_Ecole_Etudiant = nom_Ecole_Etudiant;
            Image = image;
        }
    }
}
