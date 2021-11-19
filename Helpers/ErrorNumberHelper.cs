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
    }
}
