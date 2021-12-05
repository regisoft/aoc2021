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
    const int BITCOUNT = 5;  // for sample  use  5  else 12
    const string INPUTNAME = $"{nameof(D03)}_sample.txt"; // _sample.txt   OR  .txt 

    [TestMethod]
    public void P1()
    {
      var cnt = File.ReadLines(INPUTNAME).Count();
      Debug.WriteLine($"cnt: {cnt}");
      var rslt = new int[BITCOUNT]; // with sample.txt use  5
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
      Assert.AreEqual(198, epsilon * gamma); // for sample
    }

    [TestMethod]
    public void P2()
    {
      var oxygen = P2Calc(true);
      var scrubb = P2Calc(false);
      Debug.WriteLine($"oxygen = {oxygen}, scrubb = {scrubb}");
      Debug.WriteLine($" ====> {oxygen * scrubb}");
      Assert.AreEqual(23, oxygen); // "10111"
      Assert.AreEqual(10, scrubb); // "01010"
    }

    private static int P2Calc(bool isCnt1)
    {
      var data = File.ReadAllLines(INPUTNAME).AsEnumerable();
      var cntData = data.Count();
      var binPart = string.Empty;
      for (int i = 0; i < BITCOUNT; i++)
      {
        var cntMsb = data.Select(line => line[i]).Count(p => p == (isCnt1 ? '1' : '0'));
        if (cntMsb * 2 == cntData) binPart += (isCnt1 ? "1" : "0");
        else binPart += cntMsb > cntData / 2 ? "1" : "0";
        data = data.Where(l => l.StartsWith(binPart));
        cntData = data.Count();
        Debug.WriteLine($"filter step:{i}, cntMsb={cntMsb}, binPart={binPart}, cntData={cntData}");
        if (cntData == 1)
        {
          return Convert.ToInt32(data.First(), 2);
        }
      }

      return 0;
    }

    private IEnumerable<char> GetEnum(int pos)
    {
      return File.ReadLines(INPUTNAME).Select(line => line[pos]);
    }
  }
}