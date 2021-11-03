using AutoMapper;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
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
            CreateMap<Error, ErrorReadDto>().ReverseMap();
            CreateMap<EstadoVuelo, EstadoVueloReadDto>().ReverseMap();
            CreateMap<Pais, PaisReadDto>().ReverseMap();
            CreateMap<Puerta, PuertaReadDto>().ReverseMap();
            CreateMap<Reserva, ReservaReadDto>().ReverseMap();
            CreateMap<Rol, RolReadDto>().ReverseMap();
            CreateMap<Tarjeta, TarjetaReadDto>().ReverseMap();
            CreateMap<Usuario, UsuarioReadDto>().ReverseMap();
            CreateMap<Vuelo, VueloReadDto>().ReverseMap();

            CreateMap<Aerolinea, AerolineaWriteDto>().ReverseMap();
            CreateMap<Bitacora, BitacoraWriteDto>().ReverseMap();
            CreateMap<Compra, CompraWriteDto>().ReverseMap();
            CreateMap<Consecutivo, ConsecutivoWriteDto>().ReverseMap();
            CreateMap<Error, ErrorWriteDto>().ReverseMap();
            CreateMap<EstadoVuelo, EstadoVueloWriteDto>().ReverseMap();
            CreateMap<Pais, PaisWriteDto>().ReverseMap();
            CreateMap<Puerta, PuertaWriteDto>().ReverseMap();
            CreateMap<Reserva, ReservaWriteDto>().ReverseMap();
            CreateMap<Rol, RolWriteDto>().ReverseMap();
            CreateMap<Tarjeta, TarjetaWriteDto>().ReverseMap();
            CreateMap<Usuario, UsuarioWriteDto>().ReverseMap();
            CreateMap<Vuelo, VueloWriteDto>().ReverseMap();
        }
    }
}
