using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class ClubRequestAuthentification
    {

        public string Email_Club { get; set; }

        public string Passowrd_Club { get; set; }

        public ClubRequestAuthentification()
        {
        }

        public ClubRequestAuthentification(string email_Club, string passowrd_Club)
        {
            Email_Club = email_Club;
            Passowrd_Club = passowrd_Club;
        }
    }
}
