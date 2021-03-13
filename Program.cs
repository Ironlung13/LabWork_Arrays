using LabWork_Arrays.Classes;
using System;

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
                    //Если файл не существует, то запустится ввод вручную
                    //Файл вывода всегда переписывается
                    //Файлы создаются в output пути сборки (в подпапке)
                    LinearArrays.Task1Variant6();
                    break;
                case "2":
                    //То же самое для матриц
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