using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Helpers
{
    public static class ErrorNumberHelper
    {
        public static Random errorNumber = new Random();

        public static int GenerateNumber()
        {
            return errorNumber.Next();
        }

        public static int NumeroReservacion()
        {
            return errorNumber.Next(1, 1000000);
        }

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars,7)
                .Select(s => s[errorNumber.Next(s.Length)]).ToArray());
        }
    }
}
