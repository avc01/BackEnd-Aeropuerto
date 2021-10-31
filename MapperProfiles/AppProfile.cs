using AutoMapper;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Models;

namespace BackEnd_Aeropuerto.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Consecutivo, ConsecutivoDto>().ReverseMap();
        }
    }
}
