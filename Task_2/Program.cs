using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mas = GetData();
            int[] array;

            if (mas.Length == 0)
            {
                Console.WriteLine("Входной файл пуст");
                return;
            }

            bool isDigit = int.TryParse(mas[0], out int size);
            if (isDigit && size > 0) array = new int[size];
            else
            {
                Console.WriteLine("Размер массива введен неверно");
                return;
            }

            if (mas.Length == 1)
            {
                Console.WriteLine("Последовательность не введена");
                return;
            }

            for (int i = 1; i <= size; i++)
            {
                isDigit = int.TryParse(mas[i], out int element);
                if (isDigit) array[i - 1] = element;
                else
                {
                    Console.WriteLine("Элементы массива введены неверно");
                    return;
                }
            }

            int result = GetMaxSequenceLength(array);

            Output(result);

            Console.WriteLine("DONE");
        }

        static string[] GetData()
        {
            string str;
            using (StreamReader reader = new StreamReader("INPUT.TXT"))
            {
                str = reader.ReadToEnd();
            }

            char[] separators = { ' ', '\n' };

            return str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        static int GetMaxSequenceLength(int[] array)
        {
            int[] temp = new int[array.Length];

            for (int i = 0; i < array.Length; ++i)
            {
                temp[i] = 1;
                for (int j = 0; j < i; ++j)
                    if (array[j] < array[i])
                        temp[i] = Math.Max(temp[i], 1 + temp[j]);
            }

            int result = temp[0];
            foreach (int item in temp)
                result = Math.Max(result, item);

            return result;
        }

        static void Output(int result)
        {
            using (StreamWriter writer = new StreamWriter("OUTPUT.TXT"))
            {
                writer.WriteLine(result);
            }
        }
    }
}
