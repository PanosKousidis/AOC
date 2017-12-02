using System;
using System.Linq;
using Common;
using Common.Enum;
using Common.Helpers;

namespace DayLibrary
{
    public class AOC2016_Day01 : DayBase
    {
        private const string Input = @"R3, L2, L2, R4, L1, R2, R3, R4, L2, R4, L2, L5, L1, R5, R2, R2, L1, R4, R1, L5, L3, R4, R3, R1, L1, L5, L4, L2, R5, L3, L4, R3, R1, L3, R1, L3, R3, L4, R2, R5, L190, R2, L3, R47, R4, L3, R78, L1, R3, R190, R4, L3, R4, R2, R5, R3, R4, R3, L1, L4, R3, L4, R1, L4, L5, R3, L3, L4, R1, R2, L4, L3, R3, R3, L2, L5, R1, L4, L1, R5, L5, R1, R5, L4, R2, L2, R1, L5, L4, R4, R4, R3, R2, R3, L1, R4, R5, L2, L5, L4, L1, R4, L4, R4, L4, R1, R5, L1, R1, L5, R5, R1, R1, L3, L1, R4, L1, L4, L4, L3, R1, R4, R1, R1, R2, L5, L2, R4, L1, R3, L5, L2, R5, L4, R5, L5, R3, R4, L3, L3, L2, R2, L5, L5, R3, R4, R3, R4, R3, R1";
        protected override string InputPart1 { get; } = Input;
        protected override string InputPart2 { get; } = Input;
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
                person.Move(ParseSteps(direction));
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
                person.Move(ParseSteps(direction));
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
