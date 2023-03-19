using BenchmarkDotNet.Attributes;

namespace ConsoleDemo;

public class CurrencyUseBenchmark
{
    // [Params(1_000_000)] public int CollectionSize { get; set; }
    // [Params(1, 3, 10)] public int PassesCount { get; set; }

    // private int GetLengthsSum(Currency[] currencies)
    // {
    //     int sum = 0;
    //     for (int pass = 0; pass < this.PassesCount; pass++)
    //     {
    //         for (int i = 0; i < currencies.Length; i++)
    //             sum += currencies[i].Code.Length;
    //     }
    //     return sum;
    // }

    // private CurrencyCreationBenchmark Factory =>
    //     new() { CollectionSize = this.CollectionSize };

    // [Benchmark(Baseline = true)]
    // public int PlainUse() =>
    //     this.GetLengthsSum(this.Factory.PlainCreate());

    // [Benchmark]
    // public int CachedUse() =>
    //     this.GetLengthsSum(this.Factory.CachedCreate());
}