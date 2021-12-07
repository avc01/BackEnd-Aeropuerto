using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IRolService
    {
        int AsignarRolAUsuario(RolWriteDto rol);

        object GetAllRoles();

        int DeleteRolById(int id);
    }
}
