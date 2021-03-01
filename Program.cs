using System;
using LabWork_Arrays.Classes;

namespace LabWork_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
        EntryPoint:
            Console.WriteLine("Choose task:");
            Console.WriteLine("1. Linear Arrays.");
            Console.WriteLine("2. Matrices.");
            switch (Console.ReadLine())
            {
                case "1":
                    LinearArrays.Task1Variant6();
                    break;
                case "2":
                    Matrices.Task1Variant6();
                    break;
                default:
                    Console.Clear();
                    goto EntryPoint;
            }

            Console.WriteLine("\nTo exit program, enter \"q\".");
            Console.WriteLine("To restart program, enter anything else.");
            switch (Console.ReadLine())
            {
                case "q":
                case "Q":
                    return;
                default:
                    Console.Clear();
                    goto EntryPoint;
            }
        }
    }
}