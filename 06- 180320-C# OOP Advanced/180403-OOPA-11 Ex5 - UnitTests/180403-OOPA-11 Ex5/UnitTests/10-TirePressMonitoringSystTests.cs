using _10_TirePressMonitoringSyst;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class TirePressMonitoringSystTests
    {
        public class ValidDoubleTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return 17;
                yield return 18.5;
                yield return 20;
                yield return 20.13;
                yield return 21;
            }
        }

        public class InvalidDoubleTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return 16.99;
                yield return 5.84;
                yield return -5.84;
                yield return 0;
                yield return 21.01;
                yield return 200;
            }
        }

        [Test]
        [TestCaseSource(typeof(ValidDoubleTestDataSource))]
        public void TestAlarmOn_ResultFalse(double value)
        {
            var fakeSensor = new Mock<Sensor>();
            fakeSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(value);
            
            var alarm = new Alarm();

            FieldInfo sensor = typeof(Alarm).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.IsInitOnly);
            sensor.SetValue(alarm, fakeSensor.Object);

            alarm.Check();

            Assert.IsFalse(alarm.AlarmOn);
        }

        [Test]
        [TestCaseSource(typeof(InvalidDoubleTestDataSource))]
        public void TestAlarmOn_ResultTrue(double value)
        {
            var fakeSensor = new Mock<Sensor>();
            fakeSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(value);

            var alarm = new Alarm();

            FieldInfo sensor = typeof(Alarm).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.IsInitOnly);
            sensor.SetValue(alarm, fakeSensor.Object);

            alarm.Check();

            Assert.IsTrue(alarm.AlarmOn);
        }
    }
}
