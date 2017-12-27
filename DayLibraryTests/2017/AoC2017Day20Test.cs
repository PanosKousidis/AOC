using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day20Test : DayTest
    {
        private const string Input = @"p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>
p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("0", TestPart1(Input));
            Assert.AreEqual("300", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            
            const string input = @"p=<-6,0,0>, v=< 3,0,0>, a=< 0,0,0>    
p=<-4,0,0>, v=< 2,0,0>, a=< 0,0,0>
p=<-2,0,0>, v=< 1,0,0>, a=< 0,0,0>
p=< 3,0,0>, v=<-1,0,0>, a=< 0,0,0>";
            Assert.AreEqual("1", TestPart2(input));
            Assert.AreEqual("502", TestPart2(null));
        }
    }
}