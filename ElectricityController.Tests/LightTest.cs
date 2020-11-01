using NUnit.Framework;
using System;

namespace ElectricityController.Tests
{
    [TestFixture]
    public class LightTests
    {
        Light light;
        [SetUp]
        public void Setup()
        {
            light = new Light();
        }

        [Test]
        public void ShouldConsumePower()
        {
            light.IsSwitchedOn = true;
            Assert.AreEqual(light.PowerConsumptionUnits, 5);
        }

        [Test]
        public void ShouldNotConsumePower()
        {
            light.IsSwitchedOn = false;
            Assert.AreEqual(light.PowerConsumptionUnits, 0);
        }
    }
}