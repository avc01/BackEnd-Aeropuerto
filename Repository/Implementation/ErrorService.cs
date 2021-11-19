using AutoMapper;
using BackEnd_Aeropuerto.Data;
using BackEnd_Aeropuerto.DataEncryption;
using BackEnd_Aeropuerto.Dtos;
using BackEnd_Aeropuerto.Dtos.WriteDtos;
using BackEnd_Aeropuerto.Helpers;
using BackEnd_Aeropuerto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Repository.Implementation
{
    public class ErrorService : IErrorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICrypt<ErrorReadDto> _cryptRead;
        private readonly ICrypt<ErrorWriteDto> _cryptWrite;

        public ErrorService(AppDbContext context, IMapper mapper, ICrypt<ErrorReadDto> cryptRead, ICrypt<ErrorWriteDto> cryptWrite)
        {
            _context = context;
            _mapper = mapper;
            _cryptRead = cryptRead;
            _cryptWrite = cryptWrite;
        }

        public int CreateError(ErrorWriteDto error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            if (!error.Numero.HasValue)
            {
                error.Numero = ErrorNumberHelper.GenerateNumber();
            }

            if (string.IsNullOrWhiteSpace(error.FechaHora))
            {
                error.FechaHora = TimeHelper.GetLongDate();
            }
           
            var resultEncrypted = _cryptWrite.EncryptData(error);

            var resultMapped = _mapper.Map<Error>(resultEncrypted);

            try
            {
                _context.Database.ExecuteSqlInterpolated($"sp_CreateError {resultMapped.FechaHora}, {resultMapped.Numero}, {resultMapped.Mensaje}");

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int DeleteErrorById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ErrorReadDto> GetAllErrores()
        {
            throw new NotImplementedException();
        }
    }
}
