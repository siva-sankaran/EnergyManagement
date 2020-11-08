using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EnergyManagement
{
    public class Floor
    {
        private MainCorridor[] mainCorridors { get; set; }
        public SubCorridors subCorridors { get; set; }
        private IEnumerable<Corridor> GetAllCorridors()
        {
            return ((Corridor[])mainCorridors).Concat(subCorridors);
        }
        public int FloorNumber { get; private set; }
        public Floor(int floorNumber, int noOfMainCorridors, int noOfSubCorridors)
        {
            this.FloorNumber = floorNumber;
            mainCorridors = new MainCorridor[noOfMainCorridors];
            for (int i = 0; i < noOfMainCorridors; i++)
            {
                mainCorridors[i] = new MainCorridor(i + 1);
            }

            SubCorridor[] scs = new SubCorridor[noOfSubCorridors];
            for (int i = 0; i < noOfSubCorridors; i++)
            {
                scs[i] = new SubCorridor(i + 1);
            }
            this.subCorridors = new SubCorridors(scs);
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