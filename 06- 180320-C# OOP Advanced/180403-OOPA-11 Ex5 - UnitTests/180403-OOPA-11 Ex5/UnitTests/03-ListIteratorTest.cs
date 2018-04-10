using _03_IteratorTest;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    public class StringArayTestDataSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new string[] { "edno", "dve", "tri", "chetiri" };
            yield return new string[] { "edno", "dve" };
            yield return new string[] { "edno", "dve", "tri", "chetiri", "pet" };
        }
    }

    [TestFixture]
    public class ListIteratorTest
    {
        [Test]
        [TestCaseSource(typeof(StringArayTestDataSource))]
        public void TestConstructor_Valid(string[] values)
        {
            ListIterator<string> list = new ListIterator<string>(values);

            FieldInfo listField = GetListFieldInfo();
            List<string> innerList = (List<string>)listField.GetValue(list);

            Assert.That(innerList, Is.EquivalentTo(values));
        }
        
        [Test]
        public void TestConstructor_Invalid()
        {
            Assert.Throws<ArgumentNullException>(() => new ListIterator<string>(null));
        }

        [Test]
        [TestCaseSource(typeof(StringArayTestDataSource))]
        public void TestMoveMethod_TrueOutput(string[] values)
        {
            ListIterator<string> list = new ListIterator<string>(values);

            Assert.That(() => list.Move(), Is.EqualTo(true));
        }

        [Test]
        [TestCaseSource(typeof(StringArayTestDataSource))]
        public void TestMoveMethod_FalseOutput(string[] values)
        {
            ListIterator<string> list = new ListIterator<string>(values);
            FieldInfo index = GetIndexFieldInfo();
            index.SetValue(list, values.Length - 1);

            Assert.That(() => list.Move(), Is.EqualTo(false));
        }

        [Test]
        [TestCaseSource(typeof(StringArayTestDataSource))]
        public void TestHasNextMethod_TrueOutput(string[] values)
        {
            ListIterator<string> list = new ListIterator<string>(values);

            Assert.That(() => list.HasNext(), Is.EqualTo(true));
        }

        [Test]
        [TestCaseSource(typeof(StringArayTestDataSource))]
        public void TestHasNextMethod_FalseOutput(string[] values)
        {
            ListIterator<string> list = new ListIterator<string>(values);
            FieldInfo index = GetIndexFieldInfo();
            index.SetValue(list, values.Length - 1);

            Assert.That(() => list.Move(), Is.EqualTo(false));
        }

        [Test]
        [TestCaseSource(typeof(StringArayTestDataSource))]
        public void TestPrintMethod_Valid(string[] values)
        {
            ListIterator<string> list = new ListIterator<string>(values);
            FieldInfo listField = GetListFieldInfo();
            string firstItem = ((List<string>)listField.GetValue(list)).First();

            Assert.That(() => list.Print(), Is.EqualTo(firstItem));

            FieldInfo index = GetIndexFieldInfo();
            index.SetValue(list, 1);
            string secondItem = ((List<string>)listField.GetValue(list))[1];

            Assert.That(() => list.Print(), Is.EqualTo(secondItem));
        }

        private FieldInfo GetListFieldInfo()
        {
            Type type = typeof(ListIterator<string>);
            FieldInfo listField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.FieldType == typeof(List<string>));
            return listField;
        }

        private FieldInfo GetIndexFieldInfo()
        {
            FieldInfo indexField = typeof(ListIterator<string>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.FieldType == typeof(int));
            return indexField;
        }
    }
}
