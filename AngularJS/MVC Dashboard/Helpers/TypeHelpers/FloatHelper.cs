using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Dashboard.Helpers.TypeHelpers
{
    public class FloatHelper
    {
        /// '-----------------------------------------------------------------------------------------
        /// 'returns integer values
        /// '-----------------------------------------------------------------------------------------
        public static float FloatGetValue(object Value)
        {
            return Value == DBNull.Value ? float.MinValue : (float)Value;
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Convert an object to a float number.
        /// </summary>
        /// <param name="oValue"></param>
        /// <returns>The object as a float or 0 if the object cannot be converted.</returns>
        /// '-----------------------------------------------------------------------------------------
        public static float ConvertToFloat(object oValue)
        {
            if (oValue == null || System.Convert.IsDBNull(oValue))
            {
                return 0;
            }

            string sString = oValue.ToString().Trim();

            double dValue = 0;
            if (double.TryParse(sString, NumberStyles.Any,
            CultureInfo.CurrentCulture, out dValue))
            {
                if (dValue <= float.MaxValue && dValue >= float.MinValue)
                {
                    return (float)(dValue);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Checks if a string is a numeric (int) value.
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static bool IsFloat(string stringToCheck)
        {
            float result;
            bool isFloat = true;
            if (stringToCheck == null)
            {
                stringToCheck = "";
            }
            try
            {
                result = float.Parse(stringToCheck);
            }
            catch
            {
                isFloat = false;
            }
            return isFloat;
        }
    }
}
