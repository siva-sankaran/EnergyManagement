using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ElectricityController
{
    public class Floor
    {
        private MainCorridor[] mainCorridors { get; set; }

        private SubCorridor[] subCorridors { get; set; }

        public IEnumerable<Corridor> GetAllCorridors()
        {
            return ((Corridor[])mainCorridors).Concat((Corridor[])subCorridors);
        }

        public int FloorNumber { get; private set; }

        private readonly int MaxPowerConsumption;

        public Floor(int floorNumber, int noOfMainCorridors, int noOfSubCorridors)
        {
            this.FloorNumber = floorNumber;
            mainCorridors = new MainCorridor[noOfMainCorridors];
            for (int i = 0; i < noOfMainCorridors; i++)
            {
                mainCorridors[i] = new MainCorridor(i + 1);
            }

            subCorridors = new SubCorridor[noOfSubCorridors];
            for (int i = 0; i < noOfMainCorridors; i++)
            {
                subCorridors[i] = new SubCorridor(i + 1);
            }
            MaxPowerConsumption = (noOfMainCorridors * 15) + (noOfSubCorridors * 10);
        }

        public void manageEquipments(int corridorNumber, bool isMovement)
        {
            if (isMovement)
            {
                switchOnLight(subCorridors[corridorNumber-1]);
            }
            else
            {
                switchOffLight(subCorridors[corridorNumber-1]);
            }
        }

        public int PowerConsumption
        {
            get
            {
                return GetAllCorridors().Sum(c => c.PowerConsumption);
            }
        }

        private void switchOnLight(SubCorridor c)
        {
            if (PowerConsumption + 5 > MaxPowerConsumption)
            {
                var otherCorridors = this.subCorridors.First(sc => sc.corridorNumber != c.corridorNumber && sc.airConditioner.IsSwitchedOn);
                otherCorridors.airConditioner.switchOff();
            }
            c.light.switchOn();
        }

        private void switchOffLight(SubCorridor c)
        {
            if (PowerConsumption + 5 <= MaxPowerConsumption)
            {
                var otherCorridors = this.subCorridors.First(sc => sc.corridorNumber != c.corridorNumber && !sc.airConditioner.IsSwitchedOn);
                otherCorridors.airConditioner.switchOn();
            }
            c.light.switchOff();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"               Floor { this.FloorNumber }");
            foreach (var item in this.GetAllCorridors())
            {
                str.AppendLine(item.ToString());
            }
            return str.ToString();
        }
    }
}