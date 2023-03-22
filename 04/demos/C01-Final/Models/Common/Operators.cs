using Models.Common.Formatting;
using Models.Common.Pagination;
using Models.Common.Shuffling;

namespace Models.Common;

public static class Operators
{
    public static IEnumerable<T> Once<T>(this IEnumerable<T> sequence) =>
        new SinglePassSequence<T>(sequence);

    public static IEnumerable<string> ToGrid<T>(
        this IEnumerable<T> sequence, int width, int gap) =>
        new GridFormatter<T>(sequence).Format(width, gap);

    public static IEnumerator<T> BeginShuffle<T>(this IEnumerable<T> sequence) =>
        new SequenceShuffle<T>(sequence);

    public static IEnumerable<T> Iterate<T>(this IEnumerator<T> enumerator)
    {
        while (enumerator.MoveNext()) yield return enumerator.Current;
    }

    public static IPaginated<T> Paginate<T>
     (this IEnumerable<T> sequence, IComparer<T> comparer, int pageSize) =>
      new SortedListPaginator<T>(sequence, comparer, pageSize);

    public static IEnumerable<T> Replicate<T>
    (this IEnumerable<T> sequence, int numberOfReplicates, float accuracy)
    {
      IEnumerable<T> reuseableSequence = new List<T>(sequence);
      IEnumerable<T> result = reuseableSequence;
      for (int i = 0; i < numberOfReplicates; i++)
      {
        result = result.Concat(reuseableSequence);
      }

      return result;
    }
}