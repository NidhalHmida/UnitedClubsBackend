using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UnitedClubsApi.DTO;
using UnitedClubsApi.IRepository;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
 
    public class ClubController : Controller
    {
        private readonly IClubRepository _ClubServices;

        public ClubController(IClubRepository ClubServices)
        {
            _ClubServices = ClubServices;
        }



        [Route("api/Club")]
        [HttpPost]
        public ActionResult<dynamic> SignUP(Club U)
        {
            dynamic message = _ClubServices.Inscription(U);

            return message;
        }

        [Route("api/Club/SignIn")]
        [HttpPost]
        public ActionResult<dynamic> SignIn(ClubRequestAuthentification clubRequest)
        {
           dynamic message  = _ClubServices.Connexion(clubRequest);

          
            return message;
        }


        [Route("api/Club/Signaler")]
        [Authorize(Roles = Role.Etudiant)]
        [HttpPost]
        public ActionResult<dynamic> SignalerClub(SignalementClubRequest request)
        {
            if (!User.IsInRole(Role.AdminE))
            {
                return Forbid();

            }
                dynamic message = _ClubServices.signalerClub(request);


            return message;
        }


        [Route("api/Club")]
        [Authorize(Roles = Role.Club)]
        [HttpPut]
        public ActionResult<dynamic> updateClub(Club U)
        {
            if (!User.IsInRole(Role.Club))
            {
                return Forbid();
            }
            
            dynamic message = _ClubServices.updateClub(U);

            return message;
        }

        [Route("api/Clubs")]
        [Authorize(Roles = Role.AdminE)]
        [HttpPost]
        public ActionResult<List<ClubResponse>> getAllClubsByUnivesity(ClubRequest clubRequest)
        {
            if (!User.IsInRole(Role.AdminE))
            {
                return Forbid();
            }
            List<ClubResponse> clubs = _ClubServices.listerTousClubs(clubRequest);

            return clubs;
        }

        [Route("api/ClubSignalements/{id}")]
        [Authorize(Roles = Role.AdminE)]
        [HttpGet]
        public ActionResult<List<Signalement>> listerSignalement(string id)
        {
            if (!User.IsInRole(Role.AdminE))
            {
                return Forbid();
            }
            List<Signalement> signalements = _ClubServices.listerSignalementClub(id);

            return signalements;
        }


        [Route("api/ClubsAdmin")]
        [HttpGet]
        public ActionResult<List<ClubResponse>> getAllClubsAdmin()
        {
           
            List<ClubResponse> clubs = _ClubServices.listerTousClubsAdmin();

            return clubs;
        }

        [Route("api/Club")]
        [Authorize(Roles = Role.Club)]
        [HttpDelete]
        public ActionResult<dynamic> desactiverClubCompte(String id)
        {
            if (!User.IsInRole(Role.Club))
            {
                return Forbid();
            }

            dynamic message = _ClubServices.deactiverClub(id);

            return message;
        }


        [Route("api/Club/Signalement/{id}")]
        [Authorize(Roles = Role.AdminE)]
        [HttpDelete]
        public ActionResult<dynamic> deleteClubSignalement(String id)
        {
            if (!User.IsInRole(Role.AdminE))
            {
                return Forbid();
            }

            dynamic message = _ClubServices.supprimerClubSignalement(id);

            return message;
        }
    }
}
