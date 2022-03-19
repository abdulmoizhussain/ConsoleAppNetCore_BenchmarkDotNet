using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using System;
using System.Threading.Tasks;

namespace ConsoleAppNC_BenchmarkDotNet
{
  [MemoryDiagnoser]
  [Config(typeof(BenchmarkConfigCustomized))]
  [RankColumn(NumeralSystem.Arabic)]
  [Orderer(SummaryOrderPolicy.FastestToSlowest)]
  public class Benchmark_Func_vs_Delegate
  {
    private delegate Task SomeDel(int num);
    private readonly Func<int, Task> function1 = SomeDelMethod;
    private readonly SomeDel delegate1 = new(SomeDelMethod);
    private static Task SomeDelMethod(int num) => Task.CompletedTask;

    [Benchmark(Baseline = true)]
    public void Delegate() => delegate1(1);

    [Benchmark]
    public void Function() => function1(1);

    [Benchmark]
    public void Delegate_Invoke() => delegate1.Invoke(1);

    [Benchmark]
    public void Function_Invoke() => function1.Invoke(1);
  }
}
