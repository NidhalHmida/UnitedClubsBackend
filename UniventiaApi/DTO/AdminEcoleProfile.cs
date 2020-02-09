using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class AdminEcoleProfile
    {

        public string Id { get; set; }
        public string Nom_Admin { get; set; }

        public string Prénom_Admin { get; set; }

        public string Email_Admin { get; set; }

        public string Nom_Ecole_Administration { get; set; }
        public string Departement { get; set; }
        public string Fonction_Adminstration { get; set; }
        public byte[] Image { get; set; }

        public AdminEcoleProfile()
        {
        }

        public AdminEcoleProfile(string id, string nom_Admin, string prénom_Admin, string email_Admin, string nom_Ecole_Administration, string departement, string fonction_Adminstration, byte[] image)
        {
            Id = id;
            Nom_Admin = nom_Admin;
            Prénom_Admin = prénom_Admin;
            Email_Admin = email_Admin;
            Nom_Ecole_Administration = nom_Ecole_Administration;
            Departement = departement;
            Fonction_Adminstration = fonction_Adminstration;
            Image = image;
        }
    }
}
