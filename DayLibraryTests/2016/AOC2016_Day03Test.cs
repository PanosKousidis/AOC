﻿using AoC;
using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day03Test : DayTest

    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(TestPart1("5 10 25"), "0");
            Assert.AreEqual(TestPart1(null), "917");
        }

        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2("101 301 501\r\n102 302 502\r\n103 303 503\r\n201 401 601\r\n202 402 602\r\n203 403 603"), "6");
            Assert.AreEqual(TestPart2(null), "1649");
        }
    }
}