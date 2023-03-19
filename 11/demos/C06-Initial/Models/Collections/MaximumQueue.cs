namespace Models.Collections;

public class MaximumQueue<T> : IEnumerable<T>
{
    public MaximumQueue(IComparer<T> comparer)
    {
        this.Comparer = comparer;
    }

    private IComparer<T> Comparer { get; }

    public T Maximum => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public void Enqueue(T item) => throw new NotImplementedException();

    public T Dequeue() => throw new NotImplementedException();

    public T Peek() => throw new NotImplementedException();

    public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}