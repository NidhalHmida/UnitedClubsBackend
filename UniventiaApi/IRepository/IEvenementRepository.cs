
using System;
using System.Collections.Generic;
using UnitedClubsApi.DTO;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.IRepository
{
    public interface IEvenementRepository
    {
        dynamic addEvenement(Evenement E);
        dynamic updateEvenement(Evenement e);
        dynamic SupprimerEvenement(string id);
        dynamic inscriptionEvenementEtudiant(EtudiantInscriptionEvenementRequest I);
        List<Evenement> listerTousEvenements();
        List<EvenementInfos> listerTousEvenementsSelonRegion(String région);
        List<EvenementInfos> listerTousEvenementsSelonDomaine(String domaine);
        List<EvenementInfos> listerTousEvenementsSelonUniversité(String universite );
        List<EvenementInfos> listerTousEvenementsSelonEcole(String ecole);
        List<EvenementInfos> listerTousEvenementsSelonClub(String club);
        List<EvenementInfos> listerTousEvenementsSelonDate(String date);
        List<EtudiantProfile> listerEtudiantsInscrits(EtudiantInscriptionEvenementRequest E);
        List<EvenementInfos> listerEvenementsEtudiant(EtudiantProfile E);
        List<EvenementInfos> listerEvenementInscriptionValide();
        List<EvenementInfos> listerEvenementRecommandations(String date);


    }
}
