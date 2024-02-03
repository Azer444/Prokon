using System;

namespace Manage.Helpers
{
    public class AzDateTime
    {
        public static DateTime Now
        {
            get
            {
                return TimeZoneInfo.ConvertTime(DateTime.UtcNow, tzi());
            }
        }

        public static TimeZoneInfo tzi()
        {
            TimeZoneInfo zi;
            try
            {
                zi = TimeZoneInfo.FindSystemTimeZoneById("Azerbaijan Standard Time");
            }
            catch (Exception)
            {
                zi = TimeZoneInfo.FindSystemTimeZoneById("Asia/Baku");
            }
            return zi;
        }
    }
}
