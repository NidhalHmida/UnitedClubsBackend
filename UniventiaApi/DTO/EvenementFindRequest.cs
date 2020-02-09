using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class EvenementFindRequest
    {
        public String nomUniversité { get; set; }
        public String nomEcole { get; set; }
        public String nomClub { get; set; }
        public String domaine { get; set; }
        public String région { get; set; }
        public String date { get; set; }

        public EvenementFindRequest()
        {
        }
    }

}
