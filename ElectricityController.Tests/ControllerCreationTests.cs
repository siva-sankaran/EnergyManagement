using NUnit.Framework;
using System;

namespace ElectricityController.Tests
{
    [TestFixture]
    public class ControllerCreationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1,1,2)]
        [TestCase(2,1,2)]
        public void CreateSimpleControllerTest(int floors, int mainCorridors, int subCorridors)
        {
            SmartController controller = new SmartController(floors, mainCorridors, subCorridors);
            Assert.AreEqual(floors, controller.NoOfFloors);
            Assert.AreEqual(mainCorridors, controller.NoOfMainCorridors);
            Assert.AreEqual(subCorridors, controller.NoOfSubCorridors);
        }


        [TestCase(0,1,2)]
        [TestCase(-1,1,2)]
        public void CreateSimpleController_WithInvalid_Floors_Test(int floors, int mainCorridors, int subCorridors)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => new SmartController(floors, mainCorridors, subCorridors));
        }
    }
}