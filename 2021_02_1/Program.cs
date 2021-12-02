using System;
using System.IO;

var x = 0;
var d = 0;

foreach (var l in File.ReadAllLines("in.txt"))
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