namespace EnergyManagement
{
    public class SubCorridor : Corridor
    {
        public SubCorridor(int corridorNumber) : base(corridorNumber)
        {
            this.light.switchOff();
        }
        public override string ToString()
        {
            return $"Sub corridor { this.corridorNumber } Light {this.corridorNumber} : {this.light.State} AC : {this.airConditioner.State}";
        }                
    }
}