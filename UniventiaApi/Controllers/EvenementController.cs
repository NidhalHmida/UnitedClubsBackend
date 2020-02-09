using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UnitedClubsApi.DTO;
using UnitedClubsApi.IRepository;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.Controllers
{

    [ApiController]
    public class EvenementController : Controller
    {

        private readonly IEvenementRepository _EvenementServices;

        public EvenementController(IEvenementRepository EvenementServices)
        {
            _EvenementServices = EvenementServices;
        }

        [Route("api/Evenement")]
        [Authorize(Roles = Role.Club)]
        [HttpPost]
        public ActionResult<dynamic> addEvenement(Evenement E)
        {
            dynamic message = _EvenementServices.addEvenement(E);

            if (!User.IsInRole(Role.Club))
            {
                return Forbid();
            }

            return message;
        }


        [Route("api/Evenement")]
        [Authorize(Roles = Role.Club)]
        [HttpPut]
        public ActionResult<dynamic> updateEvenement(Evenement E)
        {
            if (!User.IsInRole(Role.Club))
            {
                return Forbid();
            }

            dynamic message = _EvenementServices.updateEvenement(E);

            return message;
        }

        [Route("api/Evenement")]
        [HttpGet]
        public ActionResult<List<Evenement>>Evenements()
        {
            List<Evenement> evenements= _EvenementServices.listerTousEvenements();

            return evenements;
        }


        [Route("api/Evenement/region={region}")]
        [HttpGet]
        public ActionResult<List<EvenementInfos>> EvenementsSelonRegion(String region)
        {
         
            List<EvenementInfos> evenements = _EvenementServices.listerTousEvenementsSelonRegion(region);

            return evenements;
        }

        [Route("api/Evenement/domaine={domaine}")]
        [HttpGet]
        public ActionResult<List<EvenementInfos>> EvenementsSelonDomaine(String domaine)
        {
          
            List<EvenementInfos> evenements = _EvenementServices.listerTousEvenementsSelonDomaine(domaine);

            return evenements;
        }

        [Route("api/Evenement/universite={universite}")]
        [HttpGet]
        public ActionResult<List<EvenementInfos>> EvenementsSelonUniversité(String universite)
        {

            List<EvenementInfos> evenements = _EvenementServices.listerTousEvenementsSelonUniversité(universite);

            return evenements;
        }

        [Route("api/Evenement/ecole={ecole}")]
        [HttpGet]
        public ActionResult<List<EvenementInfos>> EvenementsSelonEcole(String ecole)
        {

            List<EvenementInfos> evenements = _EvenementServices.listerTousEvenementsSelonEcole(ecole);

            return evenements;
        }


        [Route("api/Evenement/club={club}")]
        [HttpGet]
        public ActionResult<List<EvenementInfos>> EvenementsSelonClub(String club)
        {

            List<EvenementInfos> evenements = _EvenementServices.listerTousEvenementsSelonClub(club);

            return evenements;
        }

        [Route("api/Evenement/date={date}")]
        [HttpGet]
        public ActionResult<List<EvenementInfos>> EvenementsSelonDate(String date)
        {

            List<EvenementInfos> evenements = _EvenementServices.listerTousEvenementsSelonDate(date);

            return evenements;
        }


        [Route("api/Evenement/dateInscriptionValide")]
        [Authorize(Roles = Role.Etudiant)]
        [HttpGet]
        public ActionResult<List<EvenementInfos>> listerEvenementInscriptionValide()
        {

            if (!User.IsInRole(Role.Etudiant))
            {
                return Forbid();
            }

            List<EvenementInfos> evenements = _EvenementServices.listerEvenementInscriptionValide();

            return evenements;
        }


        [Route("api/Evenement/evenementsRecommandation={date}")]
        [Authorize(Roles = Role.Club)]
        [HttpGet]
        public ActionResult<List<EvenementInfos>> listerEvenementsRecommandation(String date)
        {
            if (!User.IsInRole(Role.Club))
            {
                return Forbid();
            }

            List<EvenementInfos> evenements = _EvenementServices.listerEvenementRecommandations(date);

            return evenements;
        }

        [Route("api/Evenement/inscription")]
        [Authorize(Roles = Role.Etudiant)]
        [HttpPost]
        public ActionResult<dynamic> inscriptionEvenement(EtudiantInscriptionEvenementRequest E)
        {
            if (!User.IsInRole(Role.Etudiant))
            {
                return Forbid();
            }
            dynamic message = _EvenementServices.inscriptionEvenementEtudiant(E);

            return message;
        }

        [Route("api/Evenement/etudiants")]
        [Authorize(Roles = Role.Club)]
        [HttpPost]
        public ActionResult<List<EtudiantProfile>> ListerEtudiantsInscrits(EtudiantInscriptionEvenementRequest E)
        {

            if (!User.IsInRole(Role.Club))
            {
                return Forbid();
            }

            List < EtudiantProfile > etudiants = _EvenementServices.listerEtudiantsInscrits(E);

            return etudiants;
        }

        [Route("api/Evenement/evenementEtudiants")]
        [Authorize(Roles = Role.Etudiant)]
        [HttpPost]
        public ActionResult<List<EvenementInfos>> ListerevenementEtudiants(EtudiantProfile E)
        {
            if (!User.IsInRole(Role.Etudiant))
            {
                return Forbid();
            }

            List<EvenementInfos> evenements = _EvenementServices.listerEvenementsEtudiant(E);

            return evenements;
        }


        [Route("api/Evenement")]
        [Authorize(Roles = Role.Club)]
        [HttpDelete]
        public ActionResult<dynamic> deleteEvenement(String id)
        {

            if (!User.IsInRole(Role.Club))
            {
                return Forbid();
            }
            dynamic message = _EvenementServices.SupprimerEvenement(id);

            return message;
        }

    }
}