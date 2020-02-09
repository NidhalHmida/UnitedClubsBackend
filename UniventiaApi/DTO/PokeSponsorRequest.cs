using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class PokeSponsorRequest
    {
        public string idSponsor { get; set; }
        public ClubResponse club { get; set; }
        public String date { get; set; }

        public PokeSponsorRequest()
        {
        }

        public PokeSponsorRequest(string idSponsor, ClubResponse club, string date)
        {
            this.idSponsor = idSponsor;
            this.club = club;
            this.date = date;
        }
    }
}
