using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MotorcykelLoggerConsole
{
    static class FileUtilities
    {

       public static string[] ReadVehiclesFromFile()
        {
            string path = @"data.txt";
            string[] fromFileData = new string[0];
            //reads from file if exists, otherwiseCreateds
            if(System.IO.File.Exists(path))
            {
                fromFileData = System.IO.File.ReadAllLines(path);
            }
            else
            {
                File.Create(path);
            }
            return fromFileData;
        }
        
        public static void PrintVehiclesToFile(List<Vehicle> vehicles)
        {
            string path = @"/data.txt";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entered Printing method");
            Console.ForegroundColor = ConsoleColor.White;

            using (StreamWriter sW = new StreamWriter("data.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Using Streamwriter");
                Console.ForegroundColor = ConsoleColor.White;
                string[] linesToWrite = Program.GetVehicleListAsArray(vehicles);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File Opened");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (string s in linesToWrite)
                {
                    sW.WriteLine(s);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Line printed to file: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(s);
                }
            }
            Console.Clear();
            Console.WriteLine("Press any button to exit..");
            Console.ReadLine();
        }
    }
}
