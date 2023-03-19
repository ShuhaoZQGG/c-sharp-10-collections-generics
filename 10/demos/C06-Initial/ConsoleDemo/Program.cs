using System.Diagnostics;

try
{
    Stopwatch timer = Stopwatch.StartNew();

    Workers.GetWorkers(1_000_000)
        .ToFullySortedList(Worker.RateComparer);
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}
