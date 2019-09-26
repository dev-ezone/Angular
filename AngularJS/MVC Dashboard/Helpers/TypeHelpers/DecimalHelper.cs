using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Dashboard.Helpers.TypeHelpers
{
   public static class DecimalHelper
    {
        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Checks if a string is a decimal value.
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static bool IsDecimal(string stringToCheck)
        {
            decimal result;
            bool isDecimal = true;
            if (stringToCheck == null)
            {
                stringToCheck = String.Empty;
            }
            try
            {
                result = decimal.Parse(stringToCheck);
            }
            catch
            {
                isDecimal = false;
            }
            return isDecimal;
        }
    }
}
