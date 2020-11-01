using System;
namespace ElectricityController
{
    public class SmartController
    {
        public int NoOfFloors { get; set; }
        public int NoOfMainCorridors { get; set; }
        public int NoOfSubCorridors { get; set; }
        public Floor[] floors;
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
                floors[i] = new Floor(noOfMainCorridors, noOfSubCorridors);
            }
        }

        public void processSensorInput(SensorInput input)
        {
            floors[input.floorId].manageEquipments(input.corridorId, input.IsMovement);

        }
    }
}