using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Dashboard.Helpers.TypeHelpers
{
    public class BooleanHelper
    {
        public static bool boolGetValue(object Object)
        {
            return Object == DBNull.Value ? false : Convert.ToBoolean(Object);
        }

        public static string GetBoolValueAsString(bool boolValue)
        {
            return boolValue == true ? "1" : "0";
        }

        public static string GetBoolTextFromValue(bool boolValue)
        {
            return boolValue == true ? "Yes" : "No";
        }

        public static bool ConvertToBool(object oValue)
        {
            if (oValue == null || System.Convert.IsDBNull(oValue))
            {
                return false;
            }

            string sString = oValue.ToString().Trim();

            bool bValue = false;
            if (bool.TryParse(sString, out bValue))
            {
                return bValue;
            }
            else
            {
                return false;
            }
        }
    }
}
