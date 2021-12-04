using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Aoc2021
{
  [TestClass]
  public class D03
  {
    [TestMethod]
    public void P1()
    {
      var cnt = GetEnum(0).Count();
      Debug.WriteLine($"cnt: {cnt}");
      var rslt = new int[12]; // with sample.txt use  5
      string? bin = null;
      for (var i = 0; i < rslt.Length; i++)
      {
        rslt[i] = GetEnum(i).Count(p => p == '1');
        Debug.Write(rslt[i]+",");
        bin += rslt[i] > cnt / 2 ? "1" : "0";
      }

      int gamma = Convert.ToInt32(bin, 2);      
      Debug.WriteLine($"gamma: {bin} =>{gamma}");

      bin = bin?.Replace('0', 'x').Replace('1', '0').Replace('x', '1');
      int epsilon = Convert.ToInt32(bin, 2);
      Debug.WriteLine($"epsilon: {bin} =>{epsilon}");
      Debug.WriteLine($" ====> {epsilon * gamma}");
    }

    [TestMethod]
    public void P2()
    {
    }
    private IEnumerable<char> GetEnum(int pos)
    {
      return File.ReadLines($"{nameof(D03)}.txt").Select(line => line[pos]);
    }
  }
}