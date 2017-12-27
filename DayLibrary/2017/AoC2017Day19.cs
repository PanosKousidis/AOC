using Common.Enum;
using Common.Extensions;
using Common.Helpers;
using System;
using System.Text;

namespace DayLibrary
{
    public class AoC2017Day19 : DayBase
    {

        public override string Part1(string input)
        {
            return Move(input).Item1;
        }
        public override string Part2(string input)
        {
            return Move(input).Item2;
        }

      private (string, string) Move(string input)
        {
            var steps = 0;
            var ret = new StringBuilder();
            var p = new MovingIn2D
            {
                Map = input.StringTo2ArrayOfArrays("").InvertArray().ToDictionaryOfPointObject(),
                Face = ECardinals.Down,
                InvalidDestinationString = " ",
                MoveAllowed = true,
                LocationX = input.Lines()[0].IndexOf('|'),
                LocationY = input.Lines().Length - 1,
                ThrowOnInvalidMove = true
            };

            while (p.MoveAllowed)
            {
                try
                {
                    p.MoveForward(1, false, false);
                    steps += 1;
                    if (char.IsLetter(p.MapValue[0])) ret.Append(p.MapValue);
                }
                catch (InvalidOperationException)
                {
                    if (p.MapValue == "+")
                    {
                        p.Face = (ECardinals)Enum.Parse(typeof(ECardinals), (((int)p.Face + 1) % 4).ToString());
                        try
                        {
                            p.Peek();
                        }
                        catch (InvalidOperationException)
                        {
                            p.Face = (ECardinals)Enum.Parse(typeof(ECardinals), (((int)p.Face + 2) % 4).ToString());
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return (ret.ToString(), (steps + 1).ToString());
        }

       
    }
}