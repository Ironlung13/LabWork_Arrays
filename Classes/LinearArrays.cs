using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LabWork_Arrays.Classes
{
    public static class LinearArrays
    {
        public static void Task1Variant6(string inputFilePath = @"D:\Text Files\EPAM_Arrays\input.io")
        {
            Console.Write("Enter size of array(N <= 50)\n=> ");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N > 50)
            {
                Console.Write("Invalid input. Try again\n=> ");
            }
            int[] array = new int[N];

            Console.Write("Enter your numbers (integers) in a single line:\n=> ");
            string input = Console.ReadLine();
            Console.WriteLine();

            string[] tokens = Regex.Split(input, @"(-?[0-9]+[\,\.]?[0-9]+)");

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
                sw.Write("Size of array: ");
                sw.WriteLine(N);

                sw.Write("Array contained: ");
                foreach (var number in array)
                {
                    sw.Write(number + " ");
                }
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
                sw.Write("Positive element count: ");
                sw.Write(positiveElementCount);
            }
            Console.WriteLine();
            return positiveElementCount;
        }
    }
}
