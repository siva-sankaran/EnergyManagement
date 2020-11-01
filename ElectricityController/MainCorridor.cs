namespace ElectricityController
{
    public class MainCorridor : Corridor
    {
        public MainCorridor(int corridorNumber) : base(corridorNumber)
        {
            this.light.switchOn();
        }

        public override string ToString()
        {
            return $"Main corridor { this.corridorNumber } Light {this.corridorNumber} : {this.light.State} AC : {this.airConditioner.State}";
        }
    }
}