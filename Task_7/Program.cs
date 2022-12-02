using System;

namespace Task_7
{
    // Генерация и вывод всех размещений с повторениями из N эл-тов по К
    // Число размещений A = N^K
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Генерация всех комбинаций десятичных цифр с повторениями");
            Console.WriteLine("Формула: A = N^K");
            int N = InputInteger(1, 10, "Введите число N");
            int K = InputInteger(1, 10, "Введите число K");
            Console.WriteLine();
            int[] array = new int[K];

            Output(array);

            while (!AllEqual(array, N - 1)) 
            {
                array[K - 1]++;

                for (int i = K - 1; i >= 1; i--)
                {
                    if (array[i] == N)
                    {
                        array[i - 1]++;
                        array[i] = 0;
                    }
                }
                Output(array);
            }
        }

        static bool AllEqual(int[] array, int value)
        {
            foreach (int element in array)
                if (element != value) return false;

            return true;
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

        static void Output(int[] array)
        {
            foreach (int element in array)
                Console.Write(element);
            Console.WriteLine();
        }
    }
}
