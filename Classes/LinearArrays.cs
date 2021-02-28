using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LabWork_Arrays.Classes
{
    public static class LinearArrays
    {
        public static void Task1Variant6(string inputFilePath = @"D:\Text Files\EPAM_Arrays\input.io")
        {
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"File at [{inputFilePath}] doesn't exist! \nSwitching to manual input.");
                Task1Variant6ManualInput(inputFilePath);
                return;
            }

            using (StreamReader sr = File.OpenText(inputFilePath))
            {
                if (int.TryParse(sr.ReadLine(), out int N) && N >= 0)
                {
                    Console.WriteLine($"Size of array is {N}");
                    int[] array = new int[N];
                    string[] tokens = Regex.Split(sr.ReadLine(), @"(-?[0-9]+[\.]?[0-9]?)");

                    int currentArrayIndex = 0;
                    foreach (string substring in tokens)
                    {
                        if (currentArrayIndex >= array.Length)
                        {
                            Console.WriteLine("Array is full, so not all numbers were added.");
                            break;
                        }
                        else if (int.TryParse(substring, out int number))
                        {
                            array[currentArrayIndex] = number;
                            currentArrayIndex++;
                        }
                    }
                    Console.WriteLine($"Ammount of positive elements in array: {CountPositiveElementsInArray(array)}");
                    return;
                }
                else
                {
                    Console.WriteLine("Failed to get size of array from file. \nSwitching to manual input.");
                }
            }

            //This get's triggered if StreamReader fails to get info from file.
            Task1Variant6ManualInput(inputFilePath);
            return;
        }
        private static void Task1Variant6ManualInput(string inputFilePath = @"D:\Text Files\EPAM_Arrays\input.io")
        {
            Console.Write("Enter size of array\n=> ");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
            {
                Console.Write("Invalid input. Try again\n=> ");
            }
            int[] array = new int[N];

            Console.Write("Enter your numbers (integers) in a single line:\n=> ");
            string input = Console.ReadLine();
            Console.WriteLine();

            string[] tokens = Regex.Split(input, @"(-?[0-9]+[\.]?[0-9]?)");

            int currentArrayIndex = 0;
            foreach (string substring in tokens)
            {
                if (currentArrayIndex >= array.Length)
                {
                    Console.WriteLine("Array is full, so not all numbers were added.");
                    break;
                }
                else if (int.TryParse(substring, out int number))
                {
                    array[currentArrayIndex] = number;
                    currentArrayIndex++;
                }
            }

            using (StreamWriter sw = File.CreateText(inputFilePath))
            {
                sw.WriteLine(N);
                foreach (var number in array)
                {
                    sw.Write(number + " ");
                }

                Console.WriteLine("Save to file successful.");
            }

            Console.WriteLine($"Ammount of positive elements in array: {CountPositiveElementsInArray(array)}");
        }
        private static int CountPositiveElementsInArray(int[] array, string outputFilePath = @"D:\Text Files\EPAM_Arrays\output.io")
        {
            Console.Write("Full array:\n=> ");
            int positiveElementCount = 0;
            foreach (int number in array)
            {
                Console.Write($"{number} ");
                if (number > 0)
                    positiveElementCount++;
            }

            using (StreamWriter sw = File.CreateText(outputFilePath))
            {
                sw.Write(positiveElementCount);
                Console.WriteLine("\nOutput saved to file.");
            }
            Console.WriteLine();
            return positiveElementCount;
        }
    }
}
