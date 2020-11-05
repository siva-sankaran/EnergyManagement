using NUnit.Framework;
using System;

namespace EnergyManagement.Tests
{
    [TestFixture]
    public class FloorTest
    {
        Floor floor;

        [TestCase(1, 1, 25), Category("Default")]
        [TestCase(1, 2, 35)]
        [TestCase(1, 3, 45)]
        [TestCase(1, 4, 55)]
        [TestCase(1, 5, 65)]
        [TestCase(2, 1, 40)]
        [TestCase(2, 2, 50)]
        [TestCase(2, 3, 60)]
        [TestCase(2, 4, 70)]
        [TestCase(2, 5, 80)]
        public void DefaultPowerConsumptionTest(int noOfMainCorridors, int noOfSubCorridors, int expectedPowerConsumptionUnits)
        {
            floor = new Floor(1, noOfMainCorridors, noOfSubCorridors);
            Assert.AreEqual(expectedPowerConsumptionUnits, floor.PowerConsumption);
        }

        [TestCase(1, 1, 20), Category("SingleMovement")]
        [TestCase(1, 2, 30)]
        [TestCase(1, 3, 40)]
        [TestCase(1, 4, 50)]
        [TestCase(1, 5, 60)]
        [TestCase(2, 1, 35)]
        [TestCase(2, 2, 45)]
        [TestCase(2, 3, 55)]
        [TestCase(2, 4, 65)]
        [TestCase(2, 5, 75)]
        public void After_First_Movement_At_First_SubCorridor_PowerConsumptionTest(int noOfMainCorridors, int noOfSubCorridors, int expectedPowerConsumptionUnits)
        {
            floor = new Floor(1, noOfMainCorridors, noOfSubCorridors);
            floor.manageEquipments(1, true);
            Assert.AreEqual(expectedPowerConsumptionUnits, floor.PowerConsumption);
        }

        [TestCase(1, 2, 35)]
        [TestCase(1, 3, 45)]
        [TestCase(1, 4, 55)]
        [TestCase(1, 5, 65)]
        [TestCase(2, 2, 50)]
        [TestCase(2, 3, 60)]
        [TestCase(2, 4, 70)]
        [TestCase(2, 5, 80)]
        public void With_Movement_At_SubCorridor1_AND_2_PowerConsumptionTest(int noOfMainCorridors, int noOfSubCorridors, int expectedPowerConsumptionUnits)
        {
            floor = new Floor(1, noOfMainCorridors, noOfSubCorridors);
            floor.manageEquipments(1, true);
            floor.manageEquipments(2, true);
            Assert.AreEqual(expectedPowerConsumptionUnits, floor.PowerConsumption);
        }
        
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        public void With_Movement_At_Invalid_SubCorridor_PowerConsumptionTest(int noOfMainCorridors, int noOfSubCorridors)
        {
            floor = new Floor(1, noOfMainCorridors, noOfSubCorridors);
            floor.manageEquipments(1, true);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => floor.manageEquipments(2, true));
        }

        [TestCase(1, 1, 25)]
        [TestCase(1, 2, 35)]
        [TestCase(1, 3, 45)]
        [TestCase(1, 4, 55)]
        [TestCase(1, 5, 65)]
        [TestCase(2, 1, 40)]
        [TestCase(2, 2, 50)]
        [TestCase(2, 3, 60)]
        [TestCase(2, 4, 70)]
        [TestCase(2, 5, 80)]
        public void With_First_Movement_At_First_SubCorridor_Then_NoMovement_PowerConsumptionTest(int noOfMainCorridors, int noOfSubCorridors, int expectedPowerConsumptionUnits)
        {
            floor = new Floor(1, noOfMainCorridors, noOfSubCorridors);
            floor.manageEquipments(1, true);
            floor.manageEquipments(1, false);
            Assert.AreEqual(expectedPowerConsumptionUnits, floor.PowerConsumption);
        }


    }
}
