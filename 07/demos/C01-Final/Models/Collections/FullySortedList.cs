namespace Models.Collections;

public class FullySortedList<T> : IOrderedList<T>
{
    public FullySortedList(IEnumerable<T> sequence, IComparer<T> comparer)
    {
        this.Items = new List<T>(sequence);
        this.Items.Sort(comparer);
        this.Items.TrimExcess();
    }

    private FullySortedList(List<T> items)
    {
        this.Items = items;
    }

    private List<T> Items { get; }
    public T this[int index] => this.Items[index];

    public int Count => this.Items.Count;

    public IEnumerator<T> GetEnumerator() => this.Items.GetEnumerator();

    public IOrderedList<T> GetRange(int index, int count) =>
        new FullySortedList<T>(this.Items.GetRange(
            index.InRange(0, this.Count, nameof(index)), 
            Math.Min(count, this.Count - index).NonNegative(nameof(count))));

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}

// generic type interface
public static class FullySortedList
{
  public static IOrderedList<T> ToFullySortedList<T>(this IEnumerable<T> sequence, IComparer<T> comparer)
  {
    return new FullySortedList<T>(sequence, comparer);
  }
  

  // further encapsulation
  public static IOrderedList<T> ToFullySortedList<T, TKey>
    (this IEnumerable<T> sequence, Func<T, TKey> keySelector) 
    where TKey : IComparable<TKey> =>
    // call the above method
    sequence.ToFullySortedList(Comparer(keySelector));

  private static IComparer<T> Comparer<T, TKey>
    (Func<T, TKey> keySelector)
    where TKey: IComparable<TKey> =>
    Comparer<T>.Create((a, b) => keySelector(a).CompareTo(keySelector(b)));
}