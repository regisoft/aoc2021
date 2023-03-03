using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Aoc2021
{
  [TestClass]
  public class D07
  {
    const string INPUTNAME = $"{nameof(D07)}_sample.txt"; // _sample.txt   OR  .txt 

    [TestMethod]
    public void P1()
    {
      var input = File.ReadAllText(INPUTNAME).Split(',').Select(n => Convert.ToInt32(n)).ToList();
      var data = new int[input.Count];
      input.ForEach(n => 
      {
        for (int i = n-5; i < n+5; i++)
        {
          var action = 1;
          var w = 1;
          if (i == n)
          {
            action = -1;
          }
          if (i>=0 && i<data.Count())
          data[i] = w + action;
          w++;
        }
      });

      //--- dump
      for (int i = 0; i < data.Length; i++)
      {
        Console.Write(i + ",");
      }

      for (int i = 0; i < data.Length; i++)
      {
        Console.Write(data[i] + ",");
      }


    }

    [TestMethod]
    public void P2()
    {

    }
  }
}