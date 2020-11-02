using NUnit.Framework;
using System;

namespace EnergyManagement.Tests
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
            light.switchOn();
            Assert.AreEqual(light.PowerConsumptionUnits, 5);
        }

        [Test]
        public void ShouldNotConsumePower()
        {
            light.switchOff();
            Assert.AreEqual(light.PowerConsumptionUnits, 0);
        }

        [Test]
        public void ShouldLightStateBeOn()
        {
            light.switchOn();
            Assert.AreEqual(light.State, "ON");
        }

        [Test]
        public void ShouldLightStateBeOff()
        {
            light.switchOff();
            Assert.AreEqual(light.State, "OFF");
        }
    }
}