using System;

namespace ElectricityController
{
    public class Floor
    {
        public MainCorridor[] mainCorridors { get; set; }

        public SubCorridor[] subCorridors { get; set; }

        readonly int MaxPowerConsumption;

        public Floor(int noOfMainCorridors, int noOfSubCorridors)
        {
            mainCorridors = new MainCorridor[noOfMainCorridors];
            for (int i = 0; i < noOfMainCorridors; i++)
            {
                mainCorridors[i] = new MainCorridor();
            }
           
            subCorridors = new SubCorridor[noOfSubCorridors];
            for (int i = 0; i < noOfMainCorridors; i++)
            {
                subCorridors[i] = new SubCorridor();
            }
            MaxPowerConsumption = (noOfMainCorridors * 15) + (noOfSubCorridors * 10);
        }

        public void manageEquipments(string corridorId, bool IsMovement)
        {
            if(corridorId.StartsWith("S"))
            {

            }

        }
    }
}