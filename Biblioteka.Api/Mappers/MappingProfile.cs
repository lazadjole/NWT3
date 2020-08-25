using AutoMapper;
using Biblioteka.Database.Models;
using Biblioteka.Domain.DomainObjects;
using Biblioteka.Domain.Dto;

namespace Biblioteka.Api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Naslov, NaslovDto>();
            CreateMap<Jezik, JezikDto>();
            CreateMap<Vrsta, VrstaDto>();
            CreateMap<Clan, ClanDto>();
            CreateMap<EvidencijaDugovanja, EvidencijaDugovanjaDto>();

            CreateMap<NaslovDto, Naslov>();
            CreateMap<JezikDto, Jezik>();
            CreateMap<VrstaDto, Vrsta>();
            CreateMap<ClanDto, Clan>();
            CreateMap<EvidencijaDugovanjaDto, EvidencijaDugovanja>();

            CreateMap<NaslovModel, Naslov>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.IdNaslov))
                .ForMember(dest => dest.Jezik, act => act.MapFrom(src => src.IdJezikNavigation))
                .ForMember(dest => dest.Vrsta, act => act.MapFrom(src => src.IdVrstaNavigation));
            CreateMap<JezikModel, Jezik>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.IdJezik));
            CreateMap<VrstaModel, Vrsta>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.IdVrsta));
            CreateMap<ClanModel, Clan>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.IdClan));
            CreateMap<EvidencijaDugovanjaModel, EvidencijaDugovanja>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.IdEvidencija))
                .ForMember(dest => dest.Naslov, act => act.MapFrom(src => src.IdNaslovNavigation))
                .ForMember(dest => dest.Clan, act => act.MapFrom(src => src.IdClanNavigation));

            CreateMap<Naslov, NaslovModel>()
                .ForMember(dest => dest.IdNaslov, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdJezik, act => act.MapFrom(src => src.Jezik.Id))
                .ForMember(dest => dest.IdVrsta, act => act.MapFrom(src => src.Vrsta.Id));
                

            CreateMap<Jezik, JezikModel>()
                .ForMember(dest => dest.IdJezik, act => act.MapFrom(src => src.Id));
            CreateMap<Vrsta, VrstaModel>()
                .ForMember(dest => dest.IdVrsta, act => act.MapFrom(src => src.Id));
            CreateMap<Clan, ClanModel>()
                .ForMember(dest => dest.IdClan, act => act.MapFrom(src => src.Id));
            CreateMap<EvidencijaDugovanja, EvidencijaDugovanjaModel>()
                .ForMember(dest => dest.IdEvidencija, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdNaslov, act => act.MapFrom(src => src.Naslov.Id))
                .ForMember(dest => dest.IdClan, act => act.MapFrom(src => src.Clan.Id));

        }
    }
}//namespace