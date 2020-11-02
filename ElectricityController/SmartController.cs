using System;
namespace EnergyManagement
{
    public class Building
    {
        private Floor[] floors;
        private IInputProcess inputProcesser;
        public Building(int noOfFloors, int noOfMainCorridors, int noOfSubCorridors)
        {
            if (noOfFloors < 1)
            {
                throw new ArgumentOutOfRangeException("noOfFloors", "Number of floors cannot be less than 1");
            }
            
            if (noOfMainCorridors < 1)
            {
                throw new ArgumentOutOfRangeException("noOfMainCorridors", "Number of Main Corridors cannot be less than 1");
            }
            
            if (noOfSubCorridors < 1)
            {
                throw new ArgumentOutOfRangeException("noOfSubCorridors", "Number of Sub Corridors cannot be less than 1");
            }

            floors = new Floor[noOfFloors];
            for (int i = 0; i < noOfFloors; i++)
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