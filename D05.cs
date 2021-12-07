using Aoc2021.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
      var rects = GetInput();
      var rslt = Calc(rects, false);
      Console.WriteLine($"=============> {rslt}");
      Assert.AreEqual(5, rslt);
    }

    [TestMethod]
    public void P2()
    {
      var rects = GetInput();
      var rslt = Calc(rects, true);
      Console.WriteLine($"=============> {rslt}");
      Assert.AreEqual(12, rslt);
    }

    private static int Calc(IEnumerable<Rectangle> rects, bool withDiagonal)
    {
      var canvas = new int[10, 10];  // for example 10,10 is enough else 1000

      // width/height are raped .. as x2, y2

      foreach (var r in rects)
      {
        if (r.X == r.Width)
        {
          for (int y = r.Y; y <= r.Height; y++)
          {
            canvas[r.X, y]++;
          }
        }
        else if (r.Y == r.Height)
        {
          for (int x = r.X; x <= r.Width; x++)
          {
            canvas[x, r.Y]++;
          }
        }
        else if (withDiagonal && r.Y < r.Height)
        {
          var x = r.X;
          for (int y = r.Y; y <= r.Height; y++)
          {
            canvas[x++, y]++;
          }
        }
        else if (withDiagonal && r.Y > r.Height)
        {
          var x = r.X;
          for (int y = r.Y; y >= r.Height; y--)
          {
            canvas[x++, y]++;
          }
        }
      }

      // canvas.Dump(true);
      return canvas.Cast<int>().Where(n => n > 1).Count();
    }

    private static IEnumerable<Rectangle> GetInput()
    {
      return File.ReadLines(INPUTNAME).Select(x =>
      {
        var nums = x.Replace(" -> ", ",").Split(',');
        var rect = new Rectangle(Convert.ToInt32(nums[0]), Convert.ToInt32(nums[1]), Convert.ToInt32(nums[2]), Convert.ToInt32(nums[3]));
        if (rect.X == rect.Width && rect.Y > rect.Height)
        {
          // ensure X will y1 < y2 when horizontal
          rect = new Rectangle(rect.Width, rect.Height, rect.X, rect.Y);
        }
        else if (rect.Y == rect.Height && rect.X > rect.Width)
        {
          // ensure X will x1 < x2 when vertical
          rect = new Rectangle(rect.Width, rect.Height, rect.X, rect.Y);
        }
        else if (rect.X > rect.Width)
        {
          // ensure X will always go from left to right when diagonal
          rect = new Rectangle(rect.Width, rect.Height, rect.X, rect.Y);
        }

        return rect;
      });
    }
  }
}