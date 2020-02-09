using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitedClubsApi.DTO;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.IRepository
{
    public interface IUniversitéRepository
    {
        dynamic addUniversité(Université U);
        dynamic UpdateUniversité(Université U);
        dynamic DeleteUniversité(String id);
        List<UniversitéResponse> GetAllUniversities();
    }
}
