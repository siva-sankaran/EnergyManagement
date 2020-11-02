using System;

namespace EnergyManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl + C to stop");
            int noOfFloors, noOfMainCorridorsPerFloor, noOfSubCorridorsPerFloor;
            if (args.Length < 3)
            {
                Console.Write("Number of floors:");
                noOfFloors = Convert.ToInt32(Console.ReadLine());

                Console.Write("Main corridors per floor:");
                noOfMainCorridorsPerFloor = Convert.ToInt32(Console.ReadLine());

                Console.Write("Sub corridors per floor:");
                noOfSubCorridorsPerFloor = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                noOfFloors = Int32.Parse(args[0]);
                noOfMainCorridorsPerFloor = Int32.Parse(args[1]);
                noOfSubCorridorsPerFloor = Int32.Parse(args[2]);
            }
            Building controller = new Building(noOfFloors, noOfMainCorridorsPerFloor, noOfSubCorridorsPerFloor);
            while (true)
            {
                Console.Write("Inputs from Sensor: ");
                controller.processSensorInput(Console.ReadLine());    
            }
            
            Console.WriteLine("Bye!");
        }
    }
}
