using NUnit.Framework;
using System;

namespace ElectricityController.Tests
{
    [TestFixture]
    public class AirConditionerTests
    {
        AirConditioner ac;
        [SetUp]
        public void Setup()
        {
            ac = new AirConditioner();
        }

        [Test]
        public void ShouldConsumePower()
        {
            ac.IsSwitchedOn = true;
            Assert.AreEqual(ac.PowerConsumptionUnits, 10);
        }

        [Test]
        public void ShouldNotConsumePower()
        {
            ac.IsSwitchedOn = false;
            Assert.AreEqual(ac.PowerConsumptionUnits, 0);
        }
    }
}