using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{

    public class AdminEcoleRequestAuthentification
    {
        public string Email_Admin { get; set; }
        public string Mot_de_passe_Admin { get; set; }

        public AdminEcoleRequestAuthentification()
        {
        }

        public AdminEcoleRequestAuthentification(string email_Admin, string mot_de_passe_Admin)
        {
            Email_Admin = email_Admin;
            Mot_de_passe_Admin = mot_de_passe_Admin;
        }
    }
}
