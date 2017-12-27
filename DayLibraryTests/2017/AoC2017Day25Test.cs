using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day25Test : DayTest
    {
        private const string Input = @"Begin in state A.
Perform a diagnostic checksum after 6 steps.

In state A:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state B.
  If the current value is 1:
    - Write the value 0.
    - Move one slot to the left.
    - Continue with state B.

In state B:
  If the current value is 0:
    - Write the value 1.
    - Move one slot to the left.
    - Continue with state A.
  If the current value is 1:
    - Write the value 1.
    - Move one slot to the right.
    - Continue with state A.";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("3", TestPart1(Input));
            Assert.AreEqual("4287", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(null, TestPart2(Input));
            //Assert.AreEqual(null, TestPart2(null));
        }
    }
}