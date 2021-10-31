using AutoMapper;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Models;

namespace BackEnd_Aeropuerto.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Aerolinea, AerolineaDto>().ReverseMap();
            CreateMap<Bitacora, BitacoraDto>().ReverseMap();
            CreateMap<Compra, CompraDto>().ReverseMap();
            CreateMap<Consecutivo, ConsecutivoDto>().ReverseMap();
            CreateMap<EstadoVuelo, EstadoVueloDto>().ReverseMap();
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Puerta, PuertaDto>().ReverseMap();
            CreateMap<Reserva, ReservaDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<Tarjeta, TarjetaDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Vuelo, VueloDto>().ReverseMap();
        }
    }
}
