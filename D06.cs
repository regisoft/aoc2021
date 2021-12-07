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
    const string INPUTNAME = $"{nameof(D06)}.txt"; // _sample.txt   OR  .txt 

    [TestMethod]
    public void P1()
    {
      int cnt = Calc(80);
      Assert.AreEqual(5934, cnt);  // 26 for 18 days
    }

    [TestMethod]
    public void P2()
    {
      int cnt = Calc(256);
      Assert.AreEqual(5934, cnt);  // 26 for 18 days
    }

    private static int Calc(int dayCnt)
    {
      var data = File.ReadAllText(INPUTNAME).Split(',').Select(n => new Fish(Convert.ToInt32(n))).ToList();
      for (int day = 1; day <= dayCnt; day++)
      {
        // Each day, a 0 becomes a 6 and adds a new 8 to the end of the list,
        // while each other number decreases by 1 if it was present at the start of the day.
        int cntNewChilds = 0;
        data.ForEach(fish =>
        {
          if (fish.DaysBeforeBirth == 0)
          {
            cntNewChilds++;
            fish.DaysBeforeBirth = 6;
          }
          else fish.DaysBeforeBirth--;
        });

        for (int i = 0; i < cntNewChilds; i++)
        {
          data.Add(new Fish(8));
        }

        // dump
        // data.ForEach(fish => Console.Write(fish.DaysBeforeBirth));
        // Console.WriteLine();
      }

      return data.Count;
    }

    private class Fish
    {
      public Fish(int start)
      {
        DaysBeforeBirth = start;
      }

      public int DaysBeforeBirth { get; set; }
    }
  }
}