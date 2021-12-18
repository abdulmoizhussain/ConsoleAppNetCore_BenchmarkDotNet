using BenchmarkDotNet.Running;

namespace ConsoleAppNC_BenchmarkDotNet
{
  class Program
  {
    static void Main(string[] args)
    {
      BenchmarkRunner.Run<Benchmark2>();
      //new Benchmark2().Check();
      //Console.WriteLine(DateTime.Parse("2021-12-18T06:07:55.602Z"));
      //Console.WriteLine(DateTimeOffset.Parse("2021-12-18T06:07:55.602Z"));
    }
  }
}
