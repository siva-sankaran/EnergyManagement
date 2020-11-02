using System;

namespace EnergyManagement
{
    public abstract class Corridor
    {
        public Light light { get; set; }
        public AirConditioner airConditioner { get; set; }

        public int corridorNumber { get; set; }

        public int PowerConsumption 
        { 
            get
            {
                return light.PowerConsumptionUnits + airConditioner.PowerConsumptionUnits;
            }
        }

        public Corridor(int corridorNumber)
        {
            if (corridorNumber < 1)
            {
                throw new ArgumentException("corridorNumber can not be less than 1");
            }
            this.corridorNumber = corridorNumber;
            this.light = new Light();
            this.airConditioner = new AirConditioner();
            this.airConditioner.switchOn();
        }
    }
    
}