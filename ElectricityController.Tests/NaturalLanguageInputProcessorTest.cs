using NUnit.Framework;
using System;

namespace ElectricityController.Tests
{
    [TestFixture]
    public class NaturalLanguageInputProcessorTest
    {
        // static SensorInput Floor7_MainCorridor1_NoMovement = new SensorInput(){ FloorNumber = 7, IsMainCorridor = true, CorridorNumber = 1, HasMovement = false };
        // static SensorInput Floor7_SubCorridor1_NoMovement = new SensorInput(){ FloorNumber = 7, IsMainCorridor = false, CorridorNumber = 1, HasMovement = false };
        // static SensorInput Floor1_MainCorridor3_NoMovement = new SensorInput(){ FloorNumber = 1, IsMainCorridor = true, CorridorNumber = 3, HasMovement = false };
        // static SensorInput Floor1_SubCorridor3_NoMovement = new SensorInput(){ FloorNumber = 1, IsMainCorridor = false, CorridorNumber = 3, HasMovement = false };
        // static SensorInput Floor7_MainCorridor1_WithMovement = new SensorInput(){ FloorNumber = 7, IsMainCorridor = true, CorridorNumber = 1, HasMovement = false };
        // static SensorInput Floor7_SubCorridor1_WithMovement = new SensorInput(){ FloorNumber = 7, IsMainCorridor = false, CorridorNumber = 1, HasMovement = false };
        // static SensorInput Floor1_MainCorridor3_WithMovement = new SensorInput(){ FloorNumber = 1, IsMainCorridor = true, CorridorNumber = 3, HasMovement = false };
        // static SensorInput Floor1_SubCorridor3_WithMovement = new SensorInput(){ FloorNumber = 1, IsMainCorridor = false, CorridorNumber = 3, HasMovement = false };
        NaturalLanguageInputProcess nlprocesser;
        [SetUp]
        public void Setup()
        {
            nlprocesser = new NaturalLanguageInputProcess();
        }
        
        [TestCase("")]
        [TestCase("Movement in Sub Corridor 2 of Floor 1")]
        [TestCase("Movement in Sub Corridor 2 of 1st Floor")]
        public void ParseInput_InvalidInput_ThrowsException(string input)
        {
            Assert.Throws(typeof(ArgumentException), ()=> nlprocesser.parseInput(input));
        }

        // [TestCase("No Movement in Floor 7, Main corridor 1", Floor7_MainCorridor1_NoMovement)]
        // [TestCase("No Movement in Floor 7, Sub corridor 1", Floor7_SubCorridor1_NoMovement)]
        // [TestCase("No Movement in Floor 1, Main corridor 3", Floor1_MainCorridor3_NoMovement)]
        // [TestCase("No Movement in Floor 1, Sub corridor 3", Floor1_SubCorridor3_NoMovement)]
        // [TestCase("Movement in Floor 7, Main corridor 1", Floor7_MainCorridor1_WithMovement)]
        // [TestCase("Movement in Floor 7, Sub corridor 1", Floor7_SubCorridor1_WithMovement)]
        // [TestCase("Movement in Floor 1, Main corridor 3", Floor1_MainCorridor3_WithMovement)]
        // [TestCase("Movement in Floor 1, Sub corridor 3", Floor1_SubCorridor3_WithMovement)]

        
        [TestCase("No Movement in Floor 7, Sub corridor 1", 7, 1, false)]
        [TestCase("No Movement in Floor 1, Sub corridor 3", 1, 3, false)]
        [TestCase("Movement in Floor 7, Sub corridor 1", 7, 1, true)]
        [TestCase("Movement in Floor 1, Sub corridor 3", 1, 3, true)]
        public void ParseInput_ValidInput_ReturnsSensorInputObj(string input, int floorNumber, int corridorNumber, bool hasMovement)
        {
            var sensorInput = nlprocesser.parseInput(input);
            Assert.AreEqual(sensorInput.floorNumber, floorNumber);
            Assert.AreEqual(sensorInput.corridorNumber, corridorNumber);
            Assert.AreEqual(sensorInput.hasMovement, hasMovement);
        }
        
    }
}