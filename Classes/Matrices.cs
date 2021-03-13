using System;
using System.IO;
using System.Reflection;

namespace LabWork_Arrays.Classes
{
    public static class Matrices
    {
        public static void Task1Variant6(string inputFilePath = null)
        {
            if (string.IsNullOrWhiteSpace(inputFilePath))
            {
                inputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Matrices");
                Directory.CreateDirectory(inputFilePath);
                inputFilePath += @"\input.io";
            }

            int[,] array;
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"File at [{inputFilePath}] doesn't exist! \nSwitching to manual input.");
                array = Task1Variant6ManualInput(inputFilePath);
            }
            else
            {

                int N = 0;
                using (StreamReader sr = File.OpenText(inputFilePath))
                {
                    N = int.Parse(sr.ReadLine());
                }

                if (N <= 0)
                {
                    Console.WriteLine("Failed to get eligible info from file.");
                    Console.WriteLine("Switching to manual input.");
                    array = Task1Variant6ManualInput(inputFilePath);
                }
                else
                {
                    array = GetMatrixAndWriteToFile(N);
                }
            }

            Console.WriteLine("Full Array:");
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    Console.Write(array[x, y].ToString().PadRight(4, ' '));
                }
                Console.WriteLine();
            }
        }

        private static int[,] Task1Variant6ManualInput(string inputFilePath = null)
        {
            if (string.IsNullOrWhiteSpace(inputFilePath))
            {
                inputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Matrices");
                Directory.CreateDirectory(inputFilePath);
                inputFilePath += @"\input.io";
            }

            Console.Write("Enter size of array\n=> ");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
            {
                Console.Write("Invalid input. Try again\n=> ");
            }

            using (StreamWriter sw = File.CreateText(inputFilePath))
            {
                sw.WriteLine(N);
            }

            return GetMatrixAndWriteToFile(N);
        }
        private static int[,] GetMatrixAndWriteToFile(int size, string outputFilePath = null)
        {
            if (string.IsNullOrWhiteSpace(outputFilePath))
            {
                outputFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Matrices");
                Directory.CreateDirectory(outputFilePath);
                outputFilePath += @"\output.io";
            }

            int[,] array = GetSpiralMatrix(size);
            using (StreamWriter sw = File.CreateText(outputFilePath))
            {
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        sw.Write(array[x, y].ToString().PadRight(4, ' '));
                    }
                    sw.WriteLine();
                }
            }
            return array;
        }
        private static int[,] GetSpiralMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("size is less or equal to 0.");
            }

            int[,] array = new int[size, size];

            int currentNumber = 1;
            int xLow = 0;
            int yLow = 0;
            int xTop = size - 1;
            int yTop = size - 1;

            while (true)
            {
                for (int x = xLow; x <= xTop; x++)
                {
                    array[yLow, x] = currentNumber;
                    if (currentNumber < size * size)
                    {
                        currentNumber++;
                    }
                    else
                    {
                        return array;
                    }
                }

                yLow++;
                for (int y = yLow; y <= yTop; y++)
                {
                    array[y, xTop] = currentNumber;
                    if (currentNumber < size * size)
                    {
                        currentNumber++;
                    }
                    else
                    {
                        return array;
                    }
                }

                xTop--;
                for (int x = xTop; x >= xLow; x--)
                {
                    array[yTop, x] = currentNumber;
                    if (currentNumber < size * size)
                    {
                        currentNumber++;
                    }
                    else
                    {
                        return array;
                    }
                }

                yTop--;
                for (int y = yTop; y >= yLow; y--)
                {
                    array[y, xLow] = currentNumber;
                    if (currentNumber < size * size)
                    {
                        currentNumber++;
                    }
                    else
                    {
                        return array;
                    }
                }

                xLow++;
            }
        }
    }
}
