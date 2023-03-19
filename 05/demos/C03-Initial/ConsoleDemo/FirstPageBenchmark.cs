using BenchmarkDotNet.Attributes;

namespace ConsoleDemo;

public class FirstPageBenchmark
{
    [Params(10_000, 100_000, Priority = 0)]
    public int SequenceLength { get; set; }

    [Params(100, 1_000)]
    public int PageSize { get; set; }

    [Benchmark(Baseline = true)] public List<Worker> Populate() =>
        new List<Worker>(Workers.GetWorkers(this.SequenceLength));

    [Benchmark] public List<Worker> FullySorted()
    {
        List<Worker> list = this.Populate();
        list.Sort(Worker.RateComparer);
        if (list.Count > this.PageSize)
        {
            list.RemoveRange(this.PageSize, list.Count - this.PageSize);
        }
        return list;
    }
}