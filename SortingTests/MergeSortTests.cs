using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingLIb;
using SortingTests;

namespace Sorting.Tests
{
    [TestClass()]
    public class MergeSortTests
    {
        [TestMethod()]
        public void SortSmallOddListTest()
        {
            RunSortTest(new List<int>() { 1, 3, 4, 6, 3, 0, 5 });
        }

        [TestMethod()]
        public void SortSmallEvenListTest()
        {
            RunSortTest(new List<int>() { 1, 3, 4, 6, 3, 0});
        }

        [TestMethod()]
        public void SortRandomlyGeneratedSmallList()
        {
            RunSortTest(ListGenerator.Generate(100));
        }

        [TestMethod()]
        public void SortRandomlyGeneratedLargeList()
        {
            RunSortTest(ListGenerator.Generate(100000));
        }

        private static void RunSortTest(List<int> actual)
        {
            var sw = new Stopwatch();

            // sort using our implementation
            sw.Start();
            actual = MergeSort<int>.Sort(actual);
            var actualTime = sw.ElapsedMilliseconds;

            // sort using .Net implementation
            sw.Restart();
            actual.Sort();
            var expectedTime = sw.ElapsedMilliseconds;
            var expected = actual;

            Console.WriteLine($"Our implementation is {(actualTime > expectedTime ? "slower" : "faster")} than .Net's by {Math.Abs(expectedTime - actualTime)} ms for {actual.Count} ints.");
            
            // assert
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}