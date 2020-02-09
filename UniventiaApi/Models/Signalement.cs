using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitedClubsApi.DTO;

namespace UnitedClubsApi.Models
{
    public class Signalement
    {
        EtudiantProfile etudiant { get; set; }
        String date { get; set; }
        String raison { get; set; }

        public Signalement()
        {
        }

        public Signalement(EtudiantProfile etudiant, string date, string raison)
        {
            this.etudiant = etudiant;
            this.date = date;
            this.raison = raison;
        }
    }
}
