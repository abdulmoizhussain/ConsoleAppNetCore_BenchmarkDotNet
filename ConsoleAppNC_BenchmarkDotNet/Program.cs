using BenchmarkDotNet.Running;

namespace ConsoleAppNC_BenchmarkDotNet
{
  class Program
  {
    static void Main(string[] args)
    {
      BenchmarkRunner.Run<Benchmark_Func_vs_Delegate>();
    }
  }
}
