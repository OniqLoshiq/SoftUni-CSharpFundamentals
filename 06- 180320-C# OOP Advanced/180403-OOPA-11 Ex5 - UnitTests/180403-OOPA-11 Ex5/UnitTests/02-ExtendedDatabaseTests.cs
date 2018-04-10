using _02_ExtendedDatabase;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using System;

namespace UnitTests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int DatabaseCapacity = 16;
        private const int BaseIndex = -1;
        private IPerson[] people = new IPerson[3] { new Person(0, "proba0"), new Person(18, "proba1"), new Person(23231, "proba2") };

        [Test]
        public void TestConstructor()
        {
            PersonDatabase db = new PersonDatabase();

            FieldInfo storageField = GetStorageField();
            int storageCapacity = ((IPerson[])storageField.GetValue(db)).Length;

            Assert.That(storageCapacity, Is.EqualTo(DatabaseCapacity));

            int currentIndex = (int)GetIndexField().GetValue(db);

            Assert.That(currentIndex, Is.EqualTo(BaseIndex));
        }

        [Test]
        [TestCase(0, "proba0")]
        [TestCase(123, "proba1")]
        [TestCase(long.MaxValue, "proba2")]
        [TestCase(556848, "proba3")]
        public void TestAddMethod_Valid(long id, string username)
        {
            IPerson personToAdd = new Person(id, username);
            PersonDatabase db = new PersonDatabase();

            int indexBeforeAdd = (int)GetIndexField().GetValue(db);
            db.Add(personToAdd);

            FieldInfo storageField = GetStorageField();
            IPerson firstPerson = ((IPerson[])storageField.GetValue(db)).First();
            Assert.That(firstPerson, Is.EqualTo(personToAdd));

            int indexAfterAdd = (int)GetIndexField().GetValue(db);
            Assert.That(indexAfterAdd, Is.EqualTo(indexBeforeAdd + 1));
        }

        [Test]
        [TestCase(0, "proba0")]
        public void TestAddMethod_AddPersonWithSameId_Invalid(long id, string username)
        {
            IPerson personToAddWithSameId = new Person(id, username);
            PersonDatabase db = new PersonDatabase();

            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, new IPerson[] { new Person(0, "Dokka") });

            //IPerson[] storage = (IPerson[])storageField.GetValue(db);
            //storage[0] = new Person(0, "Dokka");

            FieldInfo currentIndexInfo = GetIndexField();
            currentIndexInfo.SetValue(db, 0);

            Assert.That(() => db.Add(personToAddWithSameId), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(0, "proba0")]
        public void TestAddMethod_AddPersonWithSameUsername_Invalid(long id, string username)
        {
            IPerson personToAddWithSameUsername = new Person(id, username);
            PersonDatabase db = new PersonDatabase();

            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, new IPerson[] { new Person(18, "proba0") });

            //IPerson[] storage = (IPerson[])storageField.GetValue(db);
            //storage[0] = new Person(18, "proba0");

            FieldInfo currentIndexInfo = GetIndexField();
            currentIndexInfo.SetValue(db, 0);

            Assert.That(() => db.Add(personToAddWithSameUsername), Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveMethod_Valid()
        {
            PersonDatabase db = new PersonDatabase();

            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, people);

            FieldInfo indexInfo = GetIndexField();
            indexInfo.SetValue(db, people.Length - 1);

            IPerson lastPerson = people.Last();
            IPerson removedPerson = db.Remove();

            Assert.That(removedPerson, Is.EqualTo(lastPerson));

            int currentIndex = (int)indexInfo.GetValue(db);

            Assert.That(currentIndex, Is.EqualTo(people.Length - 2));
        }

        [Test]
        public void TestRemoveMethod_Invalid()
        {
            PersonDatabase db = new PersonDatabase();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFetchMethod_Valid()
        {
            PersonDatabase db = new PersonDatabase();

            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, people);

            FieldInfo indexInfo = GetIndexField();
            indexInfo.SetValue(db, people.Length - 1);

            Assert.That(() => db.Fetch(), Is.EquivalentTo(people));
        }

        [Test]
        [TestCase(0, "proba0")]
        public void TestFindById_Valid(long id, string username)
        {
            PersonDatabase db = new PersonDatabase();
            IPerson personToFindById = new Person(id, username);

            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, people);

            Assert.AreEqual(db.FindById(0), personToFindById);
        }

        [Test]
        public void TestFindById_GiveNegativeId_Invalid()
        {
            PersonDatabase db = new PersonDatabase();

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]
        public void TestFindById_GiveIdOutOfStorage_Invalid()
        {
            PersonDatabase db = new PersonDatabase();
            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, people);

            Assert.Throws<InvalidOperationException>(() => db.FindById(10));
        }

        [Test]
        [TestCase(0, "proba0")]
        public void TestFindByUsername_Valid(long id, string username)
        {
            PersonDatabase db = new PersonDatabase();
            IPerson personToFindByUsername = new Person(id, username);

            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, people);

            Assert.AreEqual(db.FindByUsername("proba0"), personToFindByUsername);
        }

        [Test]
        public void TestFindByUsername_GiveNullUsername_Invalid()
        {
            PersonDatabase db = new PersonDatabase();

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }

        [Test]
        public void TestFindByUsername_GiveUsernameToUpper_Invalid()
        {
            PersonDatabase db = new PersonDatabase();
            FieldInfo storageField = GetStorageField();
            storageField.SetValue(db, people);

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("PROBA0"));
        }

        private FieldInfo GetStorageField()
        {
            FieldInfo storageField = typeof(PersonDatabase).BaseType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.FieldType == typeof(IPerson[]));
            return storageField;
        }

        private FieldInfo GetIndexField()
        {
            FieldInfo indexField = typeof(PersonDatabase).BaseType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.FieldType == typeof(int));
            return indexField;
        }
    }
}
