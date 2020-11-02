using NUnit.Framework;
using System;

namespace EnergyManagement.Tests
{
    [TestFixture]
    public class SubCorridorTest
    {
        SubCorridor corridor;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void DefaultStateTest()
        {
            corridor = new SubCorridor(1);
            Assert.False(corridor.light.IsSwitchedOn, "Light is expected to be Off");
            Assert.IsTrue(corridor.airConditioner.IsSwitchedOn, "AirConditioner is expected to be On");
        }

        [Test]
        public void DefaultPowerConsumptionTest()
        {
            corridor = new SubCorridor(1);
            Assert.AreEqual(10, corridor.PowerConsumption);
        }

        [Test]
        public void AfterSwitchOnLight_PowerConsumptionTest()
        {
            corridor = new SubCorridor(1);
            corridor.light.switchOn();
            Assert.AreEqual(15, corridor.PowerConsumption);
        }        

        [Test]
        public void WithLightsOnAndACOff_PowerConsumptionTest()
        {
            corridor = new SubCorridor(1);
            corridor.light.switchOn();
            corridor.airConditioner.switchOff();
            Assert.AreEqual(5, corridor.PowerConsumption);
        }

        [Test]
        public void WithLightsOffAndACOff_PowerConsumptionTest()
        {
            corridor = new SubCorridor(1);
            corridor.light.switchOff();
            corridor.airConditioner.switchOff();
            Assert.AreEqual(0, corridor.PowerConsumption);
        }

        [Test]
        public void DefaultToStringTest()
        {
            corridor = new SubCorridor(1);
            Assert.AreEqual("Sub corridor 1 Light 1 : OFF AC : ON", corridor.ToString());
        }
        [Test]
        public void AfterSwitchOnLight_ToStringTest()
        {
            corridor = new SubCorridor(1);
            corridor.light.switchOn();
            Assert.AreEqual("Sub corridor 1 Light 1 : ON AC : ON", corridor.ToString());
        }        

        [Test]
        public void WithLightsOnAndACOff_ToStringTest()
        {
            corridor = new SubCorridor(1);
            corridor.light.switchOn();
            corridor.airConditioner.switchOff();
            Assert.AreEqual("Sub corridor 1 Light 1 : ON AC : OFF", corridor.ToString());
        }

        [Test]
        public void WithLightsOffAndACOff_ToStringTest()
        {
            corridor = new SubCorridor(1);
            corridor.light.switchOff();
            corridor.airConditioner.switchOff();
            Assert.AreEqual("Sub corridor 1 Light 1 : OFF AC : OFF", corridor.ToString());  
        }      



    }
}