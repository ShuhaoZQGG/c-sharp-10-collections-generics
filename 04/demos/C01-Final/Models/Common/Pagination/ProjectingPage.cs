using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common.Pagination
{
  internal class ProjectingPage<T> : IPage<T>
  {
    private IReadOnlyList<T> Items { get; }
    public int Ordinal { get; }
    public int PageSize { get; }
    private int Offset => (this.Ordinal - 1) * this.PageSize;
    private int EndOffset => Math.Min(this.PageSize + this.Offset, this.Items.Count);
    public int Count => Math.Max(this.EndOffset - this.Offset, 0);
    public ProjectingPage(IReadOnlyList<T> items, int ordinal, int pageSize)
    {
      this.Items = items;
      this.Ordinal = ordinal;
      this.PageSize = pageSize;
    }

    public IEnumerator<T> GetEnumerator()
    {
      for (int i = this.Offset; i < this.EndOffset; i++)
      {
        yield return this.Items[i];
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
