using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day18Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            const string Input = @"set a 1
add a 2
mul a a
mod a 5
snd a
set a 0
rcv a
jgz a -1
set a 1
jgz a -2";


            Assert.AreEqual("4", TestPart1(Input));
            Assert.AreEqual("3188", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            const string Input = @"snd 1
snd 2
snd p
rcv a
rcv b
rcv c
rcv d";
            Assert.AreEqual("3", TestPart2(Input));
            Assert.AreEqual("7112", TestPart2(null));
        }
    }
}