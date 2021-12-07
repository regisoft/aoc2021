using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Aoc2021
{
  [TestClass]
  public class D06
  {
    const string INPUTNAME = $"{nameof(D06)}_sample.txt"; // _sample.txt   OR  .txt 

    [TestMethod]
    public void P1()
    {
      var cnt = Calc(80);
      Assert.AreEqual(5934, cnt);  // 26 for 18 days
    }

    [TestMethod]
    public void P2()
    {
      var cnt = Calc(256);
      Assert.AreEqual(5934, cnt);  // 26 for 18 days
    }

    private static long Calc(int dayCnt)
    {
      var input = File.ReadAllText(INPUTNAME).Split(',').Select(n => Convert.ToByte(n)).ToList();

      //2147483591  max size of byte array is 2GB since it uses an int for indexing.
      //26984457539 already the sample is bigger 

      var fishes = new byte[2147483591];

      long last = input.Count-1;
      for (int i = 0; i < input.Count; i++)
      {
        fishes[i] = input[i];
      }

      for (int day = 1; day <= dayCnt; day++)
      {
        // Each day, a 0 becomes a 6 and adds a new 8 to the end of the list,
        // while each other number decreases by 1 if it was present at the start of the day.
        int cntNewChilds = 0;
        for (long fishIdx = 0; fishIdx <= last; fishIdx++)
        { 
          if (fishes[fishIdx] == 0)
          {
            cntNewChilds++;
            fishes[fishIdx] = 6;
          }
          else fishes[fishIdx]--;
        };

        for (int i = 0; i < cntNewChilds; i++)
        {
          last++;
          fishes[last] = 8;
        }

        //--- dump -->>
        /*
        for (long fishIdx = 0; fishIdx <= last; fishIdx++)
        {
          Console.Write(fishes[fishIdx] + ",");
        }

        Console.WriteLine();
        */
        //--- dump --<<
      }

      return last + 1;
    }

    private class Fish
    {
      public Fish(byte start)
      {
        DaysBeforeBirth = start;
      }

      public byte DaysBeforeBirth { get; set; }
    }
  }
}