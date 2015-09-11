using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace xml_matchs
{
    class DateTools
    {
        public IEnumerable<DateTime> GetListOfSaturdays(DateTime startDate, DateTime endDate)
        { 
           var days = from d in Enumerable.Range(0, (endDate - startDate).Days + 1)
                      let currentDate = startDate.AddDays(d)
                      where currentDate.DayOfWeek == DayOfWeek.Saturday
                      select currentDate;
           return days;
        }

        internal string GetFileName(DateTime dt)
        {
            return string.Format("m{0:yyyy_MM_dd}.xml", dt);
        }

        internal string GetDays(DateTime dt)
        {
            string saturday;
            int sunday;
            if (dt.Date.Month != dt.Date.AddDays(1).Month)
            {
                saturday = string.Format("{0} {1}",dt.Date.Day,CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[dt.Date.Month - 1]);
                sunday = dt.Date.AddDays(1).Day;
            }
            else
            {
                saturday = dt.Date.Day.ToString();
                sunday = dt.Date.AddDays(1).Day;
            }
            return string.Format("Samedi {0} et Dimanche {1} {2}", saturday, sunday, CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[dt.Date.AddDays(1).Month - 1]);
        }
    }
}
