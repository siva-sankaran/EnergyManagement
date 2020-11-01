namespace ElectricityController
{
    public class Light
    {
        public bool IsSwitchedOn { get; private set; }

        public string State
        {
            get
            {
                return IsSwitchedOn ? "ON" : "OFF";
            }
        }

        public void switchOn() => IsSwitchedOn = true;

        public void switchOff() => IsSwitchedOn = false;

        public int PowerConsumptionUnits 
        { 
            get 
            {
                return IsSwitchedOn ? 5 : 0;
            }
        }
    }
}