using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Advent2016.Test
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void IsNotValidTriangle()
        {
            bool isTriangle = true;
            int[] sides = { 5, 10, 25 };

            var checker = new TriangleChecker();

            isTriangle = checker.isValidTriangle(sides);

            Assert.IsFalse(isTriangle);
        }

        [TestMethod]
        public void IsValidTriangle()
        {
            bool isTriangle = false;
            int[] sides = { 5, 9, 13 };

            var checker = new TriangleChecker();

            isTriangle = checker.isValidTriangle(sides);

            Assert.IsTrue(isTriangle);
        }

        [TestMethod]
        public void OnlyOneValidTriangleInList()
        {
            IEnumerable<string> list = new string[] {"5 9 13", "5 7 25", "1 2 3"} ;

            var checker = new TriangleChecker();

            var count = checker.GetValidTriangleCountFromList(list);

            Assert.AreEqual(1, count);
        }


        [TestMethod]
        public void GetInputAnswer()
        {
            IEnumerable<string> triangles = System.IO.File.ReadAllLines("../../../TriangleList.txt");

            var checker = new TriangleChecker();

            var count = checker.GetValidTriangleCountFromList(triangles);

            Assert.AreEqual(1921, count);
            
        }
    }
}
