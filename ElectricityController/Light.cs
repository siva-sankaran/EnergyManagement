namespace ElectricityController
{
    public class Light
    {
        public bool IsSwitchedOn { get; set; }

        public int PowerConsumptionUnits 
        { 
            get 
            {
                return IsSwitchedOn ? 5 : 0;
            }
        }
    }
}