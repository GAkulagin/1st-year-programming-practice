using System;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = InputDouble(0, "Введите первый член последовательности");
            double second = InputDouble(0, "Введите второй член последовательности");
            double third = InputDouble(0, "Введите третий член последовательности");
            double value = InputDouble(0, "Введите число M, к которому стремится последовательность");
            int number = 1;
            double result = 0.0;

            while(result < value)
            {
                result = GetElement(first, second, third, number);

                if (result <= value)
                    Console.WriteLine(String.Format("{0, 3})  {1}", number, Math.Round(result, 4, MidpointRounding.AwayFromZero)));

                number++;
            }

            if (result == value) Console.WriteLine("Число М равно последнему члену последовательности");
            else Console.WriteLine("Число М не равно последнему члену последовательности");
        }

        static double InputDouble(int leftBorder, string message)
        {
            double value;
            bool checkValue;

            do
            {
                Console.WriteLine(message);
                checkValue = double.TryParse(Console.ReadLine(), out value);

                if (!checkValue) Console.WriteLine("Неверный ввод данных");
                else if (value <= leftBorder)
                {
                    Console.WriteLine("Неверный ввод данных");
                    checkValue = false;
                }
            } while (!checkValue);

            return value;
        }

        static double GetElement(double first, double second, double third, int number)
        {
            if (number == 1) return first;
            if (number == 2) return second;
            if (number == 3) return third;

            else return GetElement(first, second, third, number - 1) / 2.0 + GetElement(first, second, third, number - 2) / 2.0 + GetElement(first, second, third, number - 3) / 2.0;
        }
    }
}
