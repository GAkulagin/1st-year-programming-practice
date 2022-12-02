using System;
using System.IO;

namespace Task_1
{
    class Circle
    {
        private int radius;
        private int score;
        private double xCord;
        private double yCord;

        public int Radius
        {
            get { return radius; }
        }
        public int Score
        {
            get { return score; }
        }
        public double XCord
        {
            get { return xCord; }
            set { xCord = value; }
        }
        public double YCord
        {
            get { return yCord; }
            set { yCord = value; }
        }

        public Circle()
        {
            radius = 0;
            score = 0;
            xCord = 0;
            yCord = 0;
        }

        public Circle(int r, int s, double x, double y)
        {
            radius = r;
            score = s;
            xCord = x;
            yCord = y;
        }

        public override string ToString()
        {
            return radius.ToString() + " " + score.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Circle[] array = GetData();

            if (array == null) return;

            double[] yCordArray = new double[array.Length];

            for(int i = 0; i < array.Length; i++)
            {
                array[i].YCord = array[i].Radius;
                double inList = Array.Find(yCordArray, item => item == array[i].YCord);
                while (inList != 0)
                {
                    array[i].YCord -= 0.01;
                    inList = Array.Find(yCordArray, item => item == array[i].YCord);
                }

                yCordArray[i] = array[i].YCord;
            }

            Output(array);
            Console.WriteLine("DONE");
        }


        static Circle[] GetData()
        {
            string str;
            char[] separators = { ' ' , '\n'};
            Circle[] array = null;

            using (StreamReader reader = new StreamReader("INPUT.TXT"))
            {
                str = reader.ReadLine();

                if(str == null)
                {
                    Console.WriteLine("Входной файл пуст");
                    return null;
                }

                bool check = int.TryParse(str, out int size);

                str = reader.ReadToEnd();
                string[] temp = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if(!check || temp.Length != size * 2)
                {
                    Console.WriteLine("Размер массива введен неверно");
                    return null;
                }

                if (size == 0)
                {
                    Console.WriteLine("Пустой массив");
                    return null;
                }

                foreach(string s in temp)
                {
                    bool isDigit = int.TryParse(s, out int value);
                    if (!isDigit || value <= 0)
                    {
                        Console.WriteLine("Элементы массива введены неверно");
                        return null;
                    }
                }

                array = new Circle[size];
                int count = 0;

                for(int i = 0; i < size; i++)
                     array[i] = new Circle(int.Parse(temp[count++]), int.Parse(temp[count++]), 0, 0);

            }

            return array;
        }

        static void Output(Circle[] array)
        {
            using(StreamWriter writer = new StreamWriter("OUTPUT.TXT"))
            {
                foreach (Circle c in array)
                    writer.WriteLine(c.XCord + " " + c.YCord);
            }
        }
    }
}
