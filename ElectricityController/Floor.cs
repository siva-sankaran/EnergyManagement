using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EnergyManagement
{
    public class Floor
    {
        private MainCorridor[] mainCorridors { get; set; }

        private SubCorridor[] subCorridors { get; set; }

        private IEnumerable<Corridor> GetAllCorridors()
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
            for (int i = 0; i < noOfSubCorridors; i++)
            {
                subCorridors[i] = new SubCorridor(i + 1);
            }
            MaxPowerConsumption = (noOfMainCorridors * 15) + (noOfSubCorridors * 10);
        }

        public void manageEquipments(int corridorNumber, bool isMovement)
        {
            if(corridorNumber < 1 || corridorNumber > subCorridors.Length)
            {
                throw new ArgumentOutOfRangeException("corridorNumber", corridorNumber, "There is no corridor with such corridor number");
            }
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

        private void switchOnLight(SubCorridor corridor)
        {
            switchOffACIfNecessary(corridor);
            corridor.swithchOnLight();
        }

        private void switchOffACIfNecessary(SubCorridor corridor)
        {
            if (PowerConsumption + 5 > MaxPowerConsumption)
            {
                var otherCorridors = this.subCorridors
                                    .OrderBy(sc => sc.corridorNumber)
                                    .FirstOrDefault(sc => sc.corridorNumber != corridor.corridorNumber && sc.airConditioner.IsSwitchedOn) ?? corridor;
                                    
                otherCorridors.airConditioner.switchOff();
            }
        }

        private void switchOffLight(SubCorridor corridor)
        {
            switchOnACIfNecessary(corridor);
            corridor.swithchOffLight();
        }

        private void switchOnACIfNecessary(SubCorridor corridor)
        {
            if (PowerConsumption + 5 <= MaxPowerConsumption)
            {
                var otherCorridors = this.subCorridors
                                    .OrderBy(sc => sc.corridorNumber)
                                    .FirstOrDefault(sc => sc.corridorNumber != corridor.corridorNumber && !sc.airConditioner.IsSwitchedOn) ?? corridor;
                otherCorridors.airConditioner.switchOn();
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"               Floor { this.FloorNumber }");
            str.AppendLine();
            str.AppendLine();
            foreach (var item in this.GetAllCorridors())
            {
                str.AppendLine(item.ToString());
            }
            return str.ToString();
        }
    }
}