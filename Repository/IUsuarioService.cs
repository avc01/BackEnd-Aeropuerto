using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository
{
    public interface IUsuarioService
    {
        int CreateUsuario(UsuarioWriteDto usuario);

        int ChangePassword(int id, string newPassword);

        IEnumerable<UsuarioReadDto> GetAllUsuarios();

        UsuarioReadDto GetUsuarioById(int id);

        int DeleteUsuarioById(int id);

        object GetUsuarioByEmail(string correo, string clave);
    }
}
