using _04_BubbleSort;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class BubbleSortTest
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5})]
        [TestCase(new int[] { 5, 4, 3, 2, 1})]
        [TestCase(new int[] { 0, 4, 0, 2, 0})]
        [TestCase(new int[] { 5, 4 })]
        [TestCase(new int[] { 4, 5 })]
        [TestCase(new int[] { 4 })]
        [TestCase(new int[] { 1, 4, 0, -2000, -2200 })]
        [TestCase(new int[] { int.MaxValue, 0, -2000, int.MinValue })]
        public void TestBubbleSort(int[] arr)
        {
            Bubble bubbleSort = new Bubble();

            int[] sortedArray = new int[arr.Length];
            Array.Copy(arr, sortedArray, arr.Length);

            Array.Sort(sortedArray);

            Assert.That(() => bubbleSort.BubbleSort(arr), Is.EquivalentTo(sortedArray));
        }

    }
}
