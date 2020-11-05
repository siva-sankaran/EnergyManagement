using System;

namespace EnergyManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter \"quit\" to stop");
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
            Building building = new Building(noOfFloors, noOfMainCorridorsPerFloor, noOfSubCorridorsPerFloor);
            Console.WriteLine(building);

            string input = Console.ReadLine();
            while (!input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("SensorInput:> " + input);
                building.processSensorInput(input);
                Console.WriteLine(building);
                input = Console.ReadLine();
            }

            Console.WriteLine("Bye!");

            //getInputInteractively(building);
        }
        public static void getInputInteractively(Building building)
        {
            string input;
            Console.Write("Inputs from Sensor: ");
            input = Console.ReadLine();
            while (!input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                building.processSensorInput(input);
                Console.WriteLine(building);
                Console.Write("Inputs from Sensor: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Bye!");
        }
    }
}
