using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class SignalementClubRequest
    {
        public  String idClub { get; set; }
        public EtudiantProfile etudiant { get; set; }
        public string date { get; set; }

        public string raison { get; set; }

        public SignalementClubRequest()
        {
        }

        public SignalementClubRequest(String idClub, EtudiantProfile etudiant, string date , string raison)
        {
            this.idClub = idClub;
            this.etudiant = etudiant;
            this.date = date;
            this.raison = raison;

        }
    }
}
