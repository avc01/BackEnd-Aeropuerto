using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.DataEncryption
{
    public interface ICrypt<T>
    {
        T EncryptData(T data);

        T DecryptDataOneRow(T data);

        IEnumerable<T> DecryptDataMultipleRows(IEnumerable<T> data);
    }
}
