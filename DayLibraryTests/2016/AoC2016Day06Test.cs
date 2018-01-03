using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day06Test: DayTest
    {
        private const string Input = @"eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("easter", TestPart1(Input));
            Assert.AreEqual("umejzgdw", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("advent", TestPart2(Input));
            Assert.AreEqual("aovueakv", TestPart2(null));
        }

    }
}