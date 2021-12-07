using System;

namespace Aoc2021.Helper
{
  internal static class Helper
  {
    public static void Dump(this int[,] matrix, bool isZeroPoint)
    {
      //Debug.Write(System.Text.Json.JsonSerializer.Serialize(boards)); ..it can't handle matrix

      for (int y = 0; y < matrix.GetLongLength(1); y++)
      {
        for (int x = 0; x < matrix.GetLongLength(0); x++)
        {
          var val = matrix[x, y];
          Console.Write("{0} ", val == 0 ? '.' : val.ToString());
        }
        Console.WriteLine();
      }
    }
  }
}