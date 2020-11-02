namespace EnergyManagement
{
    public interface IInputProcess
    {
        (int floorNumber, int corridorNumber, bool hasMovement) parseInput(string input);
    }
}