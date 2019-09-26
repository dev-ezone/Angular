using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Dashboard.Helpers.TypeHelpers
{
    public static class IntegerHelper
    {
        /// '-----------------------------------------------------------------------------------------
        /// 'returns integer values
        /// '-----------------------------------------------------------------------------------------
        public static int IntGetVal(object Value)
        {
            return Value == DBNull.Value ? int.MinValue : (int)Value;
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Convert an object to an integer number.
        /// </summary>
        /// <param name="oValue"></param>
        /// <returns>The object as an integer or 0 if the object cannot be converted.</returns>
        /// '-----------------------------------------------------------------------------------------
        public static int ConvertToInt(object oValue)
        {
            if (oValue == null || System.Convert.IsDBNull(oValue))
            {
                return 0;
            }

            string sString = oValue.ToString().Trim();

            int iValue = 0;
            if (int.TryParse(sString, NumberStyles.Any,
            CultureInfo.CurrentCulture, out iValue))
            {
                if (iValue <= int.MaxValue && iValue >= int.MinValue)
                {
                    return iValue;
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
        /// Convert an object to an integer number.
        /// </summary>
        /// <param name="oValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns>The object as an integer or the defaultValue if the object cannot be converted.</returns>
        /// '-----------------------------------------------------------------------------------------
        public static int ConvertToInt(object oValue, int defaultValue)
        {
            if (oValue == null || System.Convert.IsDBNull(oValue))
            {
                return defaultValue;
            }

            string sString = oValue.ToString().Trim();

            int iValue = 0;
            if (int.TryParse(sString, NumberStyles.Any,
            CultureInfo.CurrentCulture, out iValue))
            {
                if (iValue <= int.MaxValue && iValue >= int.MinValue)
                {
                    return iValue;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Checks if a string is a numeric (int) value.
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static bool IsNumeric(string stringToCheck)
        {
            int result;
            bool isNumeric = true;
            if (stringToCheck == null)
            {
                stringToCheck = "";
            }
            try
            {
                result = int.Parse(stringToCheck);
            }
            catch
            {
                isNumeric = false;
            }
            return isNumeric;
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Check if a number is a multiple of another.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns>True if x is divisible by n and false if not.</returns>
        /// <example>6 is a multiple of 3, but 7 is not.</example>
        /// '-----------------------------------------------------------------------------------------
        public static bool IsDivisble(int x, int n)
        {
            return (x % n) == 0;
        }

        //Extension Methods
        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Get all of the even numbers out of a collection of numbers.
        /// </summary>
        /// <param name="Values"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static IEnumerable<int> WhereEven(this IEnumerable<int> Values)
        {
            foreach (int i in Values)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }

        /// '-----------------------------------------------------------------------------------------
        /// <summary>
        /// Get all of the odd numbers out of a collection of numbers.
        /// </summary>
        /// <param name="Values"></param>
        /// <returns></returns>
        /// '-----------------------------------------------------------------------------------------
        public static IEnumerable<int> WhereOdd(this IEnumerable<int> Values)
        {
            foreach (int i in Values)
            {
                if (i % 2 > 0)
                {
                    yield return i;
                }
            }
        }
    }
}
