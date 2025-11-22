
using AutoMapper;
using ListadoBecasApp.DTOs;
using ListadoBecasApp.Models;

namespace ListadoBecasApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Beca, BecaDto>()
                .ForMember(dest => dest.NombreCarrera,
                    opt => opt.MapFrom((src, dest) =>
                        src.IdCarreraNavigation != null
                            ? src.IdCarreraNavigation.NombreCarrera
                            : "Sin carrera"
                     ));

            CreateMap<BecaDto, Beca>()
                .ForMember(dest => dest.IdCarreraNavigation, opt => opt.Ignore());

            // CARRERAS
            CreateMap<Carrera, CarreraDto>();
            CreateMap<CarreraDto, Carrera>();


        }
    }
}
