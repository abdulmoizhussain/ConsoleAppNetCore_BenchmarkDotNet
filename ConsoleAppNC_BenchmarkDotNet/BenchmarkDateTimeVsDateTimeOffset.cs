using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace ConsoleAppNC
{
  [MemoryDiagnoser]
  public class BenchmarkDateTimeVsDateTimeOffset
  {
    [Benchmark(Baseline = true)]
    public void Date_Time()
    {
      var list = new List<DateTime>()
      {
        { DateTime.UtcNow },
        //{ new DateTime() },
        //{ new DateTime() },
        //{ new DateTime() },
        //{ new DateTime() },
        //{ new DateTime() },
        //{ new DateTime() },
      };
    }

    [Benchmark]
    public void Date_Time_Offset()
    {
      var list = new List<DateTimeOffset>()
      {
        { DateTimeOffset.UtcNow },
        //{ new DateTimeOffset() },
        //{ new DateTimeOffset() },
        //{ new DateTimeOffset() },
        //{ new DateTimeOffset() },
        //{ new DateTimeOffset() },
        //{ new DateTimeOffset() },
      };
    }
  }
}
