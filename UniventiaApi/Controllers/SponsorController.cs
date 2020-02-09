using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitedClubsApi.DTO;
using UnitedClubsApi.IRepository;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.Controllers
{
    [ApiController]
    [Produces("application/json")]

    public class SponsorController : Controller
    {
        private readonly ISponsorRepository _SponsorServices;

        public SponsorController(ISponsorRepository SponsorServices)
        {
            _SponsorServices = SponsorServices;
        }

        [Route("Sponsor/SignIn")]
        [HttpPost]
            public ActionResult<dynamic> SignInSponsor(SponsorRequestAuthentification e)
            {
                dynamic message = _SponsorServices.SignInSponsor(e);

                return Ok(message);
            }

            [Route("Sponsor/verification")]
            [HttpPost]
            public ActionResult<dynamic> SignInSponsorrVerification(SponsorRequestAuthentification s)
            {
                dynamic message = _SponsorServices.SignInSponsorVerification(s);

                return Ok(message);
            }

        [Route("Sponsor")]
        [HttpPost]
            public ActionResult<dynamic> SignUpStudent(Sponsor s)
            {
                dynamic message = _SponsorServices.SignUpSponsor(s);

                return Ok(message);
            }

        [Route("Sponsor/")]
        [Authorize(Roles = Role.Sponsor)]
        [HttpPut]
            public ActionResult<dynamic> UpdateSponsor(Sponsor s)
            {
            if (!User.IsInRole(Role.Sponsor))
            {
                return Forbid();
            }

            dynamic message = _SponsorServices.UpdateSponsor(s);

                return Ok(message);
            }


        [Route("Sponsor/")]
        [Authorize(Roles = Role.Sponsor)]
        [HttpDelete]
            public ActionResult<dynamic> Delete(String id)
            {
            if (!User.IsInRole(Role.Sponsor))
            {
                return Forbid();
            }
            dynamic message = _SponsorServices.DeleteSponsor(id);

                return Ok(message);
            }


        [Route("api/Sponsor")]
        [Authorize(Roles = Role.Club)]
        [HttpGet]
        public ActionResult<List<SponsorProfile>> getAllSponsors()
        {
            if (!User.IsInRole(Role.Club))
            {
                return Forbid();
            }
            List<SponsorProfile> sponsors = _SponsorServices.listerTousSponsor();

            return sponsors;
        }

        [Route("api/Sponsor/Poker")]
        [Authorize(Roles = Role.Club)]
        [HttpPost]
        public ActionResult<dynamic> PokerSponsor(PokeSponsorRequest request)
        {
            if (!User.IsInRole(Role.Club))
            {
                return Forbid();

            }
            dynamic message = _SponsorServices.PokeSponsor(request);


            return message;
        }

        [Route("api/SponsorPokes/{id}")]
        [Authorize(Roles = Role.Sponsor)]
        [HttpGet]
        public ActionResult<List<Poke>> listerPokesSponsor(string id)
        {
            if (!User.IsInRole(Role.Sponsor))
            {
                return Forbid();
            }
            List<Poke> pokes = _SponsorServices.listerPokeSponsor(id);

            return pokes;
        }

    }
    }