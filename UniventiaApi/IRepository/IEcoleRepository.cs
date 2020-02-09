using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitedClubsApi.DTO;

namespace UnitedClubsApi.IRepository
{
    public interface IEcoleRepository
    {
        dynamic addEcole(EcoleRequest E);
        dynamic updateEcole(EcoleRequest E);
        List<EcoleResponse> GetAllEcoles(EcoleRequest E);
        dynamic deleteEcole(EcoleRequest E);
    }
}
