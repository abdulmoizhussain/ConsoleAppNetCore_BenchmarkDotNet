using BenchmarkDotNet.Configs;

namespace ConsoleAppNC_BenchmarkDotNet
{
  class BenchmarkConfig : ManualConfig
  {
    public BenchmarkConfig()
    {
      var ratioStyle = BenchmarkDotNet.Columns.RatioStyle.Percentage;

      SummaryStyle =
        BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(ratioStyle);
    }
  }
}
