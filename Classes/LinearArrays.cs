using System;
using System.Text.RegularExpressions;
using System.IO;

namespace LabWork_Arrays.Classes
{
    public static class LinearArrays
    {
        public static void Task1Variant6()
        {
            using (FileStream stream = new FileStream())
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

            Console.WriteLine($"Ammount of positive elements in array: {CountPositiveElementsInArray(array)}");
            Console.ReadLine();
        }

        private static int CountPositiveElementsInArray(int[] array)
        {
            Console.Write("Full array:\n=> ");
            int positiveElementCount = 0;
            foreach (int number in array)
            {
                Console.Write($"{number} ");
                if (number > 0)
                    positiveElementCount++;
            }

            Console.WriteLine();
            return positiveElementCount;
        }
    }
}
