using System;
namespace ElectricityController
{
    public class SmartController
    {
        private int NoOfFloors { get; set; }
        private int NoOfMainCorridors { get; set; }
        private int NoOfSubCorridors { get; set; }
        private Floor[] floors;

        private IInputProcess inputProcesser;
        public SmartController(int noOfFloors, int noOfMainCorridors, int noOfSubCorridors)
        {
            this.NoOfFloors = noOfFloors;
            if (noOfFloors < 1)
            {
                throw new ArgumentOutOfRangeException("noOfFloors", "Number of floors cannot be less than 1");
            }
            this.NoOfMainCorridors = noOfMainCorridors;
            if (noOfMainCorridors < 1)
            {
                throw new ArgumentOutOfRangeException("noOfMainCorridors", "Number of Main Corridors cannot be less than 1");
            }
            this.NoOfSubCorridors = noOfSubCorridors;
            if (noOfSubCorridors < 1)
            {
                throw new ArgumentOutOfRangeException("noOfSubCorridors", "Number of Sub Corridors cannot be less than 1");
            }

            floors = new Floor[this.NoOfFloors];
            for (int i = 0; i < this.NoOfFloors; i++)
            {
                floors[i] = new Floor(i+1, noOfMainCorridors, noOfSubCorridors);
            }

            inputProcesser = new NaturalLanguageInputProcess();
        }

        public void processSensorInput(string input)
        {
            var sensorInput = inputProcesser.parseInput(input);
            floors[sensorInput.floorNumber].manageEquipments(sensorInput.corridorNumber, sensorInput.hasMovement);
        }

        
    }
}