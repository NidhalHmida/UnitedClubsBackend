using System;
using UnitedClubsApi.Dto;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.IRepository
{
    public interface IEtudiantRepository
    {

        dynamic SignUpStudent(Etudiant e);

        dynamic SignInEtudiant(EtudiantRequestAuthentification e);

        dynamic SignInEtudiantrVerification(EtudiantRequestAuthentification e);

         dynamic UpdateEtudiant(Etudiant e);

        dynamic DeleteEtudiant(String id);



    }
}
