using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AOC2016_Day01Test:AOC2016_Day01
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(Part1Result("R2, L3").DistanceFrom(0, 0), 5);
            Assert.AreEqual(Part1Result("R2, R2, R2").DistanceFrom(0, 0), 2);
            Assert.AreEqual(Part1Result("R5, L5, R5, R3").DistanceFrom(0, 0), 12);
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(Part2Result("R8, R4, R4, R8").DistanceFrom(0, 0), 4);
        }

    }
}