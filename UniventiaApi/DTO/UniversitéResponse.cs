using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class UniversitéResponse
    {
  
        public string Id { get; set; }
       
        public string Id_Université { get; set; }
       
        public string Nom_Université { get; set; }

        public string Région { get; set; }
    
        public string Téléphone_Université { get; set; }

        public string Adresse_Université { get; set; }
      
        public string Email_Université { get; set; }
        
        public byte[] Image { get; set; }

        public UniversitéResponse()
        {
        }

        public UniversitéResponse(string id_Université, string nom_Université, string région, string téléphone_Université, string adresse_Université, string email_Université, byte[] image)
        {
            Id_Université = id_Université;
            Nom_Université = nom_Université;
            Région = région;
            Téléphone_Université = téléphone_Université;
            Adresse_Université = adresse_Université;
            Email_Université = email_Université;
            Image = image;
        }
    }
}
