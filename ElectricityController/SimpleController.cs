using System;
using System.Linq;

namespace EnergyManagement
{
    public class SimpleController : IController
    {
        public void manageEquipments_LongMethod(Floor floor, int corridorNumber, bool isMovement)
        {
            SubCorridor operatingCorridor = floor.subCorridors[corridorNumber-1];
            if (corridorNumber < 1 || corridorNumber > floor.subCorridors.Length)
            {
                throw new ArgumentOutOfRangeException("corridorNumber", corridorNumber, "There is no corridor with such corridor number");
            }
            if (isMovement)
            {
                if (floor.CurrentPowerConsumptionUnits + 5 > floor.MaximumPowerConsumptionLimit)
                {
                    var otherCorridors = floor.subCorridors
                                        .OrderBy(sc => sc.corridorNumber)
                                        .FirstOrDefault(sc => sc.corridorNumber != corridorNumber && sc.airConditioner.IsSwitchedOn)
                                        ?? operatingCorridor;

                    otherCorridors.swithchOffAirConditioner();
                }
                operatingCorridor.swithchOnLight();
            }
            else
            {
                if (floor.CurrentPowerConsumptionUnits + 5 <= floor.MaximumPowerConsumptionLimit)
                {
                    var otherCorridors = floor.subCorridors
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