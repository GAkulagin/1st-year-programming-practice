using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Task_8
{
    // Полуэйлеров граф задан списком вершин и ребер. Найти в нем какую-либо эйлерову цепь
    // Список вершин и ребер - это список степеней второго порядка
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> graph = GetGraph("Input.txt");
            if(graph == null)
            {
                Console.WriteLine("Неверный ввод данных");
                return;
            }
            if(graph.Count == 0)
            {
                Console.WriteLine("Входной файл пуст");
                return;
            }

            bool check = CheckData(graph);
            if (!check)
            {
                Console.WriteLine("Неверный ввод данных! Проверьте содержимое входного файла");
                return;
            }

            PrintGraph(graph);

            check = IsHalfEulerian(graph);
            if (!check)
            {
                Console.WriteLine("Граф не является полуэйлеровым!");
                return;
            }

            List<int> path = GetPath(graph);

            PrintPath(path);
        }


        static bool CheckData(List<List<int>> graph)
        {

            if (graph == null) return false;

            for (int i = 0; i < graph.Count; i++)
            {
                for (int j = 0; j < graph[i].Count; j++)
                {
                    // число смежных вершин <= N-1
                    if (graph[i].Count >= graph.Count) return false;
                    // значение элемента
                    if (graph[i][j] <= 0 || graph[i][j] > graph.Count) return false;
                    // смежность вершины с собой
                    if (graph[i][j] == i + 1) return false;
                    // повторяющиеся вершины
                    List<int> temp = graph[i].FindAll(node => node == graph[i][j]);
                    if (temp.Count > 1) return false;
                    // "лишние" связи вершин
                    if (!graph[graph[i][j] - 1].Contains(i + 1)) return false;
                }
            }

            return true;
        }

        static bool IsHalfEulerian(List<List<int>> graph)
        {
            int oddDegCount = 0;

            foreach (List<int> list in graph)
                if (list.Count % 2 != 0) oddDegCount++;

            return oddDegCount == 2;
        }

        static List<List<int>> GetGraph(string fileName)
        {
            List<List<int>> graph = new List<List<int>>();          

            using (StreamReader reader = new StreamReader(fileName))
            {
                while (reader.Peek() >= 0)
                {
                    string str = reader.ReadLine();
                    List<int> list = GetNodesList(str);

                    if (list == null) return null;

                    graph.Add(list);
                }
            }

            return graph;
        }

        static List<int> GetNodesList(string str)
        {
            char[] separator = { ' ' };
            List<int> nodes = new List<int>();
            string[] mas = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in mas)
            {
                bool isDigit = int.TryParse(item, out int value);

                if (!isDigit) return null;

                nodes.Add(value);
            }

            return nodes;
        }      

        static List<int> GetPath(List<List<int>> graph)
        {
            // Эйлерова цепь
            List<int> path = new List<int>();

            List<int> currentNode = graph[0];
            path.Add(1);

            while(currentNode.Count > 0)
            {
                int temp = currentNode[0];     // смежная вершина, первая в списке
                currentNode.RemoveAt(0);       // удаляем temp из списка
                graph[temp - 1].Remove(graph.IndexOf(currentNode) + 1);      // удаляем вершину из списка смежных с temp
                path.Add(temp);
                currentNode = graph[temp - 1];
            }

            return path;
        }

        static void PrintGraph(List<List<int>> graph)
        {
            Console.WriteLine("Смежность вершин графа:");

            for(int i = 0; i < graph.Count; i++)
            {
                Console.Write($"Вершина {i + 1}: ");

                for (int j = 0; j < graph[i].Count; j++)
                    Console.Write(graph[i][j] + " ");

                Console.WriteLine();
            }
        }

        static void PrintPath(List<int> path)
        {
            Console.WriteLine("Эйлерова цепь: ");
            foreach (int item in path) Console.Write(item + " ");
            Console.WriteLine();
        }

        //// Генератор тестов
        //static List<List<int>> CreateGraph(int nodeCount)
        //{
        //    List<int> degreeList = GetDegreeList(nodeCount);
        //    Random rand = new Random();
        //    List<List<int>> graph = new List<List<int>>();
        //    int start = 1;

        //    for (int i = 0; i < nodeCount; i++)
        //    {
        //        List<int> list = new List<int>(degreeList[i]);
        //        graph.Add(list);
        //    }

        //    for (int i = 0; i < nodeCount; i++)
        //    {
        //        List<int> choiceList = GetChoiceList(start, nodeCount);
        //        choiceList.RemoveAt(i);  // Исключить текущую вершинy

        //        foreach (int node in graph[i])  // Исключить смежные вершины
        //            choiceList.Remove(node);

        //        while (graph[i].Count <= degreeList[i])
        //        {
        //            int index = rand.Next(0, choiceList.Count);
        //            graph[i].Add(choiceList[index]);
        //            graph[index].Add(i + 1);
        //            choiceList.RemoveAt(index);  // Исключить новую вершину
        //        }

        //        start++;
        //    }

        //    return graph;
        //}

        //static List<int> GetDegreeList(int size)
        //{
        //    List<int> odd = new List<int>(); // нечетные
        //    List<int> even = new List<int>(); // четные
        //    Random rand = new Random();
        //    List<int> list = new List<int>();
        //    int i = 1;

        //    while (i < size)
        //    {
        //        odd.Add(i);
        //        i += 2;
        //    }
        //    i = 2;
        //    while (i < size)
        //    {
        //        even.Add(i);
        //        i += 2;
        //    }

        //    list.Add(odd[rand.Next(0, odd.Count)]);
        //    Thread.Sleep(100);
        //    list.Add(odd[rand.Next(0, odd.Count)]);

        //    for (int j = 2; j < size; j++)
        //    {
        //        list.Add(even[rand.Next(0, even.Count)]);
        //        Thread.Sleep(100);
        //    }

        //    return list;
        //}

        //static List<int> GetChoiceList(int start, int nodeCount)
        //{
        //    List<int> list = new List<int>();

        //    for (int i = start; i <= nodeCount; i++) // начать с 1
        //        list.Add(i);

        //    return list;
        //}
    }
}

