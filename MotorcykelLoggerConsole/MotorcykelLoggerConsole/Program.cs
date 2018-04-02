using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcykelLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            bool exit = false;
            string[] fromFileData = FileUtilities.ReadVehiclesFromFile();
            if (fromFileData.Length > 0)
            {
                for (int i = 0; i < fromFileData.Length; i++)
                {
                    string[] argumentData = fromFileData[i].Split(' ');
                    vehicleList.Add(new Vehicle(argumentData[0], int.Parse(argumentData[1]), int.Parse(argumentData[2]), int.Parse(argumentData[3]), int.Parse(argumentData[4])));

                }
            }
            while (!exit)
            {
                PrintVehicleList(vehicleList);
                String input;
                Console.WriteLine("1. Add new vehicle");
                Console.WriteLine("2. Update existing vehicle miles");
                Console.WriteLine("3. Commit service");
                Console.WriteLine("4. Exit");

                input = Console.ReadLine();
                if (input.ToLower() == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Please enter: Name Year Miles ServiceInterval.");
                    input = Console.ReadLine();
                    String[] vehicleData = input.Split(' ');
                    vehicleList.Add(new Vehicle(vehicleData[0], int.Parse(vehicleData[1]), int.Parse(vehicleData[2]), int.Parse(vehicleData[3]), int.Parse(vehicleData[4])));
                }
                if(input.ToLower() == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Please select a vehicle: ");
                    PrintVehicleNamesWithNumbers(getNameOfVehiclesInList(vehicleList));
                    input = Console.ReadLine();
                    if(int.Parse(input) < vehicleList.Count)
                    {
                        int index = int.Parse(input);
                        Console.WriteLine("Input new miles");
                        input = Console.ReadLine();
                        vehicleList[index - 1].setMiles(int.Parse(input));
                    }            
                }
                if (input.ToLower() == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Please select a vehicle: ");
                    PrintVehicleNamesWithNumbers(getNameOfVehiclesInList(vehicleList));
                    input = Console.ReadLine();
                    if (int.Parse(input) < vehicleList.Count)
                    {
                        int index = int.Parse(input);
                        Console.WriteLine("Input miles when service was done");
                        input = Console.ReadLine();
                        vehicleList[index - 1].ServiceDoneAtMiles(int.Parse(input));
                    }
                }
                if (input.ToLower() == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Do you wish to exit?(YES/NO)");
                    input = Console.ReadLine();
                    if (input.ToLower() == "yes")
                    {
                        FileUtilities.PrintVehiclesToFile(vehicleList);
                        exit = true;
                    }
                    if (input.ToLower() == "no")
                    {

                    }

                }
        
                Console.Clear();
            }
        }


        public static void PrintVehicleList(List<Vehicle> list)
        {
            foreach (object t in list)
            {
                Console.WriteLine(t);
            }
        }

        public static void PrintVehicleNamesWithNumbers(string[] names)
        {
            for(int i = 0; i < names.Length; i++)
            {
                Console.WriteLine((i + 1) + ". "+ names[i]);
            }
        }

        public static string[] GetVehicleListAsArray(List<Vehicle> list)
        {
            string[] returnString = new string[list.Count];
            for (int i = 0; i < returnString.Length; i++)
            {
                returnString[i] = list[i].ToFileString();
            }

            return returnString;
        }

        public static string[] getNameOfVehiclesInList(List<Vehicle> list)
        {
            string[] names = new string[list.Count]; 
            for(int i = 0; i < list.Count; i++)
            {
                names[i] = list[i].Name;
            }
            return names;
        }
    }
}
