﻿using Common.Extensions;
using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests._2017
{
    [TestFixture]
    public class AOC2017_Day02Test : AOC2017_Day02
    {
        [Test]
        public void TestPart1()
        {
            var arr = "5\t1\t9\t5\r\n7\t5\t3\r\n2\t4\t6\t8".StringTo2ArrayOfArrays("\t");
            Assert.AreEqual(CalcCheckSumMinMax(arr), 18);
        }
        [Test]
        public void TestPart2()
        {
            var arr = "5\t9\t2\t8\r\n9\t4\t7\t3\r\n3\t8\t6\t5".StringTo2ArrayOfArrays("\t");
            Assert.AreEqual(CalcCheckSumDivRem(arr), 9);
        }
    }
}