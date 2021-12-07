using Aoc2021.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Aoc2021
{
  [TestClass]
  public class D05
  {
    const string INPUTNAME = $"{nameof(D05)}_sample.txt"; // _sample.txt   OR  .txt 

    [TestMethod]
    public void P1()
    {
      var rects = File.ReadLines(INPUTNAME).Select(x =>
        {
          var nums = x.Replace(" -> ", ",").Split(',');
          var x1 = Convert.ToInt32(nums[0]);
          var y1 = Convert.ToInt32(nums[1]);
          var x2 = Convert.ToInt32(nums[2]);
          var y2 = Convert.ToInt32(nums[3]);
          return new Rectangle(x1, y1, x2, y2);
        });
      // Assert.AreEqual(10, rects.Count());

      var canvas = new int[1000, 1000];  // for example 10,10 is enough

      foreach (var r in rects)
      {
        if (r.X == r.Width)
        {
          var y1 = r.Y >= r.Height ? r.Height : r.Y;
          var y2 = r.Y >= r.Height ? r.Y : r.Height;
          for (int y = y1; y <= y2; y++)
          {
            canvas[r.X, y]++;
          }
        }

        if (r.Y == r.Height)
        {
          var x1 = r.X >= r.Width ? r.Width : r.X;
          var x2 = r.X >= r.Width ? r.X : r.Width;
          for (int x = x1; x <= x2; x++)
          {
            canvas[x, r.Y]++;
          }
        }
      }

      // canvas.Dump(true);
      var rslt = canvas.Cast<int>().Where(n => n > 1).Count();
      Console.WriteLine($"=============> {rslt}");
      Assert.AreEqual(5, rslt);
    }

    [TestMethod]
    public void P2()
    {

    }
  }
}