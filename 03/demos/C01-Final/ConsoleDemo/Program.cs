try
{
  Workers.TestData.ToGrid(60, 2).WriteLines();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}
