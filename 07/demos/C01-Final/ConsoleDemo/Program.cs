try
{
  //IEnumerable<Worker> rawData = Workers.GetWorkers(40);

  //IOrderedList<Employee> sorted = new FullySortedList<Worker>(rawData, Worker.RateComparer);
  //IOrderedList<Employee> sorted = rawData.ToFullySortedList<Worker>(Worker.RateComparer);

  // the best generic method is the one which requires type parameters

  /*
  var rawData = Workers.GetWorkers(40);
  var sorted = rawData.ToFullySortedList(Worker.RateComparer); // extension methods allow call chaining
  sorted.ToGrid(120, 2).WriteLines();
  */

  Workers.GetWorkers(40)
         .ToFullySortedList(worker => worker.HourlyRate)
         .ToGrid(120, 2)
         .WriteLines();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}