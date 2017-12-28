using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day08Test: DayTest
    {
        private const string Input = @"";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("119", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(@"XXXX.XXXX.X..X.XXXX..XXX.XXXX..XX...XX..XXX...XX..
...X.X....X..X.X....X....X....X..X.X..X.X..X.X..X.
..X..XXX..XXXX.XXX..X....XXX..X..X.X....X..X.X..X.
.X...X....X..X.X.....XX..X....X..X.X.XX.XXX..X..X.
X....X....X..X.X.......X.X....X..X.X..X.X....X..X.
XXXX.X....X..X.X....XXX..X.....XX...XXX.X.....XX..
"
                , TestPart2(null));
        }

    }
}