using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVC_Dashboard.Helpers.TypeHelpers
{
    public static class StringsHelper
    {
        public static string ToIncludeSpace(this string text)
        {
            if (text == null)
                return "";
            else
                return Regex.Replace(text, "[AI](?![A-Z]{2,})[a-z]*|[A-Z][a-z]+|[A-Z]{2,}(?=[A-Z]|$)", " $0").Trim();
        }

        public static string ToTitleCase(this string str)
        {
            string rText = "";

            if (str == null)
                return "";

            try
            {
                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo TextInfo = cultureInfo.TextInfo;
                rText = TextInfo.ToTitleCase(str);
            }
            catch
            {
                rText = str;
            }
            return rText;
        }
    }
}
