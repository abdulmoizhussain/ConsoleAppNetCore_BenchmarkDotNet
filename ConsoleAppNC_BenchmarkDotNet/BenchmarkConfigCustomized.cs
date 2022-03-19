using BenchmarkDotNet.Configs;

namespace ConsoleAppNC_BenchmarkDotNet
{
  class BenchmarkConfigCustomized : ManualConfig
  {
    public BenchmarkConfigCustomized()
    {
      var ratioStyle = BenchmarkDotNet.Columns.RatioStyle.Percentage;

      SummaryStyle =
        BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(ratioStyle);
    }
  }
}
