using BenchmarkDotNet.Attributes;

namespace ConsoleAppNC_BenchmarkDotNet
{
  public class Benchmark1
  {
    private readonly object Object = "my name";
    public Benchmark1()
    {
    }

    [Benchmark]
    public string SimpleCast()
    {
      return (string)Object;
    }

    [Benchmark]
    public string CastAs()
    {
      return Object as string;
    }
  }
}
