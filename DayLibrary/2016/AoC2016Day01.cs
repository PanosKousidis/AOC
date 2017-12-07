using System;
using System.Linq;
using Common.Enum;
using Common.Helpers;

namespace DayLibrary
{
    public class AoC2016Day01 : DayBase
    {
        private bool _bDone;

        public override string Part1(string input)
        {
            var person = new MovingIn2D();

            foreach (var direction in input.Split(','))
            {
                person.Turn(ParseTurnOrders(direction));
                person.MoveForward(ParseSteps(direction), false, true);
            }
            return person.DistanceFrom(0,0).ToString();
        }

        public override string Part2(string input)
        {
            _bDone = false;
            var person = new MovingIn2D();
            person.AlreadyVisited += OnAlreadyVisited;

            foreach (var direction in input.Split(','))
            {
                person.Turn(ParseTurnOrders(direction));
                person.MoveForward(ParseSteps(direction), true, true);
                if (_bDone) break;
            }
            return person.DistanceFrom(0,0).ToString();
        }

        private void OnAlreadyVisited(MovingIn2D sender, int x, int y)
        {
            _bDone = true;
            sender.MoveAllowed = false;
        }

        private static ETurnOrders ParseTurnOrders(string s)
        {
            var i = s.Count(c => c == 'R') - s.Count(c => c == 'L');
            if (i >= 0) i = i % 4;
            else i = 4 + i % -4;
            switch (i)
            {
                case 0:
                    return ETurnOrders.NoTurn;
                case 1:
                    return ETurnOrders.Right;
                case 2:
                    return ETurnOrders.Back;
                case 3:
                    return ETurnOrders.Left;
                default:
                    throw new Exception("Unable to find turn");
            }
        }
        private static int ParseSteps(string s)
        {
            s = s.Replace("R", "").Replace("L", "");
            return int.Parse(s);
        }
    }
}
