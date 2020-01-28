using System;
using System.Collections.Generic;
using Kata;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class FriendOrFoeTests
        {
            [Test]
            public void TestFriendOrFoe()
            {
                string[] expected = { "Ryan", "Mark" };
                string[] names = { "Ryan", "Kieran", "Mark", "Jimmy" };
                CollectionAssert.AreEqual(expected, KataImplementations.FriendOrFoe(names));
            }
        }

        [TestFixture]
        public class PrinterTests
        {

            [Test]
            public void TestPrinter()
            {
                Console.WriteLine("Testing PrinterError");
                string s = "aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";
                Assert.AreEqual("3/56", KataImplementations.PrinterError(s));
            }
        }

        [TestFixture]
        public class BitCounting
        {
            [Test]
            public void TestCountBits()
            {
                Assert.AreEqual(0, KataImplementations.CountBits(0));
                Assert.AreEqual(1, KataImplementations.CountBits(4));
                Assert.AreEqual(3, KataImplementations.CountBits(7));
                Assert.AreEqual(2, KataImplementations.CountBits(9));
                Assert.AreEqual(2, KataImplementations.CountBits(10));
            }
        }

        [TestFixture]
        public class FindTests
        {
            [Test]
            public static void TestFind1()
            {
                int[] exampleTest1 = { 2, 6, 8, -10, 3 };
                Assert.IsTrue(3 == KataImplementations.Find(exampleTest1));
            }

            [Test]
            public static void TestFind2()
            {
                int[] exampleTest2 = { 206847684, 1056521, 7, 17, 1901, 21104421, 7, 1, 35521, 1, 7781 };
                Assert.IsTrue(206847684 == KataImplementations.Find(exampleTest2));
            }

            [Test]
            public static void TestFind3()
            {
                int[] exampleTest3 = { int.MaxValue, 0, 1 };
                Assert.IsTrue(0 == KataImplementations.Find(exampleTest3));
            }
        }

        [TestFixture]
        public class DnaComplementTest
        {
            [TestCase]
            public void test01()
            {
                Assert.AreEqual("TTTT", KataImplementations.DNAComplement("AAAA"));
            }
            [TestCase]
            public void test02()
            {
                Assert.AreEqual("TAACG", KataImplementations.DNAComplement("ATTGC"));
            }
            [TestCase]
            public void test03()
            {
                Assert.AreEqual("CATA", KataImplementations.DNAComplement("GTAT"));
            }
        }

        [TestFixture]
        public class XbonacciTest
        {
            private KataImplementations.Xbonacci variabonacci;

            [SetUp]
            public void SetUp()
            {
                variabonacci = new KataImplementations.Xbonacci();
            }

            [TearDown]
            public void TearDown()
            {
                variabonacci = null;
            }

            [Test]
            public void Tests()
            {
                Assert.AreEqual(new double[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105 }, variabonacci.Tribonacci(new double[] { 1, 1, 1 }, 10));
                Assert.AreEqual(new double[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 }, variabonacci.Tribonacci(new double[] { 0, 0, 1 }, 10));
                Assert.AreEqual(new double[] { 0, 1, 1, 2, 4, 7, 13, 24, 44, 81 }, variabonacci.Tribonacci(new double[] { 0, 1, 1 }, 10));
            }
        }

        [TestFixture]
        public partial class SolutionTest
        {
            [Test, Description("ValidatePin should return false for pins with length other than 4 or 6")]
            public void LengthTest()
            {
                Assert.AreEqual(false, KataImplementations.ValidatePin("1"), "Wrong output for \"1\"");
                Assert.AreEqual(false, KataImplementations.ValidatePin("12"), "Wrong output for \"12\"");
                Assert.AreEqual(false, KataImplementations.ValidatePin("123"), "Wrong output for \"123\"");
                Assert.AreEqual(false, KataImplementations.ValidatePin("12345"), "Wrong output for \"12345\"");
                Assert.AreEqual(false, KataImplementations.ValidatePin("1234567"), "Wrong output for \"1234567\"");
                Assert.AreEqual(false, KataImplementations.ValidatePin("-1234"), "Wrong output for \"-1234\"");
                Assert.AreEqual(false, KataImplementations.ValidatePin("1.234"), "Wrong output for \"1.234\"");
                Assert.AreEqual(false, KataImplementations.ValidatePin("-1.234"), "Wrong output for \"-1.234\"");
                Assert.AreEqual(false, KataImplementations.ValidatePin("00000000"), "Wrong output for \"00000000\"");
            }

            [Test, Description("ValidatePin should return false for pins which contain characters other than digits")]
            public void NonDigitTest()
            {
                Assert.AreEqual(false, KataImplementations.ValidatePin("a234"), "Wrong output for \"a234\"");
                Assert.AreEqual(false, KataImplementations.ValidatePin(".234"), "Wrong output for \".234\"");
            }

            [Test, Description("ValidatePin should return true for valid pins")]
            public void ValidTest()
            {
                Assert.AreEqual(true, KataImplementations.ValidatePin("1234"), "Wrong output for \"1234\"");
                Assert.AreEqual(true, KataImplementations.ValidatePin("0000"), "Wrong output for \"0000\"");
                Assert.AreEqual(true, KataImplementations.ValidatePin("1111"), "Wrong output for \"1111\"");
                Assert.AreEqual(true, KataImplementations.ValidatePin("123456"), "Wrong output for \"123456\"");
                Assert.AreEqual(true, KataImplementations.ValidatePin("098765"), "Wrong output for \"098765\"");
                Assert.AreEqual(true, KataImplementations.ValidatePin("000000"), "Wrong output for \"000000\"");
                Assert.AreEqual(true, KataImplementations.ValidatePin("090909"), "Wrong output for \"090909\"");
            }
        }

        [TestFixture]
        public class PigLatinTest
        {
            [Test]
            public void KataTests()
            {
                Assert.AreEqual("igPay atinlay siay oolcay", KataImplementations.PigLatin("Pig latin is cool"));
                Assert.AreEqual("hisTay siay ymay tringsay", KataImplementations.PigLatin("This is my string"));
            }
        }

        [TestFixture]
        public class PrimeTest
        {
            private static IEnumerable<TestCaseData> sampleTestCases
            {
                get
                {
                    yield return new TestCaseData(0).Returns(false);
                    yield return new TestCaseData(1).Returns(false);
                    yield return new TestCaseData(2).Returns(true);
                    yield return new TestCaseData(282589933).Returns(true);
                }
            }

            [Test, TestCaseSource("sampleTestCases")]
            public bool SampleTest(int n) => KataImplementations.IsPrime(n);
        }

        [TestFixture]
        public class DeleteNthTests
        {
            [Test]
            public void TestSimple()
            {
                var expected = new int[] { 20, 37, 21 };

                var actual = KataImplementations.DeleteNth(new int[] { 20, 37, 20, 21 }, 1);

                CollectionAssert.AreEqual(expected, actual);
            }

            [Test]
            public void TestSimple2()
            {
                var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };

                var actual = KataImplementations.DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [TestFixture]
        public class WeightSortTests
        {

            [Test]
            public void Test1()
            {
                Console.WriteLine("****** Basic Tests");
                Assert.AreEqual("2000 103 123 4444 99", KataImplementations.orderWeight("103 123 4444 99 2000"));
                Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", KataImplementations.orderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
            }
        }

        [TestFixture]
        public class ValidateWordTest
        {
            [Test]
            public void GenericTests()
            {
                Assert.AreEqual(3, KataImplementations.FindEvenIndex(new int[] { 1, 2, 3, 4, 3, 2, 1 }));
                Assert.AreEqual(1, KataImplementations.FindEvenIndex(new int[] { 1, 100, 50, -51, 1, 1 }));
                Assert.AreEqual(-1, KataImplementations.FindEvenIndex(new int[] { 1, 2, 3, 4, 5, 6 }));
                Assert.AreEqual(3, KataImplementations.FindEvenIndex(new int[] { 20, 10, 30, 10, 10, 15, 35 }));
            }
        }

        [TestFixture]
        public class RgbTest
        {
            [Test]
            public void FixedTests()
            {
                Assert.AreEqual("FFFFFF", KataImplementations.Rgb(255, 255, 255));
                Assert.AreEqual("FFFFFF", KataImplementations.Rgb(255, 255, 300));
                Assert.AreEqual("000000", KataImplementations.Rgb(0, 0, 0));
                Assert.AreEqual("9400D3", KataImplementations.Rgb(148, 0, 211));
                Assert.AreEqual("9400D3", KataImplementations.Rgb(148, -20, 211), "Handle negative numbers.");
                Assert.AreEqual("90C3D4", KataImplementations.Rgb(144, 195, 212));
                Assert.AreEqual("D4350C", KataImplementations.Rgb(212, 53, 12), "Consider single hex digit numbers.");
            }
        }

        [TestFixture]
        public class TDDTest
        {
            [Test]
            public void MyTest()
            {
                try
                {
                    KataImplementations.Add(null, null);
                    Assert.Fail(); // If it gets to this line, no exception was thrown
                }
                catch (Exception) { }

                try
                {
                    KataImplementations.Add("9", null);
                    Assert.Fail(); // If it gets to this line, no exception was thrown
                }
                catch (Exception) { }

                try
                {
                    KataImplementations.Add("10", "word");
                    Assert.Fail(); // If it gets to this line, no exception was thrown
                }
                catch (Exception) { }
                
                Assert.AreEqual(200, KataImplementations.Add("100", "100"));
            }
        }

        [TestFixture]
        public class RangeExtractorTest
        {
            [Test(Description = "Simple tests")]
            public void SimpleTests()
            {
                Assert.AreEqual("1,2", KataImplementations.Extract(new[] { 1, 2 }));
                Assert.AreEqual("1-3", KataImplementations.Extract(new[] { 1, 2, 3 }));

                Assert.AreEqual(
                    "-6,-3-1,3-5,7-11,14,15,17-20",
                    KataImplementations.Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 })
                );

                Assert.AreEqual(
                    "-3--1,2,10,15,16,18-20",
                    KataImplementations.Extract(new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 })
                );
            }
        }
    }
}