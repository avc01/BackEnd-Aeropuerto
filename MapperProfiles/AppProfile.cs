using AutoMapper;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Models;

namespace BackEnd_Aeropuerto.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Aerolinea, AerolineaReadDto>().ReverseMap();
            CreateMap<Bitacora, BitacoraReadDto>().ReverseMap();
            CreateMap<Compra, CompraReadDto>().ReverseMap();
            CreateMap<Consecutivo, ConsecutivoReadDto>().ReverseMap();
            CreateMap<EstadoVuelo, EstadoVueloReadDto>().ReverseMap();
            CreateMap<Pais, PaisReadDto>().ReverseMap();
            CreateMap<Puerta, PuertaReadDto>().ReverseMap();
            CreateMap<Reserva, ReservaReadDto>().ReverseMap();
            CreateMap<Rol, RolReadDto>().ReverseMap();
            CreateMap<Tarjeta, TarjetaReadDto>().ReverseMap();
            CreateMap<Usuario, UsuarioReadDto>().ReverseMap();
            CreateMap<Vuelo, VueloReadDto>().ReverseMap();
        }
    }
}
