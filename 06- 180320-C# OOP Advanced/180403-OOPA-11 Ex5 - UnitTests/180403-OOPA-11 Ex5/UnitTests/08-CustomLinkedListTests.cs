using _08_CustomLinkedList;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class CustomLinkedListTests
    {
        private DynamicList<int> dList;

        [SetUp]
        public void DynamicListTestUnit()
        {
            this.dList = new DynamicList<int>();
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void GetElementByIndex_Invalid(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { int element = this.dList[index]; }, "The provided index is invalid!");
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        public void AddItemShouldIncreaseCountAndGetElementByIndex_Valid(int num, int index)
        {
            this.dList.Add(num);
            this.dList.Add(num);

            int expectedCount = 2;

            Assert.AreEqual(num, this.dList[index], "The element is not added on the right index!");
            Assert.AreEqual(expectedCount, this.dList.Count, "The count of the list is not being increased by one!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveAtMethod_Invalid(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dList.RemoveAt(index), "The provided index is invalid!");
        }

        [Test]
        [TestCase(2, 1)]
        [TestCase(2, 0)]
        [TestCase(18, 10)]
        public void RemoveAtMethod_ShouldReturnRemovedItem_ShouldDecreaseCount_Valid(int numberOfElements, int indexToRemove)
        {
            AddElements(numberOfElements);
            int removedItem = this.dList.RemoveAt(indexToRemove);

            int expectedItemToBeRemoved = indexToRemove;

            Assert.AreEqual(expectedItemToBeRemoved, removedItem, "The removed item is not at the right index!");
            Assert.That(numberOfElements - 1, Is.EqualTo(this.dList.Count), "The count is not being decreased by one!");
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(2, 0)]
        [TestCase(18, 9)]
        public void RemoveMetod_ShouldReturnRemovedIndex_ShouldDecreaseCount(int numberOfElements, int elementToRemove)
        {
            AddElements(numberOfElements);
            int removedIndex = this.dList.Remove(elementToRemove);

            int expectedIndexToBeRemoved = elementToRemove;

            Assert.AreEqual(expectedIndexToBeRemoved, removedIndex, "The removed index is not the index of the item!");
            Assert.AreEqual(numberOfElements - 1, this.dList.Count, "The count is not being decreased by one!");
        }

        [Test]
        [TestCase(3, 4)]
        [TestCase(2, 3)]
        [TestCase(18, -1)]
        public void RemoveMethod_ShouldNotFindItem_ShouldHaveSameCount(int numberOfElements, int elementToRemove)
        {
            AddElements(numberOfElements);
            int removedIndex = this.dList.Remove(elementToRemove);

            int expectedIndexToBeRemoved = -1;

            Assert.AreEqual(expectedIndexToBeRemoved, removedIndex);
            Assert.AreEqual(numberOfElements, this.dList.Count, "The count should not change!");
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(2, 0)]
        [TestCase(18, 9)]
        public void IndexOfMetod_ShouldReturnIndexOfElement(int numberOfElements, int element)
        {
            AddElements(numberOfElements);
            int indexOfElement = this.dList.IndexOf(element);

            int expectedIndex = element;

            Assert.AreEqual(expectedIndex, indexOfElement);
        }

        [Test]
        [TestCase(3, -1)]
        [TestCase(2, 5)]
        [TestCase(18, 55)]
        public void IndexOfMetod_ShouldReturnIndexOfNotFoundElement(int numberOfElements, int element)
        {
            AddElements(numberOfElements);
            int indexOfElement = this.dList.IndexOf(element);

            int expectedIndex = -1;

            Assert.AreEqual(expectedIndex, indexOfElement);
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(2, 0)]
        [TestCase(18, 9)]
        public void ContainsMetod_ShouldReturnTrue(int numberOfElements, int element)
        {
            AddElements(numberOfElements);
            bool containsElement = this.dList.Contains(element);

            bool expectedOutput = true;

            Assert.AreEqual(expectedOutput, containsElement);
        }

        [Test]
        [TestCase(3, 3)]
        [TestCase(2, 2)]
        [TestCase(18, 18)]
        public void ContainsMetod_ShouldReturnFalse(int numberOfElements, int element)
        {
            AddElements(numberOfElements);
            bool containsElement = this.dList.Contains(element);

            bool expectedOutput = false;

            Assert.AreEqual(expectedOutput, containsElement);
        }

        private void AddElements(int numberOfElements)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                this.dList.Add(i);
            }
        }
    }
}
