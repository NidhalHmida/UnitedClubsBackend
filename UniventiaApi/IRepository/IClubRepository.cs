using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitedClubsApi.DTO;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.IRepository
{
    public interface IClubRepository
    {
        dynamic Inscription(Club club);
        dynamic Connexion(ClubRequestAuthentification club);
        dynamic updateClub(Club club);
         List<ClubResponse>listerTousClubs(ClubRequest clubs);
        List<ClubResponse> listerTousClubsAdmin();
        dynamic deactiverClub(String id);
        dynamic signalerClub(SignalementClubRequest request);
        dynamic listerSignalementClub(string id);
        dynamic supprimerClubSignalement(string id);
    }
}
