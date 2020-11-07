using NUnit.Framework;
using System;

namespace EnergyManagement.Tests
{
    [TestFixture, Category("AirCondition")]
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
            ac.switchOn();
            Assert.AreEqual(ac.PowerConsumptionUnits, 10);
        }

        [Test]
        public void ShouldNotConsumePower()
        {
            ac.switchOff();
            Assert.AreEqual(ac.PowerConsumptionUnits, 0);
        }

        [Test]
        public void ShouldAirConditionStateBeOn()
        {
            ac.switchOn();
            Assert.AreEqual(ac.State, "ON");
        }

        [Test]
        public void ShouldAirConditionStateBeOff()
        {
            ac.switchOff();
            Assert.AreEqual(ac.State, "OFF");
        }
    }
}