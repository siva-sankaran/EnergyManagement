namespace EnergyManagement
{
    public class MainCorridor : Corridor
    {
        public MainCorridor(int corridorNumber) : base(corridorNumber)
        {
            this.swithchOnLight();
        }

        public override string ToString()
        {
            return $"Main corridor { this.corridorNumber } Light {this.corridorNumber} : {this.getLightState()} AC : {this.airConditioner.State}";
        }
    }
}