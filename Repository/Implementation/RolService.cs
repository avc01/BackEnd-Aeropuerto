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
    public class RolService : IRolService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<RolReadDto> _cryptRead;
        private readonly ICrypt<RolWriteDto> _cryptWrite;
        private readonly IErrorService _errorService;
        private readonly IUsuarioService _usuarioService;

        public RolService(
           AppDbContext context,
           IMapper mapper,
           ICrypt<RolReadDto> cryptRead,
           ICrypt<RolWriteDto> cryptWrite,
           IErrorService errorService,
           IUsuarioService usuarioService)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
            _errorService = errorService;
            _usuarioService = usuarioService;
        }

        public int AsignarRolAUsuario(RolWriteDto rol)
        {
            if (rol == null)
            {
                throw new ArgumentNullException(nameof(rol));
            }

            var resultEncrypted = _cryptWrite.EncryptData(rol);

            var resultMapped = _mapper.Map<Rol>(resultEncrypted);

            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_CreateRol {resultMapped.Tipo}, {resultMapped.UsuarioId}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public int DeleteRolById(int id)
        {
            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_DeleteRolById {id}");

                return 1;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return 0;
            }
        }

        public object GetAllRoles()
        {
            try
            {
                var resultAllUsers = _usuarioService.GetAllUsuarios();

                var result = _context.Roles.FromSqlInterpolated<Rol>($"sp_GetRoles")
                    .ToList();

                if (result is null) return null;

                var resultMapped = _mapper.Map<IEnumerable<RolReadDto>>(result);

                var resultDecrypted = _cryptRead.DecryptDataMultipleRows(resultMapped);

                var query = (from roles in resultDecrypted
                             join usuarios in resultAllUsers on roles.UsuarioId equals usuarios.UsuarioId
                             select new
                             {
                                 Id = roles.RolId,
                                 Rol = roles.Tipo,
                                 UsuarioId = roles.UsuarioId,
                                 NombreDeUsuario = usuarios.NombreUsuario
                             }).ToList();

                return query;
            }
            catch (Exception e)
            {
                _errorService.CreateError(new ErrorWriteDto { Mensaje = e.Message });

                return null;
            }
        }
    }
}
