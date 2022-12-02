using System;

////В программе построен циклический список. 
//Напишите метод (рекурсивный и нерекурсивный варианты) создания нового списка, включающего элементы, 
//    содержащие те же значения в информационных полях, что и элементы исходного списка, но в обратном порядке.

namespace Task_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Изначальный список:");
            BDList<int> list = new BDList<int>(1);
            if(list == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }
            list.Print();
            Console.WriteLine();

            Console.WriteLine("Нерекурсивный метод");
            Console.WriteLine("Перевернутый список:");
            BDList<int> reverseList = list.GetReverseList();
            reverseList.Print();
            Console.WriteLine();

            Console.WriteLine("Pекурсивный метод");
            BDList<int> listReverse = new BDList<int>();
            listReverse.GetReverseList(list.End, list.Length);
            listReverse.Print();
            Console.WriteLine();
        }
    }
}
