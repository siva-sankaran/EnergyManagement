namespace EnergyManagement
{
    public abstract class ElectricEquipment
    {
        protected static int _powerConsumption;
        protected abstract int Units
        {
            get;
        }
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
                return IsSwitchedOn ? Units : 0;
            }
        }
    }
}