using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day07Test : DayTest
    {
        private const string InputTest = @"pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)";

        [Test]
        public void TestPart1()
        {

            Assert.AreEqual("tknk", TestPart1(InputTest));
            Assert.AreEqual("aapssr", TestPart1(null));

        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("60", TestPart2(InputTest));
            Assert.AreEqual("1458", TestPart2(null));
        }
    }
}