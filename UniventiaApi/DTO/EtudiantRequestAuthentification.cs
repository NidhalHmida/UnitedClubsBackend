using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.Dto
{
    public class EtudiantRequestAuthentification
    { 
        public string Email { get; set; }
        public string Mot_de_passe { get; set; }
        public string Etat_compte { get; set; }

        public EtudiantRequestAuthentification()
        {
        }

        public EtudiantRequestAuthentification(string email, string mot_de_passe, string etat_compte)
        {
            Email = email;
            Mot_de_passe = mot_de_passe;
            Etat_compte = etat_compte;
        }
    }
}
