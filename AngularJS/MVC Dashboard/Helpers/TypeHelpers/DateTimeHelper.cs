using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Dashboard.Helpers.TypeHelpers
{
    public static class DateTimeHelper
    {
        public static int GetMonthsBetween(DateTime from, DateTime to)
        {
            if (from > to) return GetMonthsBetween(to, from);

            var monthDiff = Math.Abs((to.Year * 12 + (to.Month - 1)) - (from.Year * 12 + (from.Month - 1)));

            if (from.AddMonths(monthDiff) > to || to.Day < from.Day)
            {
                return monthDiff - 1;
            }
            else
            {
                return monthDiff;
            }
        }

        public static bool IsTimePlusOneHour(DateTime? orignalDateTime, DateTime? dateTimeToCheck)
        {
            bool result = false;

            if (orignalDateTime.HasValue && dateTimeToCheck.HasValue)
            {
                if (dateTimeToCheck.Value.Date == orignalDateTime.Value.Date)
                {
                    if (dateTimeToCheck.Value.Hour == orignalDateTime.Value.Hour + 1)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public static DateTime? AvoidHourErrorDate(DateTime? date, DateTime? orignaldate)
        {
            try
            {
                if (date.HasValue && orignaldate.HasValue)
                {
                    var hours = ((DateTime)date - (DateTime)orignaldate).TotalHours;
                    if (hours == -1 || hours == 1)
                        return orignaldate;
                    else
                        return date;
                }
                else
                    return date;
            }
            catch
            {
                return date;
            }
        }

        public static int GetAge(DateTime reference, DateTime birthday)
        {
            int age = reference.Year - birthday.Year;
            if (reference < birthday.AddYears(age))
            {
                age--;
            }

            return age;
        }

        public static bool IsWeekEndDay(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime GetNextWorkingDay(DateTime date)
        {
            do
            {
                date = date.AddDays(1);
            } while(IsWeekEndDay(date));

            return date;
        }
    }
}
