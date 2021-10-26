using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.DataEncryption
{
    public class Crypt<T> : ICrypt<T>
    {
        private readonly IDataProtector _dataProtector;

        public Crypt(IDataProtectionProvider dataProtectionProvider, IConfiguration configuration)
        {
            _dataProtector = dataProtectionProvider.CreateProtector(configuration.GetSection("SecretKey").Value);
        }

        T ICrypt<T>.EncryptData(T data)
        {
            Type type = data.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string) || property.PropertyType == typeof(DateTime))
                {
                    property.SetValue(type, _dataProtector.Protect((byte[])property.GetValue(type, null)));
                }
            }

            return data;
        }
    }
}
