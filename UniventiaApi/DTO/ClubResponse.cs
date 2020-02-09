using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class ClubResponse
    {
        public string Id { get; set; }

        public string Id_Club { get; set; }

        public string Nom_Club { get; set; }

        public string Téléphone_Club { get; set; }

        public string Description { get; set; }

        public string Nombre_Membres { get; set; }

        public string Date_Création { get; set; }

        public string Email_Club { get; set; }

        public string Nom_université { get; set; }
   
        public string Nom_Ecole { get; set; }
     
        public int nombreSignalement { get; set; }

        public ClubResponse()
        {
        }
    }


}
