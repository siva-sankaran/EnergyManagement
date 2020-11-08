using System.Collections.Generic;
using System.Linq;

namespace EnergyManagement
{
    public class SubCorridors : ICorridorCollection
    {
        private SubCorridor[] subCorridors;
        public SubCorridors(SubCorridor[] subCorridors)
        {
            this.subCorridors = subCorridors;
        }
        
        #region IEnumerable interface implementation
        public IEnumerator<SubCorridor> GetEnumerator()
        {
            return subCorridors.AsEnumerable().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return subCorridors.AsEnumerable().GetEnumerator();
        }
        #endregion

        #region ICorridorCollection interface implementation
        public int getSubCorridorLength()
        {
            return subCorridors.Length;
        }

        public int getMaximumPowerConsumptionLimit()
        {
            return subCorridors.Length * 10;
        }

        public int getCurrentPowerConsumptionUnits()
        {
            return subCorridors.Sum(s => s.PowerConsumption);
        }

        public SubCorridor getSubCorridorByCorridorNumber(int CorridorNumber)
        {
            return subCorridors[CorridorNumber - 1];
        }
        #endregion
    }
}