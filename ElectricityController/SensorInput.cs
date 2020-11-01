namespace ElectricityController
{
    public class SensorInput
    {
        class CorridorMovements{
            int corridorId;
            bool hasMovement;
        }
        //0 based index is ID
        public int floorId;
        public bool IsMainCorridor;
        public int corridorId;
        public bool IsMovement;

        public CorridorMovements[] mainCorridorMovements;
        public CorridorMovements[] subCorridorMovements;

        public SensorInput(string inputs)
        {
            var corridorTypes = inputs.Split(':');

            int i = 0;
            foreach (var corridorMovements in corridorTypes[0].Split(','))
            {
                mainCorridorMovements[i] = new CorridorMovements(){  corridorId =   }
                i++;
            }

        }
    }
}