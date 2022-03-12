using System;

namespace ConsoleAppNC
{
  public static class DateTimeExtensions
  {
    public static readonly long TicksOffset = TimeZoneInfo.Local.GetUtcOffset(new DateTime()).Ticks;
    public static readonly long Ticks1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

    /// <summary>
    /// Will work correctly only for the dates which are greater than 1970-01-01T00:00:00.000Z
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static long GetMillisSince1970(this DateTime dateTime)
    {
      return (dateTime.Ticks - Ticks1970 - TicksOffset) / TimeSpan.TicksPerMillisecond;
    }
  }
}
