using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitedClubsApi.DTO;
using UnitedClubsApi.IRepository;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class UniversitéController : Controller
    {
        private readonly IUniversitéRepository _UniversitéServices;

        public UniversitéController(IUniversitéRepository UniversitéServices)
        {
            _UniversitéServices = UniversitéServices;
        }



        [Route("api/Universite")]
        [HttpPost]
        public ActionResult<dynamic> addUniversité(Université U)
        {
            dynamic message = _UniversitéServices.addUniversité(U);

            return message;
        }


        [Route("api/Universite")]
        [HttpPut]
        public ActionResult<dynamic> updateUniversité(Université U)
        {
            dynamic message = _UniversitéServices.UpdateUniversité(U);

            return message;
        }

        [Route("api/Universite")]
        [HttpGet]
        public ActionResult<List<UniversitéResponse>> getAllUniversities()
        {
            List<UniversitéResponse> universities = _UniversitéServices.GetAllUniversities();

            return universities;
        }

        [Route("api/Universite")]
        [HttpDelete]
        public ActionResult<dynamic> deleteUniversité(String id)
        {
            dynamic message = _UniversitéServices.DeleteUniversité(id);

            return message;
        }
    }
}