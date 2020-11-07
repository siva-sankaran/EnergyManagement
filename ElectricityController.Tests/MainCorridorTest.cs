using NUnit.Framework;
using System;

namespace EnergyManagement.Tests
{
    [TestFixture, Category("MainCorridor")]
    public class MainCorridorTest
    {
        MainCorridor corridor;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void DefaultStateTest()
        {
            corridor = new MainCorridor(1);
            Assert.AreEqual("ON", corridor.getLightState(), "Light is expected to be On");
            Assert.IsTrue(corridor.airConditioner.IsSwitchedOn, "AirConditioner is expected to be On");
        }

        [Test]
        public void DefaultPowerConsumptionTest()
        {
            corridor = new MainCorridor(1);
            Assert.AreEqual(15, corridor.PowerConsumption);
        }

        [Test]
        public void AfterSwitchOffLight_PowerConsumptionTest()
        {
            corridor = new MainCorridor(1);
            corridor.swithchOffLight();
            Assert.AreEqual(10, corridor.PowerConsumption);
        }        

        [Test]
        public void WithLights_DefaultState_And_ACOff_PowerConsumptionTest()
        {
            corridor = new MainCorridor(1);
            corridor.airConditioner.switchOff();
            Assert.AreEqual(5, corridor.PowerConsumption);
        }

        [Test]
        public void WithLightsOff_And_ACOff_PowerConsumptionTest()
        {
            corridor = new MainCorridor(1);
            corridor.swithchOffLight();
            corridor.airConditioner.switchOff();
            Assert.AreEqual(0, corridor.PowerConsumption);
        }

        [Test]
        public void DefaultToStringTest()
        {
            corridor = new MainCorridor(1);
            Assert.AreEqual("Main corridor 1 Light 1 : ON AC : ON", corridor.ToString());
        }
        [Test]
        public void AfterSwitchOffLight_ToStringTest()
        {
            corridor = new MainCorridor(1);
            corridor.swithchOffLight();
            Assert.AreEqual("Main corridor 1 Light 1 : OFF AC : ON", corridor.ToString());
        }        

        [Test]
        public void WithLights_DefaultState_And_ACOff_ToStringTest()
        {
            corridor = new MainCorridor(1);
            corridor.airConditioner.switchOff();
            Assert.AreEqual("Main corridor 1 Light 1 : ON AC : OFF", corridor.ToString());
        }

        [Test]
        public void WithLightsOffAndACOff_ToStringTest()
        {
            corridor = new MainCorridor(1);
            corridor.swithchOffLight();
            corridor.airConditioner.switchOff();
            Assert.AreEqual("Main corridor 1 Light 1 : OFF AC : OFF", corridor.ToString());  
        }      



    }
}