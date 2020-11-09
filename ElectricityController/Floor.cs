using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EnergyManagement
{
    public class Floor
    {
        private MainCorridor[] mainCorridors { get; set; }
        public SubCorridor[] subCorridors { get; set; }
        private IEnumerable<Corridor> GetAllCorridors()
        {
            return ((Corridor[])mainCorridors).Concat(subCorridors);
        }
        public int FloorNumber { get; private set; }

        public int MaximumPowerConsumptionLimit
        {
            get
            {
                return subCorridors.Length * 10;
            }
        }

        public int CurrentPowerConsumptionUnits
        {
            get 
            { 
                return subCorridors.Sum(s => s.PowerConsumption);
            }
        }
        
        public Floor(int floorNumber, int noOfMainCorridors, int noOfSubCorridors)
        {
            this.FloorNumber = floorNumber;
            mainCorridors = new MainCorridor[noOfMainCorridors];
            for (int i = 0; i < noOfMainCorridors; i++)
            {
                mainCorridors[i] = new MainCorridor(i + 1);
            }

            this.subCorridors = new SubCorridor[noOfSubCorridors];
            for (int i = 0; i < noOfSubCorridors; i++)
            {
                this.subCorridors[i] = new SubCorridor(i + 1);
            }
        }

        public override string ToString()
        {
            return this.GetAllCorridors()
                        .Aggregate(new StringBuilder($"               Floor { this.FloorNumber }")
                                    .AppendLine()
                                    .AppendLine(), 
                            (sb, corridor)=> sb.AppendLine(corridor.ToString()))
                        .ToString();
        }

    }
}