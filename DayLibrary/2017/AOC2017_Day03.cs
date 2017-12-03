using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using Common.Enum;
using Common.Helpers;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AOC2017_Day03 : DayBase
    {
        private readonly string _commonInput = Resources.AOC2017_Day03_Input;
        protected override string InputPart1 => _commonInput;
        protected override string InputPart2 => _commonInput;
        protected override void Part1(string input)
        {
            Console.WriteLine(Part1Result(int.Parse(input)));
        }

        protected static int Part1Result(int input)
        {
            var p = new MovingIn2D()
            {
                Face = ECardinals.Down,
                LocationX = 0,
                LocationY = 0,
            };
            var currentNo = 1;

            var reps = 0;
            while (currentNo != input)
            {
                for (var i = 0; i < 2; i++)
                {
                    p.Turn(ETurnOrders.Left);
                    var rep = 0;
                    while (rep <= reps)
                    {
                        p.MoveForward(1, true, true);
                        currentNo++;
                        if (input == currentNo) return p.DistanceFrom(0, 0);
                        rep++;
                    }
                }
                reps++;
            }
            return 0;
        }

       
        protected override void Part2(string input)
        {
            Console.WriteLine(Part2Result(int.Parse(input)));
        }

        protected int Part2Result(int input)
        {
            dic = new Dictionary<Point, int>();
            var p = new MovingIn2D()
            {
                Face = ECardinals.Down,
                LocationX = 0,
                LocationY = 0,
            };
            var currentNo = 1;
            dic.Add(new Point(0,0),1);
            var reps = 0;
            while (currentNo != input)
            {
                for (var i = 0; i < 2; i++)
                {
                    p.Turn(ETurnOrders.Left);
                    var rep = 0;
                    while (rep <= reps)
                    {
                        p.MoveForward(1, true, true);
                        currentNo = GetCurrentNo(new Point(p.LocationX, p.LocationY));
                        if (input < currentNo) return currentNo;
                        dic.Add(new Point(p.LocationX, p.LocationY), currentNo);
                        rep++;
                    }
                }
                reps++;
            }
            return currentNo;
        }

        private int GetCurrentNo(Point p)
        {
            var sum = 0;
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    if(dic.ContainsKey(new Point(p.X + i, p.Y + j)))
                        sum += dic[new Point(p.X + i, p.Y + j)];
                }
            }
            return sum;
        }

        private Dictionary<Point, int> dic;

    }

   
}
