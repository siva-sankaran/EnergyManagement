namespace EnergyManagement
{
    public class AirConditioner : ElectricEquipment
    {
        protected override int Units
        {
            get
            {
                return 10;
            }
        }
    }
}