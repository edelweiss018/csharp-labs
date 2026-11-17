

using System;

class Program
{
    static void PrintMatrix(int[,] m)
    {
        Console.WriteLine("Матрица:");

        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                Console.Write($"{m[i, j],5}");
            }
            Console.WriteLine();
        }
    }

    static int[] FindColumnMax(int[,] m)
    {
        int rows = m.GetLength(0);
        int cols = m.GetLength(1);

        int[] B = new int[cols];

        for (int j = 0; j < cols; j++)
        {
            int max = m[0, j];

            for (int i = 1; i < rows; i++)
            {
                if (m[i, j] > max)
                {
                    max = m[i, j];
                }
            }

            B[j] = max;
        }

        return B;
    }

    static void Main()
    {
        int nomer = 2;
        int n = 5;

        int[,] matrix = new int[n, n];

        Random rnd = new Random(nomer);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rnd.Next(-10, 11);
            }
        }

        PrintMatrix(matrix);

        int[] B = FindColumnMax(matrix);

        Console.WriteLine("\nӘр бағандағы ең үлкен элементтер:");

        for (int j = 0; j < B.Length; j++)
        {
            Console.WriteLine($"B[{j}] = {B[j]}");
        }
    }
}
