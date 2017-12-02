using System;
using System.Linq;
using Common.Enum;
using Common.Helpers;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AOC2016_Day01 : DayBase
    {
        private readonly string _input = Resources.AOC2016_Day01_Input;
        protected override string InputPart1 => _input;
        protected override string InputPart2 => _input;
        private bool _bDone;
        protected override void Part1(string input)
        {
            var p = Part1Result(input);
            Console.WriteLine(p.LocationX + "," + p.LocationY);
            Console.WriteLine(p.DistanceFrom(0, 0));
        }

        protected MovingPersonIn2D Part1Result(string input)
        {
            var person = new MovingPersonIn2D();

            foreach (var direction in input.Split(','))
            {
                person.Turn(ParseTurnOrders(direction));
                person.MoveForward(ParseSteps(direction));
            }
            return person;
        }

        protected override void Part2(string input)
        {
            var p = Part2Result(input);
            Console.WriteLine(p.LocationX + "," + p.LocationY);
            Console.WriteLine(p.DistanceFrom(0, 0));
        }
        protected MovingPersonIn2D Part2Result(string input)
        {
            var person = new MovingPersonIn2D();
            person.AlreadyVisited += OnAlreadyVisited;

            foreach (var direction in input.Split(','))
            {
                person.Turn(ParseTurnOrders(direction));
                person.MoveForward(ParseSteps(direction));
                if (_bDone) break;
            }
            return person;
        }

        private void OnAlreadyVisited(MovingPersonIn2D sender, int x, int y)
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
