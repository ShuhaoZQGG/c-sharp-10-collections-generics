namespace Models.Common;

internal class SequenceShuffle<T>
{
    public SequenceShuffle(IEnumerable<T> sequence)
    {

    }

    public IEnumerable<T> GetShuffledContent() => Enumerable.Empty<T>();
}