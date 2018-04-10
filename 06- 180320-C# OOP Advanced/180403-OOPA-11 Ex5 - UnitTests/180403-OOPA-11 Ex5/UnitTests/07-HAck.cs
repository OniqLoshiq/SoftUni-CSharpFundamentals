using _07_Hack;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class Hack
    {
        public class IntegerTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return 1;
                yield return 0;
                yield return -20;
                yield return 15684;
                yield return -15684;
            }
        }

        public class DoubleTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return -50.6;
                yield return 15.2568;
                yield return -10035.35843;
                yield return 657.575;
            }
        }

        [Test]
        [TestCaseSource(typeof(IntegerTestDataSource))]
        public void TestMathAbsMethod(int num)
        {
            Mock<IMathAbs> fakeAbs = new Mock<IMathAbs>();
            fakeAbs.Setup(x => x.GetMathAbsValue(num)).Returns(Math.Abs(num));

            var function = new MathFunctions();
            int positiveNumber = function.GetMathAbsValue(num);

            Assert.AreEqual(fakeAbs.Object.GetMathAbsValue(num), positiveNumber);
        }

        [Test]
        [TestCaseSource(typeof(DoubleTestDataSource))]
        public void TestMathFloorMethod(double num)
        {
            Mock<IMathFloor> fakeFloor = new Mock<IMathFloor>();
            fakeFloor.Setup(x => x.GetMathFloorValue(num)).Returns((int)Math.Floor(num));

            var function = new MathFunctions();
            int flooredNumber = function.GetMathFloorValue(num);

            Assert.AreEqual(fakeFloor.Object.GetMathFloorValue(num), flooredNumber);
        }
    }
}
