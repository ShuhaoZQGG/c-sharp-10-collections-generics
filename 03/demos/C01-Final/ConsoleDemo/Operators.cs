using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
  internal static class Operators
  {
    public static void WriteLines(this IEnumerable<string> lines)
    {
      foreach (string line in lines)
      {
        Console.WriteLine(line);
      }
    }
  }
}
