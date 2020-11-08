using System;
using System.Linq;

namespace EnergyManagement
{
    public class SimpleController : IController
    {
        public void manageEquipments_LongMethod(ICorridorCollection corridors, int corridorNumber, bool isMovement)
        {
            SubCorridor operatingCorridor = corridors.getSubCorridorByCorridorNumber(corridorNumber);
            if (corridorNumber < 1 || corridorNumber > corridors.getSubCorridorLength())
            {
                throw new ArgumentOutOfRangeException("corridorNumber", corridorNumber, "There is no corridor with such corridor number");
            }
            if (isMovement)
            {
                if (corridors.getCurrentPowerConsumptionUnits() + 5 > corridors.getMaximumPowerConsumptionLimit())
                {
                    var otherCorridors = corridors
                                        .OrderBy(sc => sc.corridorNumber)
                                        .FirstOrDefault(sc => sc.corridorNumber != corridorNumber && sc.airConditioner.IsSwitchedOn)
                                        ?? operatingCorridor;

                    otherCorridors.swithchOffAirConditioner();
                }
                operatingCorridor.swithchOnLight();
            }
            else
            {
                if (corridors.getCurrentPowerConsumptionUnits() + 5 <= corridors.getMaximumPowerConsumptionLimit())
                {
                    var otherCorridors = corridors
                                        .OrderBy(sc => sc.corridorNumber)
                                        .FirstOrDefault(sc => sc.corridorNumber != corridorNumber && !sc.airConditioner.IsSwitchedOn) 
                                        ?? operatingCorridor;

                    otherCorridors.swithchOnAirConditioner();
                }
                operatingCorridor.swithchOffLight();
            }

        }
    }
}