using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day12Test: DayTest
    {
        private const string Input = @"cpy 41 a
inc a
inc a
dec a
jnz a 2
dec a";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("42", TestPart1(Input));
            Assert.AreEqual("318083", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("9227737", TestPart2(null));
        }

    }
}