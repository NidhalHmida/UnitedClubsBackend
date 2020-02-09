using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class SponsorRequestAuthentification
    {
     
        public string Email_Sponsor { get; set; } 

        public string Mot_de_passe_Sponsor { get; set; }

        public string Etat_compte { get; set; }

        public SponsorRequestAuthentification()
        {
        }

        public SponsorRequestAuthentification(string email_Sponsor, string mot_de_passe_Sponsor, string etat_compte)
        {
            Email_Sponsor = email_Sponsor;
            Mot_de_passe_Sponsor = mot_de_passe_Sponsor;
            Etat_compte = etat_compte;
        }
    }
}
