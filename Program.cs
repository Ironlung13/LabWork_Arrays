using System;
using LabWork_Arrays.Classes;

namespace LabWork_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
        EntryPoint:
            LinearArrays.Task1Variant6();
            Console.WriteLine("\nTo exit program, enter \"q\".");
            Console.WriteLine("To restart program, enter anything else.");
            switch (Console.ReadLine())
            {
                case "q":
                    return;
                default:
                    Console.Clear();
                    goto EntryPoint;
            }
        }
    }
}