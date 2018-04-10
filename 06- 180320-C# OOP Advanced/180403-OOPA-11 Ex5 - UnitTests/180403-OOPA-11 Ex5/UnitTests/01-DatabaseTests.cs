using _01_Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] {  })]
        public void TestConstructor_InitializeValues_Valid(int[] values)
        {
            Database<int> db = new Database<int>(values);

            FieldInfo storageField = GetStorageField();

            IEnumerable<int> storageValues = ((int[])storageField.GetValue(db)).Take(values.Length);

            Assert.That(storageValues, Is.EquivalentTo(values));
        }

        [Test]
        public void TestConstructor_InitializeValues_Invalid()
        {
            int[] values = new int[17];

            Assert.That(() => new Database<int>(values), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        [TestCase(-10000)]
        [TestCase(667)]
        public void TestAddMethod_Valid(int element)
        {
            Database<int> db = new Database<int>();
            int indexBeforeAdd = (int)GetIndexField().GetValue(db);
            db.Add(element);

            FieldInfo storageField = GetStorageField();
            int firstElement = ((int[])storageField.GetValue(db)).First();
            Assert.That(firstElement, Is.EqualTo(element));

            int indexAfterAdd = (int)GetIndexField().GetValue(db);
            Assert.That(indexAfterAdd, Is.EqualTo(indexBeforeAdd + 1));
        }

        [Test]
        public void TestAddMethod_Invalid()
        {
            Database<int> db = new Database<int>();
            FieldInfo currentIndexInfo = GetIndexField();
            currentIndexInfo.SetValue(db, 16);

            Assert.That(() => db.Add(18), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 })]
        public void TestRemoveMethod_Valid(int[] values)
        {
            Database<int> db = new Database<int>();

            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, values);

            FieldInfo indexInfo = GetIndexField();
            indexInfo.SetValue(db, values.Length - 1);

            int lastElement = values.Last();
            int removedElement = db.Remove();

            Assert.That(removedElement, Is.EqualTo(lastElement));

            int currentIndex = (int)indexInfo.GetValue(db);

            Assert.That(currentIndex, Is.EqualTo(values.Length - 2));
        }

        [Test]
        public void TestRemoveMethod_Invalid()
        {
            Database<int> db = new Database<int>();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 })]
        public void TestFetchMethod_Valid(int[] values)
        {
            Database<int> db = new Database<int>();

            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, values);

            FieldInfo indexInfo = GetIndexField();
            indexInfo.SetValue(db, values.Length - 1);

            Assert.That(() => db.Fetch(), Is.EquivalentTo(values));
        }

        private FieldInfo GetStorageField()
        {
            FieldInfo storageField = typeof(Database<int>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.FieldType == typeof(int[]));
            return storageField;
        }

        private FieldInfo GetIndexField()
        {
            FieldInfo indexField = typeof(Database<int>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.FieldType == typeof(int));
            return indexField;
        }
    }
}
