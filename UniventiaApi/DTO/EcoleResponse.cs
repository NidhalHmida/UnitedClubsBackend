using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class EcoleResponse
    {

        public string Id_Ecole { get; set; }
        public string Nom_Ecole { get; set; }
        public string Téléphone_Ecole { get; set; }
        public string Adresse_Ecole { get; set; }
        public string Email_Ecole { get; set; }
        public byte[] Image { get; set; }

        public EcoleResponse()
        {
        }

        public EcoleResponse(string id_Ecole, string nom_Ecole, string téléphone_Ecole, string adresse_Ecole, string email_Ecole, byte[] image)
        {
            Id_Ecole = id_Ecole;
            Nom_Ecole = nom_Ecole;
            Téléphone_Ecole = téléphone_Ecole;
            Adresse_Ecole = adresse_Ecole;
            Email_Ecole = email_Ecole;
            Image = image;
        }
    }
}
