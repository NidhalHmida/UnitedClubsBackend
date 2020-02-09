using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnitedClubsApi.DTO;
using UnitedClubsApi.IRepository;
using UnitedClubsApi.Models;
using UnitedClubsApi.Services;

namespace UnitedClubsApi.Controllers
{
    [ApiController]
    public class AdminController : Controller
    {

        private readonly IAdminEcoleRepository _AdminServices;
      
        public AdminController(IAdminEcoleRepository AdminServices)
        {
            _AdminServices = AdminServices;
   
        }
       
        [Route("api/Admin/")]
        [HttpPost]
        public ActionResult<string> addAdmin(AdminEcole A)
        {
            dynamic message = _AdminServices.addAdmin(A);

            return Ok(message);
        }


        [Route("api/Admin/SignIn")]
        [HttpPost]
        public ActionResult<dynamic> SignInAdmin(AdminEcoleRequestAuthentification a)
        {
            dynamic message = _AdminServices.SignInAdminEcole(a);

            return Ok(message);
        }
        [Route("api/Admin/")]
        [HttpPut]
        public ActionResult<dynamic> updateAdmin(AdminEcole A)
        {
            dynamic message = _AdminServices.UpdateAdmin(A);


            return Ok(message);
        }

        [Route("api/Admin/")]
        [HttpGet]
        public ActionResult<List<AdminEcole>> getAllAdmins()
        {
            List<AdminEcole>  admins = _AdminServices.GetAllAdmins();

            return Ok(admins);
        }

        [Route("api/Admin/")]
        [HttpDelete]
        public ActionResult<string> deleteAdmin(String id)
        {
            dynamic message = _AdminServices.DeleteAdmin(id);

            return Ok(message);
        }

    

     
    }
}