using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DayLibrary
{
    public class AoC2017Day24 : DayBase
    {

        public override string Part1(string input)
        {
            return Part1(input, null);
        }
        public override string Part2(string input)
        {
            return Part2(input, null);
        }

        public override string Part1(string input, object args)
        {
            var bridges = input.Lines().ToList().Select(x => Bridge.Parse(x)).ToList();
            CreateBridges(new List<Bridge>(), bridges, 0);
            // return construction.Sum(x=> x.Pin[0] + x.Pin[1]).ToString();
            return null;
        }

        private List<List<Bridge>> CreateBridges(List<Bridge> currentBridges, List<Bridge> availableBridges, int currentNo)
        {
            var constructions = new List<List<Bridge>>();

            while (availableBridges.Count > 0 && availableBridges.Where(x => x.Pin.Contains(currentNo)).ToList().Count > 0)
            {
                var b = availableBridges.Where(x => x.Pin.Contains(currentNo)).ToList();

                foreach (var bridge in b)
                {

                    currentBridges.Add(bridge);
                    constructions.Add(currentBridges);
                    availableBridges.Remove(bridge);
                    constructions.AddRange(CreateBridges(currentBridges, availableBridges, bridge.Pin[0] == currentNo ? bridge.Pin[1] : bridge.Pin[0]));
                    availableBridges.Add(bridge);
                }
            }

            return constructions;
        }


        public override string Part2(string input, object args)
        {
            return null;
        }
    }

    public class Bridge
    {
        public int[] Pin { get; set; } = new int[2];
        public static Bridge Parse(string input)
        {
            return new Bridge()
            {
                Pin = input.Split('/').Select(int.Parse).ToArray()
            };
        }
        public override string ToString()
        {
            return Pin[0] + "/" + Pin[1];

        }
    }
}