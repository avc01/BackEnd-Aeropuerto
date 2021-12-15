using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public interface ICompraService
    {
        int CreateCompra(CompraWriteDto compraWriteDto);

        IEnumerable<CompraReadDto> GetCompras();

        object GetComprasDeUsuarioByCorreo(string correo);
    }
}
