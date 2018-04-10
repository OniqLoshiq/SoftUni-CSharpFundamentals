using _09_DateTime;
using Moq;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    public class DateTimeNowTests
    {
        [Test]
        public void AddDayToTheMiddleOfTheMonth()
        {
            var mock = new Mock<IDateTime>();
            mock.Setup(f => f.Now).Returns(new DateTime(2006, 7, 18));

            DateTime result = mock.Object.Now.AddDays(1);
            DateTime expectedDate = new DateTime(2006, 7, 19);

            Assert.AreEqual(expectedDate, result);
        }

        [Test]
        public void AddDayToTheEndOfTheMonth()
        {
            var mock = new Mock<IDateTime>();
            mock.Setup(f => f.Now).Returns(new DateTime(2006, 7, 31));

            DateTime result = mock.Object.Now.AddDays(1);
            DateTime expectedDate = new DateTime(2006, 8, 1);

            Assert.AreEqual(expectedDate, result);
        }

        [Test]
        public void AddPreviousDayToTheDate_ResultSameMonth()
        {
            var mock = new Mock<IDateTime>();
            mock.Setup(f => f.Now).Returns(new DateTime(2006, 7, 31));

            DateTime result = mock.Object.Now.AddDays(-5);
            DateTime expectedDate = new DateTime(2006, 7, 26);

            Assert.AreEqual(expectedDate, result);
        }

        [Test]
        public void AddPreviousDayToTheDate_ResulPreviousMonth()
        {
            var mock = new Mock<IDateTime>();
            mock.Setup(f => f.Now).Returns(new DateTime(2006, 7, 2));

            DateTime result = mock.Object.Now.AddDays(-5);
            DateTime expectedDate = new DateTime(2006, 6, 27);

            Assert.AreEqual(expectedDate, result);
        }

        [Test]
        public void AddDayToLeapYearInFebruary()
        {
            var mock = new Mock<IDateTime>();
            mock.Setup(f => f.Now).Returns(new DateTime(2008, 2, 28));

            DateTime result = mock.Object.Now.AddDays(1);
            DateTime expectedDate = new DateTime(2008, 2, 29);

            Assert.AreEqual(expectedDate, result);
        }

        [Test]
        public void AddDayToNormalYearInFebruary()
        {
            var mock = new Mock<IDateTime>();
            mock.Setup(f => f.Now).Returns(new DateTime(2009, 2, 28));

            DateTime result = mock.Object.Now.AddDays(1);
            DateTime expectedDate = new DateTime(2009, 3, 1);

            Assert.AreEqual(expectedDate, result);
        }
    }
}
