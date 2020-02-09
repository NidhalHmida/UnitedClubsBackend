using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitedClubsApi.DTO
{
    public class EtudiantInscriptionEvenementRequest
    {
        public String Id_Evenement { get; set; }
        public EtudiantProfile etudiant { get; set; }

        public EtudiantInscriptionEvenementRequest()
        {
        }
    }
}
