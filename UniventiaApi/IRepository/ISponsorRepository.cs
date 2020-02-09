using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitedClubsApi.DTO;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.IRepository
{
    public interface ISponsorRepository
    {
        dynamic SignUpSponsor(Sponsor e);
        dynamic SignInSponsor(SponsorRequestAuthentification e);
        dynamic SignInSponsorVerification(SponsorRequestAuthentification e);
        dynamic UpdateSponsor(Sponsor e);
        dynamic DeleteSponsor(String id);
        dynamic PokeSponsor(PokeSponsorRequest request);
        dynamic listerPokeSponsor(string id);
        List<SponsorProfile> listerTousSponsor();
    }
}
