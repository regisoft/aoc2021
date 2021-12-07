using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Aoc2021
{
  [TestClass]
  public class D04
  {
    const string INPUTNAME = $"{nameof(D04)}_sample.txt"; // _sample.txt   OR  .txt 

    [TestMethod]
    public void P1()
    {
      var rslt = Calc(true);
      Debug.WriteLine($"=============> {rslt}");
      Assert.AreEqual(4512, rslt); // _sample.txt 
    }

    [TestMethod]
    public void P2()
    {
      var rslt = Calc(false);
      Debug.WriteLine($"=============> {rslt}");
      Assert.AreEqual(1924, rslt); // _sample.txt 
    }

    public int Calc(bool returnWhenFirstHit)
    {
      var input = File.ReadLines(INPUTNAME);
      var bingos = input.First().Split(',').Select(n => n == "0" ? 1000 : Convert.ToInt32(n));  // bingo == 0 is a problem when mark with *-1
      var boards = GetInputBoards(input);
      var boardWins = new bool[boards.Count];
      foreach (var bingo in bingos)
      {
        for (int b = 0; b < boardWins.Length; b++)
        {
          var board = boards[b];
          for (int x = 0; x < 5; x++)
          {
            for (int y = 0; y < 5; y++)
            {
              if (board[x, y] == bingo)
              {
                board[x, y] *= -1;
                if (CheckBingo(board, true) || CheckBingo(board, false))
                {
                  var sumUnmarked = GetUnmarkedSum(board);
                  var hit = sumUnmarked * bingo;
                  if (returnWhenFirstHit)
                    return hit;

                  boardWins[b] = true;
                  if (!boardWins.Any(x => !x))
                    return hit;
                }
              }
            }
          }
        }
      }

      return 0;
    }

    private bool CheckBingo(int[,] board, bool isHorizontal)
    {
      for (int x = 0; x < 5; x++)
      {
        var hitCnt = 0;
        for (int y = 0; y < 5; y++)
        {
          if (board[isHorizontal ? x : y, isHorizontal ? y : x] < 0)
            hitCnt++;
        }

        if (hitCnt == 5)
          return true;
      }

      return false;
    }

    private int GetUnmarkedSum(int[,] board)
    {
      var sum = 0;
      for (int x = 0; x < 5; x++)
      {
        for (int y = 0; y < 5; y++)
        {
          if (board[x, y] > 0 && board[x, y] != 1000)  // bingo == 0 is a problem
            sum += board[x, y];
        }
      }

      return sum;
    }

    private List<int[,]> GetInputBoards(IEnumerable<string> lines)
    {
      var lineNr = -1;
      var boards = new List<int[,]>();
      int[,]? currentBoard = null;

      foreach (var line in File.ReadLines(INPUTNAME))
      {
        if (lineNr == -1)
        {
          lineNr++;
          continue;
        }

        if (line == string.Empty)
        {
          currentBoard = new int[5, 5];
          boards.Add(currentBoard);
          lineNr = 0;
          continue;
        }

        var colNr = 0;
        foreach (var num in line.Trim().Replace("  ", " ").Split(" "))
        {
          currentBoard[lineNr, colNr] = num == "0" ? 1000 : Convert.ToInt32(num);  // bingo == 0 is a problem
          colNr++;
        }

        lineNr++;
      }

      return boards;
    }
  }
}