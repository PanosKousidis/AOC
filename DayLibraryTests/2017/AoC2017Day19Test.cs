using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day19Test : DayTest
    {
        private const string Input = @"     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     +B-+  +--+ ";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("ABCDEF", TestPart1(Input));
            Assert.AreEqual("ITSZCJNMUO", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("38", TestPart2(Input));
            Assert.AreEqual("17420", TestPart2(null));
        }
    }
}