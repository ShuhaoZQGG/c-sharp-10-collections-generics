using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
  internal class SequenceShuffle<T> : IEnumerator<T>
  {
    private T[] Data { get; }
    private Random RandomNumbers { get; } = new Random(Guid.NewGuid().GetHashCode());
    private int hashCode { get; } = new Guid().GetHashCode();
    private int Position { get; set; } = -1;

    public T Current => this.Data[this.Position];

    object IEnumerator.Current => this.Current;
    public SequenceShuffle(IEnumerable<T> sequence)
    {
      this.Data = sequence.ToArray();
    }


    public void Dispose() {}

    public bool MoveNext()
    {
      if (this.Position >= this.Data.Length - 1) return false;
      this.Position += 1;
      Console.WriteLine(this.hashCode);
      Console.WriteLine(this.RandomNumbers.Next(1, 1000));
      int pick = this.RandomNumbers.Next(this.Position, this.Data.Length);
      (Data[Position], Data[pick]) = (Data[pick], Data[Position]);
      return true;
    }

    public void Reset()
    {
      this.Position = -1;
    }
  }
}
