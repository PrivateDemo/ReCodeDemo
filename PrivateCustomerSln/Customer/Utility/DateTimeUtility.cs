using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Utility
{
    public static class DateTimeUtility
    {
        public static long CurrentTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }

        public static DateTime GetDateTimeFromTimeStamp(long stamp)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(stamp);
            return dt;
        }

        public static long GetTimeStampFromDateTime(DateTime dt)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0)); // 当地时区
            long timeStamp = (long)(dt - startTime).TotalMilliseconds; // 相差毫秒数
            return timeStamp;
        }
    }
}
