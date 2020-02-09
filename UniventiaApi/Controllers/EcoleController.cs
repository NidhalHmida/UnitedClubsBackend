using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitedClubsApi.DTO;
using UnitedClubsApi.IRepository;

namespace UnitedClubsApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class EcoleController : Controller
    {
        private readonly IEcoleRepository _EcoleServices;

        public EcoleController(IEcoleRepository EcoleServices)
        {
            _EcoleServices = EcoleServices;
        }

        [Route("api/Ecole")]
        [HttpPost]
        public ActionResult<dynamic> addEcole(EcoleRequest E)
        {
            dynamic message = _EcoleServices.addEcole(E);

            return message;
        }


        [Route("api/Ecole")]
        [HttpPut]
        public ActionResult<dynamic> updateEcole(EcoleRequest E)
        {
            dynamic message = _EcoleServices.updateEcole(E);

            return message;
        }

        [Route("api/Ecoles")]
        [HttpPost]
        public ActionResult<List<EcoleResponse>> getAllEcoles(EcoleRequest E)
        {
            List<EcoleResponse> ecoles = _EcoleServices.GetAllEcoles(E);

            return ecoles;
        }

        [Route("api/Ecole")]
        [HttpDelete]
        public ActionResult<dynamic> deleteEcole(EcoleRequest E)
        {
            dynamic message = _EcoleServices.deleteEcole(E);

            return message;
        }
    }
}