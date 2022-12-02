using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 1;
            do
            {
                //choice = int.Parse(Console.ReadLine());

                double x = InputDouble("Введите координату x");
                double y = InputDouble("Введите координату y");

                if ((y <= 1 && y >= -2) && (x >= -1 && x <= 1))
                {
                    if ((x >= 0 && x - y < 0) || (x < 0 && x + y > 0))
                        Console.WriteLine("Точка не принадлежит указанной области");
                    else Console.WriteLine("Точка принадлежит указанной области");
                }
                else Console.WriteLine("Точка не принадлежит указанной области");

            } while (choice != 0);
        }


        static double InputDouble(string message)
        {
            double value;
            bool check;

            do
            {
                Console.WriteLine(message);

                check = double.TryParse(Console.ReadLine(), out value);
                if (!check) Console.WriteLine("Неверный ввод данных");

            } while (!check);

            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }       
    }
}
