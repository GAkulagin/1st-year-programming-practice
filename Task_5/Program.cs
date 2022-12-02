using System;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = InputInteger(1, 100, "Введите размерность матрицы");
            Console.WriteLine("Введите элементы матрицы");
            int[,] matrix = InputMatrix(size);
            bool[] even = new bool[size];

            for (int i = 0; i < size; i++)
                even[i] = true;

            ShowMatrix(matrix);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    if (matrix[i, j] % 2 != 0)
                    {
                        even[i] = false;
                        break;
                    }
            }

            Output(even);
        }

        // Автоматическая генерация
        static int[,] CreateMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = rand.Next(-50, 51);

            return matrix;
        }

        static int InputInteger(int leftBorder, int rightBorder, string message)
        {
            int value;
            bool checkValue;
            do
            {
                Console.WriteLine(message);
                checkValue = int.TryParse(Console.ReadLine(), out value);

                if (!checkValue)
                    Console.WriteLine("Неверный ввод данных");
                else if ((value > rightBorder) || (value < leftBorder))
                {
                    Console.WriteLine("Неверный ввод данных");
                    checkValue = false;
                }

            } while (!checkValue);

            return value;
        }

        static int[,] InputMatrix(int size)
        {
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = InputInteger(-99, 99, "");

            return matrix;
        }

        static void Output(bool[] array)
        {
            string numbers = "";

            for(int i = 0; i < array.Length; i++)
                if (array[i])
                {
                    int index = i + 1;
                    numbers += index + " ";
                }

            if (numbers == "") Console.WriteLine("В матрице нет строк, состоящих только из четных чисел");
            else Console.WriteLine($"Номера строк, содержащих только четные числа: {numbers}");
        }

        static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
