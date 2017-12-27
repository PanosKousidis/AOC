using Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DayLibrary
{
    public class AoC2017Day24 : DayBase
    {
        public override string Part1(string input, object args)
        {
            var availableBridges = input.Lines().Select(BridgeComponent.Parse).ToList();
            var bridgeCombinations = GetBridgeCombinations(new List<BridgeComponent>(), 0, availableBridges);
            return bridgeCombinations.Max(x => x.Strength).ToString();
        }

        public override string Part2(string input, object args)
        {
            var availableBridges = input.Lines().Select(BridgeComponent.Parse).ToList();
            var bridgeCombinations = GetBridgeCombinations(new List<BridgeComponent>(), 0, availableBridges);
            var maxBridges = bridgeCombinations.Max(x => x.Bridges.Count);
            var resBridges = bridgeCombinations.Where(x => x.Bridges.Count == maxBridges);
            return resBridges.Max(x => x.Strength).ToString();
        }
        public List<BridgeStructure> GetBridgeCombinations(List<BridgeComponent> usedBridges, int currentPinValue, List<BridgeComponent> availableBridges)
        {
            var possibleBridges = new List<BridgeStructure>();
            var nextBridges = availableBridges.Where(x => x.Pins.Contains(currentPinValue)).ToList();
            foreach(var next in nextBridges)
            {
                var newUsedBridges = usedBridges.Select(x => x).ToList();
                var newAvailableBridges = availableBridges.Select(x => x).ToList();
                newUsedBridges.Add(next);
                newAvailableBridges.Remove(availableBridges.Where(x=> x.Id == next.Id).First());
                possibleBridges.Add(new BridgeStructure() { Bridges = newUsedBridges });
                possibleBridges.AddRange(GetBridgeCombinations(newUsedBridges, next.Pins[0] == currentPinValue ? next.Pins[1] : next.Pins[0] , newAvailableBridges));
            }
            return possibleBridges;
        }
    }

    public class BridgeComponent
    {
        private static int _id = 0;
        public int Id { get; set; }
        public int[] Pins { get; set; } = new int[2];
        public BridgeComponent()
        {
            Id = _id;
            _id++;
        }
        public static BridgeComponent Parse(string input)
        {
            return new BridgeComponent()
            {
                Pins = new int[2]
                {
                    int.Parse(input.Split('/')[0]),
                    int.Parse(input.Split('/')[1])
                }
            };
        }
        public override string ToString()
        {
            return Pins[0] + "/" + Pins[1];
        }
    }

    public class BridgeStructure
    {
        public List<BridgeComponent> Bridges { get; set; } = new List<BridgeComponent>();
        public int Strength => Bridges.Sum(x => x.Pins[0] + x.Pins[1]);
        public override string ToString()
        {
            return string.Join(", ", Bridges.Select(x => x.ToString()).ToArray());
        }
    }

}