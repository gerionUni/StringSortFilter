using NUnit.Framework;
using System;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            //Assert.Pass();
            string sample = "Chapters in books are usually given the cardinal numbers 1, 2, 3, 4, 5, 6 and so on. But I have decided to give my chapters prime numbers 2, 3, 5, 7, 11, 13 and so on because I like prime numbers.  This is how you work out what prime numbers are.";
            string cleanSample = "Chapters in books are usually given the cardinal numbers , , , 4, , 6 and so on. But I have decided to give my chapters prime numbers , , , , ,  and so on because I like prime numbers.  This is how you work out what prime numbers are." + Environment.NewLine;
            PrimeNumberFilter.Classes.Functions fn = new PrimeNumberFilter.Classes.Functions();
            Assert.AreEqual(fn.NewText(sample,"Asc"), cleanSample);
        }
    }
}