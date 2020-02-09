using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitedClubsApi.Dto;
using UnitedClubsApi.IRepository;
using UnitedClubsApi.Models;


namespace UnitedClubsApi.Controllers
{

    [ApiController]
    [Produces("application/json")]
    public class EtudiantController : Controller

    {
       
        private readonly IEtudiantRepository _EtudiantServices;

        public EtudiantController(IEtudiantRepository EtudiantServices)
        {
            _EtudiantServices = EtudiantServices;
        }

        [Route("Etudiant/SignIn")]
        [HttpPost]
        public ActionResult<dynamic> SignInEtudiant(EtudiantRequestAuthentification e )
        {
            dynamic message = _EtudiantServices.SignInEtudiant(e);

            return  Ok(message);
        }

        [Route("Etudiant/verification")]
        [HttpPost]
        public ActionResult<dynamic> SignInEtudiantrVerification(EtudiantRequestAuthentification e)
        {
            dynamic message = _EtudiantServices.SignInEtudiantrVerification(e);

            return Ok(message);
        }

        [Route("Etudiant")]
        [HttpPost]
        public ActionResult<dynamic> SignUpStudent(Etudiant e)
        {
            dynamic message = _EtudiantServices.SignUpStudent(e);
            return Ok(message);
        }

        [Route("Etudiant/")]
        [Authorize(Roles = Role.Etudiant)]
        [HttpPut]
        public ActionResult<dynamic> UpdateEtudiant(Etudiant e)
        {
            if (!User.IsInRole(Role.Etudiant))
            {
                return Forbid();
            }

            dynamic message = _EtudiantServices.UpdateEtudiant(e);

            return Ok(message);
        }


        [Route("Etudiant/")]
        [Authorize(Roles = Role.Etudiant)]
        [HttpDelete]
        public ActionResult<dynamic> Delete(String id)
        {

            if (!User.IsInRole(Role.Etudiant))
            {
                return Forbid();
            }
            dynamic message = _EtudiantServices.DeleteEtudiant(id);

            return Ok(message);
        }

        
    
    }
}