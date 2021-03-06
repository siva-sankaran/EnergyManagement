using System;
using System.Text;

namespace EnergyManagement
{
    public class Building
    {
        private Floor[] floors;
        private IInputProcess inputProcesser;

        private IController controller;

        public Building(int noOfFloors, int noOfMainCorridors, int noOfSubCorridors, IController controller)
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

            this.controller = controller;

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
            controller.manageEquipments_LongMethod(floors[sensorInput.floorNumber-1], sensorInput.corridorNumber, sensorInput.hasMovement);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var floor in floors)
            {
                str.AppendLine(floor.ToString());
            }
            str.Length -= 2;
            return str.ToString();
        }

        
    }
}