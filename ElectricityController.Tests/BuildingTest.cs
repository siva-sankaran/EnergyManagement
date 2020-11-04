using NUnit.Framework;
using System;

namespace EnergyManagement.Tests
{
    [TestFixture]
    public class BuildingTest
    {
        Building _2floors_1main_2sub;
        [SetUp]
        public void Setup()
        {
               _2floors_1main_2sub = new Building(2, 1, 2);
        }
        [TestCase(2, 1, 2, @"               Floor 1

Main corridor 1 Light 1 : ON AC : ON
Sub corridor 1 Light 1 : OFF AC : ON
Sub corridor 2 Light 2 : OFF AC : ON

               Floor 2

Main corridor 1 Light 1 : ON AC : ON
Sub corridor 1 Light 1 : OFF AC : ON
Sub corridor 2 Light 2 : OFF AC : ON
")]
        public void DefaultState_ToString(int floorNos, int mCorNos, int sCorNos, string str)
        {
            Building building = new Building(floorNos, mCorNos, sCorNos);
            Assert.AreEqual(str, building.ToString());

        }
        [TestCase("Movement in Floor 1, Sub corridor 2", @"               Floor 1

Main corridor 1 Light 1 : ON AC : ON
Sub corridor 1 Light 1 : OFF AC : OFF
Sub corridor 2 Light 2 : ON AC : ON

               Floor 2

Main corridor 1 Light 1 : ON AC : ON
Sub corridor 1 Light 1 : OFF AC : ON
Sub corridor 2 Light 2 : OFF AC : ON
")]
        public void processSensorInput_With1_Movement_Test(string sensorInputString, string str)
        {
            _2floors_1main_2sub.processSensorInput(sensorInputString);
            Assert.AreEqual(str, _2floors_1main_2sub.ToString());
            Assert.AreEqual(str, _2floors_1main_2sub.ToString());
        }

        [TestCase("Movement in Floor 1, Sub corridor 2", @"               Floor 1

Main corridor 1 Light 1 : ON AC : ON
Sub corridor 1 Light 1 : OFF AC : OFF
Sub corridor 2 Light 2 : ON AC : ON

               Floor 2

Main corridor 1 Light 1 : ON AC : ON
Sub corridor 1 Light 1 : OFF AC : ON
Sub corridor 2 Light 2 : OFF AC : ON
", "No Movement in Floor 1, Sub corridor 2", @"               Floor 1

Main corridor 1 Light 1 : ON AC : ON
Sub corridor 1 Light 1 : OFF AC : ON
Sub corridor 2 Light 2 : OFF AC : ON

               Floor 2

Main corridor 1 Light 1 : ON AC : ON
Sub corridor 1 Light 1 : OFF AC : ON
Sub corridor 2 Light 2 : OFF AC : ON
")]
        public void processSensorInput_With1_movement_And_NoMovement_Test(string first_sensorInputString, string first_str, string second_sensorInputString, string second_str)
        {
            _2floors_1main_2sub.processSensorInput(first_sensorInputString);
            //After 1 Movement
            Assert.AreEqual(first_str, _2floors_1main_2sub.ToString());
            
            _2floors_1main_2sub.processSensorInput(second_sensorInputString);
            Assert.AreEqual(second_str, _2floors_1main_2sub.ToString());
        }        
        
    }
}