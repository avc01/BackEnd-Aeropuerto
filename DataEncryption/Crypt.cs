using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;

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
                if (property.GetValue(data) == null)
                {
                    continue;
                }

                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(data, _dataProtector.Protect((string)property.GetValue(data)));
                }
            }
            return data;
        }

        T ICrypt<T>.DecryptDataOneRow(T data)
        {
            Type type = data.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(data) == null)
                {
                    continue;
                }

                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(data, _dataProtector.Unprotect((string)property.GetValue(data)));
                }
            }
            return data;
        }

        IEnumerable<T> ICrypt<T>.DecryptDataMultipleRows (IEnumerable<T> data)
        {
            foreach (T item in data)
            {
                Type type = item.GetType();

                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    if (property.GetValue(item) == null)
                    {
                        continue;
                    }

                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(item, _dataProtector.Unprotect((string)property.GetValue(item)));
                    }
                }
            }
            return data;
        }

        public string EncryptSingleString(string value) 
        {
            return _dataProtector.Protect(value);
        }

        public IEnumerable<string> DecryptEnumerableString(IEnumerable<string> lista)
        {
            List<string> listToReturn = new List<string>();

            foreach (var item in lista)
            {
               listToReturn.Add(_dataProtector.Unprotect(item));
            }
           
            return listToReturn;
        }
    }
}
