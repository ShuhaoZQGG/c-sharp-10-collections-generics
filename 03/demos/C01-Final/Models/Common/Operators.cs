namespace Models.Common;
/// <summary>
/// The name Operators comes from LINQ (and functional programming)
/// These extension methods apply to IEnumerable<T> like operators
/// </summary>
public static class Operators
{
  public static IEnumerable<T> Once<T>(this IEnumerable<T> sequence) =>
      new SinglePassSequence<T>(sequence);

  public static IEnumerable<string> ToGrid<T>(this IEnumerable<T> sequence, int width, int gap)
  {
    return new GridFormatter<T>(sequence).Format(width, gap);
  }
}