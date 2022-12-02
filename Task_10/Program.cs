using System;
using System.IO;

namespace Task_10
{
        //Полиномы P(x) с целочисленными коэффициентами представлены списками.
        //Каждый элемент списка содержит два информационных поля: показатель степени i переменной x и коэффициент ai при xi.
        //Если в полиноме некоторый коэффициент ai равен нулю, то соответствующий элемент в список не включается.
        //Напишите метод сложения двух полиномов (показатели степени и коэффициенты считываются из текстовых файлов 
        //значения показателей степеней и соответствующих коэффициентов двух полиномов содержатся в двух разных файлах, каждая строка которых содержит два числа:
        //показатель степени и коэффициент)).
        //Результат – полином, представленный новым списком.
        //Выведите в текстовый файл полученные в результате вычислений показатели степеней и коэффициенты результирующего полинома,
        //записанные в элементы списка(по паре чисел в строку)
    public class Program
    {
        static void Main(string[] args)
        {
            // четные эл-ты - степень, нечетные - коэффициент
            string[] firstPolynomString = GetData("Polynomial_1.txt", out int lineCount1);
            string[] secndPolynomString = GetData("Polynomial_2.txt", out int lineCount2);

            if (firstPolynomString.Length != lineCount1*2 || secndPolynomString.Length != lineCount2*2)
            {
                Console.WriteLine("Проверьте правильность ввода данных");
                return;
            }

            // Приведение к int + проверка ввода
            int[] firstpolynomInt = DataToInt(firstPolynomString);
            int[] secndPolynomInt = DataToInt(secndPolynomString);

            if (firstpolynomInt == null || secndPolynomInt == null)
            {
                Console.WriteLine("Проверьте правильность ввода данных");
                return;
            }

            int[,] firstpolynomMatr = GetMatrix(firstpolynomInt);
            int[,] secndPolynomMatr = GetMatrix(secndPolynomInt);

            BDList firstList = new BDList(firstpolynomMatr);
            BDList secndList = new BDList(secndPolynomMatr);

            BDList sumList = firstList.SumOfPolymonials(secndList);

            if(sumList == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }

            sumList.RemoveZeroElements();
            sumList.Print();

            Output(sumList, "Output.txt");
        }


        public static int[] DataToInt(string[] data)
        {
            bool isDigit;
            int[] array = new int[data.Length];

            for(int i = 0; i < data.Length; i++)
            {
                isDigit = int.TryParse(data[i], out int value);
                if (!isDigit) return null;
                array[i] = value;
            }

            return array;
        }

        public static int[,] GetMatrix(int[] data)
        {
            int[,] matrix = new int[2, data.Length / 2];
            int i = 0;
            int j = 0;

            while(i < data.Length)
            {
                matrix[0, j] = data[i];
                i++;
                matrix[1, j] = data[i];
                i++;
                j++;
            }

            return matrix;
        }

        public static string[] GetData(string fileName, out int lineCount)
        {
            string str = "";
            char[] separator = { ' ' };

            lineCount = 0;

            using (StreamReader reader = new StreamReader(fileName))
            {
                while(reader.Peek() >= 0)
                {
                    str += reader.ReadLine() + " ";
                    lineCount++;
                }
            }

            return str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void Output(BDList list, string fileName)
        {
            using(StreamWriter writer = new StreamWriter(fileName))
            {
                BDPoint point = list.Beg;

                while(point != null)
                {
                    writer.Write(point.ToString());
                    point = point.next;
                }
            }
        }
    }
}
