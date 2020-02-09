using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitedClubsApi.DTO;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.IRepository
{
    public interface IAdminEcoleRepository
    {
        dynamic addAdmin(AdminEcole a);
        dynamic SignInAdminEcole(AdminEcoleRequestAuthentification a);
        dynamic UpdateAdmin(AdminEcole a);
        dynamic DeleteAdmin(String id);
        List<AdminEcoleProfile> GetAllAdmins();

    }
}
