namespace EnergyManagement
{
    public class SubCorridor : Corridor
    {
        public SubCorridor(int corridorNumber) : base(corridorNumber)
        {
            this.swithchOffLight();
        }
        public override string ToString()
        {
            return $"Sub corridor { this.corridorNumber } Light {this.corridorNumber} : {this.getLightState()} AC : {this.airConditioner.State}";
        }                
    }
}