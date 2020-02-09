using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitedClubsApi.DTO;

namespace UnitedClubsApi.Models
{
    public class Poke
    {
        ClubResponse club {get; set ;}
        String date { get; set; }

        public Poke()
        {
        }

        public Poke(ClubResponse club, string date)
        {
            this.club = club;
            this.date = date;
        }
    }
}
