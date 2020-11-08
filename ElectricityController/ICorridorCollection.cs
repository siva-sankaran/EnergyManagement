using System.Collections.Generic;
using System.Linq;

namespace EnergyManagement
{
    public interface ICorridorCollection : IEnumerable<SubCorridor>
    {
        public int getSubCorridorLength();
        public int getMaximumPowerConsumptionLimit();
        public int getCurrentPowerConsumptionUnits();
        public SubCorridor getSubCorridorByCorridorNumber(int CorridorNumber);
    }
}