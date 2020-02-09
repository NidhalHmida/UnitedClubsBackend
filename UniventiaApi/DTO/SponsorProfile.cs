using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class SponsorProfile
    {

        public string Id { get; set; }
        public string Matricule_Sponsor { get; set; }
        public string Nom_Sponsor { get; set; }

        public string Email_Sponsor { get; set; }
    
        public string Téléphone_Sponsor { get; set; }

        public string Adresse_Sponsor { get; set; }

        public byte[] Image { get; set; }

        public SponsorProfile()
        {
        }

        public SponsorProfile(string id, string matricule_Sponsor, string nom_Sponsor, string email_Sponsor, string téléphone_Sponsor, string adresse_Sponsor, byte[] image)
        {
            Id = id;
            Matricule_Sponsor = matricule_Sponsor;
            Nom_Sponsor = nom_Sponsor;
            Email_Sponsor = email_Sponsor;
            Téléphone_Sponsor = téléphone_Sponsor;
            Adresse_Sponsor = adresse_Sponsor;
            Image = image;
        }
    }
}
