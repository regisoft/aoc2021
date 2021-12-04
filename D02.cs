using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Aoc2021
{
  [TestClass]
  public class D02
  {
    [TestMethod]
    public void P1()
    {
      var x = 0;
      var d = 0;

      foreach (var l in File.ReadAllLines($"{nameof(D02)}.txt"))
      {
        var prms = l.Split(' ');
        var val = int.Parse(prms[1]);
        switch (prms[0])
        {
          case "forward":
            x += val;
            break;
          case "up":
            d -= val;
            break;
          case "down":
            d += val;
            break;
        }
      }

      Console.WriteLine("x={0},d={1},s={2}", x, d, x * d);
    }

    [TestMethod]
    public void P2()
    {
      var a = 0;
      var x = 0;
      var d = 0;

      foreach (var line in File.ReadAllLines($"{nameof(D02)}.txt"))
      {
        var prms = line.Split(' ');
        var val = int.Parse(prms[1]);
        switch (prms[0])
        {
          case "forward":
            x += val;
            d += (a * val);
            break;
          case "up":
            a -= val;
            break;
          case "down":
            a += val;
            break;
        }
        // Console.WriteLine("x={0},d={1},a={2},     line={3}", x, d, a, line);
      }

      Console.WriteLine("x={0},d={1},a={2},s={3}", x, d, a, x * d);
    }
  }
}