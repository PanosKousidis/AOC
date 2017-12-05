using DayLibrary;
using DayLibrary.Properties;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day04Test:AoC2016Day04
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(Part1Result("aaaaa-bbb-z-y-x-123[abxyz]"), 123);
            Assert.AreEqual(Part1Result("a-b-c-d-e-f-g-h-987[abcde]"), 987);
            Assert.AreEqual(Part1Result("not-a-real-room-404[oarel]"), 404);
            Assert.AreEqual(Part1Result("totally-real-room-200[decoy]"), 0);
            Assert.AreEqual(Part1Result(Resources.AoC2016_Day04_Input), 137896);
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(Part2Result(Resources.AoC2016_Day04_Input), 501);
        }

    }
}