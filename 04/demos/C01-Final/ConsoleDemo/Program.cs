using System.Diagnostics;
try
{
  IPaginated<Worker> pages = Workers.TestData.Replicate(50_000, .05F).Paginate(Worker.RateComparer, 5);

  Stopwatch pageTimer = Stopwatch.StartNew();
  IEnumerator<IPage<Worker>> pagesEnumerator = pages.GetEnumerator();
  while (pagesEnumerator.MoveNext())
  {
    IPage<Worker> page = pagesEnumerator.Current;
    PayRate rate = page.AveragePayRate();
    Console.WriteLine($"Page #{page.Ordinal}: {page.Count} x {rate} [{pageTimer.Elapsed}]");
    pageTimer.Restart();
    break; // if there is an issue on the first page, page pagination only stops until all pages finish processing
  }
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}