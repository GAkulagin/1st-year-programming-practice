using System;

namespace Task_4
{

//    Дано действительное положительное число е.Методом хорд вычислить с точностью е корень уравнения
//    ниже, следом за уравнением f(x) = 0, дополнительно задан отрезок, содержащий корень
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение уравнения x^2 - sin(5x) = 0 методом хорд");

            double accuracy = InputDouble("Введите точность вычисления");
            double xStatic = 0.6;
            double xChangeable = 0.5;
            double xTemp;
            double funcStatic = FunctionValue(xStatic);
            int iteration = 1;

            do
            {
                xTemp = xChangeable;
                xChangeable = xTemp - ((FunctionValue(xTemp) * (xTemp - xStatic)) / (FunctionValue(xTemp) - funcStatic));
                Output(iteration, xChangeable);
                iteration++;

            } while (Math.Abs(xChangeable - xTemp) >= accuracy);

            Console.WriteLine("Вычисление завершено");
        }

        static double FunctionValue(double value)
        {
            return Math.Pow(value, 2) - Math.Sin(5 * value);
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
                else if(value <= 0)
                {
                    Console.WriteLine("Неверный ввод данных");
                    check = false;
                }

            } while (!check);

            return value;
        }

        static void Output(int iteration, double value)
        {
            Console.WriteLine($"Итерация № {iteration}: приближенное значение корня: {value}");
        }
    }
}
