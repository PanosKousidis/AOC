using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day10Test: DayTest
    {
        private const string Input = @"value 5 goes to bot 2
bot 2 gives low to bot 1 and high to bot 0
value 3 goes to bot 1
bot 1 gives low to output 1 and high to bot 0
bot 0 gives low to output 2 and high to output 0
value 2 goes to bot 2";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("2", TestPart1(Input, new[] { 2, 5 }));
            Assert.AreEqual("98", TestPart1(null, new[] { 61, 17 }));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("4042", TestPart2(null, new[] { 0, 1, 2 }));
        }

    }
}