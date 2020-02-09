using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class ClubRequest
    {
        public String nomUniversité { get; set; }
        public String nomEcole { get; set; }

        public String nomClub { get; set; }

        public ClubRequest()
        {
        }

        public ClubRequest(string nomUniversité, string nomEcole, string nomClub)
        {
            this.nomUniversité = nomUniversité;
            this.nomEcole = nomEcole;
            this.nomClub = nomClub;
        }
    }
}
