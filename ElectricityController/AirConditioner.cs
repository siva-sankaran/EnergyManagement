namespace ElectricityController
{
    public class AirConditioner
    {
        public bool IsSwitchedOn { get; set; }

        public int PowerConsumptionUnits 
        { 
            get 
            {
                return IsSwitchedOn ? 10 : 0;
            }
        }
    }
}