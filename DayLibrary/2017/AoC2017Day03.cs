using System.Collections.Generic;
using System.Drawing;
using Common.Enum;
using Common.Helpers;

namespace DayLibrary
{
    public class AoC2017Day03 : DayBase
    {

        public override string Part1(string input, object args)
        {
            return Part1Result(int.Parse(input)).ToString();
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


        public override string Part2(string input, object args)
        {
            return Part2Result(int.Parse(input)).ToString();
        }

        protected int Part2Result(int input)
        {
            _dic = new Dictionary<Point, int>();
            var p = new MovingIn2D()
            {
                Face = ECardinals.Down,
                LocationX = 0,
                LocationY = 0,
            };
            var currentNo = 1;
            _dic.Add(new Point(0,0),1);
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
                        _dic.Add(new Point(p.LocationX, p.LocationY), currentNo);
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
                    if(_dic.ContainsKey(new Point(p.X + i, p.Y + j)))
                        sum += _dic[new Point(p.X + i, p.Y + j)];
                }
            }
            return sum;
        }

        private Dictionary<Point, int> _dic;

    }

   
}
