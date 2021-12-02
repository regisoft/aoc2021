using System;
using System.IO;

var a = 0;
var x = 0;
var d = 0;

foreach (var line in File.ReadAllLines("in.txt"))
{
  var prms = line.Split(' ');
  var val = int.Parse(prms[1]);
  switch (prms[0])
  {
    case "forward":
      x += val;
      d = d + (a * val);
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