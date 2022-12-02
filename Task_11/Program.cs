using System;

namespace Task_11
{
//    Зафиксируем натуральное k и перестановку чисел
//1, ..., k(ее можно задать с помощью последовательности
//натуральных чисел plt ..., pky в которую входит каждое
//из чисел 1, ..., k). При шифровке в исходном тексте к каждой из последовательных групп по k символов применяется
//зафиксированная перестановка.Пусть k = 4 и перестановка
//есть 3. 2, 4, 1. Тогда группа символов slf s2, s3, s4 заменяется на s3, s2, s4, sv Если в последней группе меньше
//четырех символов, то к ней добавляются пробелы.Пользуясь изложенным способом:
//а) зашифровать данный текст;
//б) расшифровать данный текст.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");

            string str = Console.ReadLine();

            int length = InputInteger(3, 10, "Введите размер группы символов (Min - 3, Max - 10)");

            int[] cipher = GetCipher(length);

            Console.WriteLine("Перестановка символов в группе");
            foreach (int item in cipher)
                Console.Write(item + " ");
            Console.WriteLine();

            char[] text = GetText(str, length);

            Encrypt(ref text, cipher);

            Console.WriteLine("Зашифрованный текст:");
            Console.WriteLine(text);

            Decrypt(ref text, cipher);

            Console.WriteLine("Расшифрованный текст: ");
            Console.WriteLine(text);
        }


        static void Decrypt(ref char[] text, int[] cipher)
        {
            char[] temp = new char[cipher.Length];
            int index = 0;

            while (index != text.Length)
            {
                Array.Copy(text, index, temp, 0, cipher.Length);

                ReSwap(ref temp, cipher);  // Теперь в temp - изначальный порядок символов
                Insert(ref text, temp, index);

                index += cipher.Length;
            }
        }

        static void Encrypt(ref char[] text, int[] cipher)
        {
            char[] temp = new char[cipher.Length];
            int index = 0;

            while (index != text.Length)
            {
                Array.Copy(text, index, temp, 0, cipher.Length);

                Swap(ref temp, cipher);
                Insert(ref text, temp, index);

                index += cipher.Length;
            }
        }

        static int[] GetCipher(int length)
        {
            int[] cipher = new int[length];
            int[] priorities = new int[length];
            Random rand = new Random();

            for (int i = 1; i <= length; i++)
            {
                cipher[i - 1] = i;
                priorities[i - 1] = rand.Next(1, (int)Math.Pow(length, 3));
            }

            Array.Sort(priorities, cipher);

            return cipher;
        }

        static char[] GetText(string str, int length)
        {
            int remainder = str.Length % length;

            if (remainder == 0) return str.ToCharArray();

            for (int i = 0; i < length - remainder; i++)
                str += " ";

            return str.ToCharArray();
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

        static void Insert(ref char[] text, char[] temp, int index)
        {
            for(int i = 0; i < temp.Length; i++)
            {
                text[i + index] = temp[i];
            }
        }

        static void ReSwap(ref char[] array, int[] cipher)
        {
            char[] temp = new char[array.Length];

            for (int i = 0; i < cipher.Length; i++)
            {
                temp[cipher[i] - 1] = array[i];
            }

            array = temp;
        }

        static void Swap(ref char[] array, int[] cipher)
        {
            char[] temp = new char[array.Length];

            for(int i = 0; i < cipher.Length; i++)
            {
                temp[i] = array[cipher[i] - 1];
            }

            array = temp;
        }
    }
}
