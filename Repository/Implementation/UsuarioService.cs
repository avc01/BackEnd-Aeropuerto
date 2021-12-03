using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.DataEncryption;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using BackEnd_Aeropuerto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<UsuarioReadDto> _cryptRead;
        private readonly ICrypt<UsuarioWriteDto> _cryptWrite;
        private readonly IErrorService _errorService;

        public UsuarioService(
            AppDbContext context, 
            IMapper mapper, 
            ICrypt<UsuarioReadDto> cryptRead, 
            ICrypt<UsuarioWriteDto> cryptWrite,
            IErrorService errorService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _errorService = errorService;
        }

        public int ChangePassword(int id, string newPassword)
        {
            try
            {
                var resultEncrypted = _cryptWrite.EncryptSingleString(newPassword);

                _context.Database.ExecuteSqlInterpolated($"sp_ChangePassword {id}, {resultEncrypted}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public int CreateUsuario(UsuarioWriteDto usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var resultEncrypted = _cryptWrite.EncryptData(usuario);

            var resultMapped = _mapper.Map<Usuario>(resultEncrypted);

            try
            {
                // Se crea el usuario con un procedimiento almacenado.
                _context.Database.ExecuteSqlInterpolated($"sp_CreateUsuario {resultMapped.NombreUsuario}, {resultMapped.Contraseña}, {resultMapped.ConfirmaContraseña}, {resultMapped.Correo}, {resultMapped.Pregunta}, {resultMapped.Respuesta}");

                // Se busca el ultimo usuario creado para extraer el primery key con un procedimiento almacenado.
                var allUsuarios = GetAllUsuarios().TakeLast(1).FirstOrDefault();

                // Se encripta el rol por defecto a asignar.
                var encryptedResult = _cryptWrite.EncryptSingleString("Consulta");

                // Se crea el rol por defecto "Consulta" asignado usuario recientemente creado con un procedimiento almacenado.
                _context.Database.ExecuteSqlInterpolated($"sp_CreateRol {encryptedResult},{allUsuarios.UsuarioId}");

                // Se retorna un 1 indicando que fue un exito.
                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public int DeleteUsuarioById(int id)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeleteUsuarioById {id}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public IEnumerable<UsuarioReadDto> GetAllUsuarios()
        {
            var result = _context.Usuarios.FromSqlInterpolated<Usuario>($"sp_GetUsuarios")
                .ToList();

            if (result is null) return null;

            var resultMapped = _mapper.Map<IEnumerable<UsuarioReadDto>>(result);

            var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

            return resultDecrypted;
        }

        public UsuarioReadDto GetUsuarioById(int id)
        {
            var result = _context.Usuarios
               .FromSqlInterpolated<Usuario>($"sp_GetUsuarioById {id}")
               .ToList()
               .FirstOrDefault();

            if (result is null) return null;

            var resultMapped = _mapper.Map<UsuarioReadDto>(result);

            var resultDecrypted = _cryptRead.DecryptDataOneRow(resultMapped);

            return resultDecrypted;
        }
        
        public object GetUsuarioByEmail(string correo, string clave)
        {
            var result = GetAllUsuarios();

            var resultFiltered = result.Where(x => x.Correo == correo && x.Contraseña == clave).FirstOrDefault();

            if (resultFiltered is null) return false;

            var userRolResult = _context.Roles.FromSqlInterpolated<Rol>($"sp_GetRolesDeUsuario {resultFiltered.UsuarioId}")
                .ToList().Select(x => x.Tipo);

            var userRolResultDecrypted = _cryptRead.DecryptEnumerableString(userRolResult);
                
            return new { EstaLogeado = true, userRolResultDecrypted };
        }
    }
}
