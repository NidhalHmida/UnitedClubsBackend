
using AutoMapper;
using System.Collections.Generic;
using UnitedClubsApi.Dto;
using UnitedClubsApi.Models;

namespace UnitedClubsApi.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<EtudiantRequestAuthentification, Etudiant>().ReverseMap();
            CreateMap< Etudiant,EtudiantProfile>().ReverseMap();
            CreateMap<SponsorRequestAuthentification, Sponsor>().ReverseMap();
            CreateMap<Sponsor, SponsorProfile>().ReverseMap();
            CreateMap<AdminEcoleRequestAuthentification, AdminEcole>().ReverseMap();
            CreateMap<AdminEcole, AdminEcoleProfile>().ReverseMap();
            CreateMap<Université, UniversitéResponse>().ReverseMap();
            CreateMap<Ecole, EcoleResponse>().ReverseMap();
            CreateMap<Club, ClubResponse>().ReverseMap();
            CreateMap<ClubRequestAuthentification, Club>().ReverseMap();
            CreateMap<EcoleRequest, Ecole>().ReverseMap();
            CreateMap<Evenement, EvenementInfos>().ReverseMap();

        }
    }
}
