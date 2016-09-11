using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAsset.App.Domain.Common
{
    public static class DateTimeExtension
    {
        public static DateTime SetTime(this DateTime dt, int hour, int minute)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, hour, minute, 0);
        }

        public static bool EqualDay(this DateTime dt, DateTime otherdate)
        {
            return dt.Year.Equals(otherdate.Year) && dt.Month.Equals(otherdate.Month) && dt.Day.Equals(otherdate.Day);
        }
    }
}
