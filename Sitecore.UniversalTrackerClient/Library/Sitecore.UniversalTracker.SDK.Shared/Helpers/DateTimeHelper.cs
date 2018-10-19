using System;
namespace Sitecore.UniversalTrackerClient.Helpers
{
    public static class DateTimeHelper
    {
        public static long ConvertToUnixTime(DateTime dateTime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)(dateTime - sTime).TotalSeconds;
        }
    }
}
