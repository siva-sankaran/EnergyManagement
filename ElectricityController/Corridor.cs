using System;

namespace EnergyManagement
{
    public abstract class Corridor
    {
        private Light light { get; set; }
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

        public void swithchOffLight()
        {
            this.light.switchOff();
        }

        public void swithchOnLight()
        {
            this.light.switchOn();
        }

        public string getLightState()
        {
            return this.light.State;
        }

        public void swithchOffAirConditioner()
        {
            this.airConditioner.switchOff();
        }

        public void swithchOnAirConditioner()
        {
            this.airConditioner.switchOn();
        }
    }
    
}