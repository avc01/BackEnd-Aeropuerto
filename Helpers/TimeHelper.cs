using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Aeropuerto.Helpers
{
    public static class TimeHelper
    {
        public static string GetLongDate()
        {
            DateTime dateTime = DateTime.Now;

            dateTime.ToLongDateString();

            return dateTime.ToString();
        }
    }
}
