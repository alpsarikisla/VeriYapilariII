using CustomTypes;
using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.Queue;
using DataStructures.Stack;
using DataStructures.Tree.BST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps
{
    public static class Apps
    {

        private static void CustomTypesExamples()
        {
            #region CustomTypeStudent
            //var student = new Student(10, "Ahmet", 3.40);

            //Console.WriteLine(student);
            #endregion

            #region CustomTypeWithArray
            var arr = new Student[]
            {
                new Student(15,"Mehmet",2.45),
                new Student(10,"Ahmet",3.40),
                new Student(85,"Filiz",1.30),
                new Student(65,"Can",2.65),
                new Student(75,"Mete",2.40),
                new Student(90,"Ömer",3.10),
                new Student(12,"Fatma",1.45),
                new Student(14,"Merve",3.80),
                new Student(18,"Semih",2.80),
            };

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------Array--------");

            var newArr = new DataStructures.Array.Array<Student>(arr);
            newArr.Add(new Student(22, "Aslı", 3.90));

            foreach (var item in newArr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----SinglyLinked<Student>------");

            var linkedList = new DataStructures.LinkedList.SinglyLinkedList.SinglyLinkedList<Student>(newArr);
            linkedList.AddAfter(linkedList.Head,
                new Student(99, "Yiğit", 4.00));

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----BST<Student>------");

            var bst = new DataStructures.Tree.BST.BST<Student>(linkedList);

            foreach (var item in bst)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----MinHEAP<Student>------");

            var heap = new DataStructures.Heap.MinHeap<Student>(bst);

            foreach (var item in heap)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----MaxHEAP<Student>------");

            var maxHeap = new DataStructures.Heap.BinaryHeap<Student>(DataStructures.Shared.SortDirection.Descending, bst);

            foreach (var item in maxHeap)
            {
                Console.WriteLine(maxHeap.DeleteMinMax());
            }

            Console.WriteLine("-----BubbleSort<Student>------");

            DataStructures.SortingAlgorithms.BubbleSort.Sort<Student>(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----InsentionSort<Student>------");

            DataStructures.SortingAlgorithms.InsertionSort.Sort<Student>(arr, DataStructures.Shared.SortDirection.Descending);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            #endregion
        }
        private static void DisjointSetApp01AyrıkSetler()
        {
            var disjointSet = new DataStructures
                            .Set
                            .DisjointSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });
            disjointSet.Union(5, 6);
            disjointSet.Union(1, 2);
            disjointSet.Union(0, 2);

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Find({i}) = {disjointSet.FindSet(i)}");
            }

            Console.ReadKey();
        }
        private static void DoublyLinkedListApp01()
        {
            // Liste başına,arasına ve sonuna ekleme
            var list = new DoublyLinkedList<int>();
            list.AddFirst(12);
            list.AddFirst(23);
            // 23 12
            list.AddLast(44);
            list.AddLast(55);
            // 23 12 44 55 
            list.AddAfter(list.Head.Next, new DoublyLinkedListNode<int>(13));
            // 23 12 13 44 55

            // Dolaşma
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        private static void DoublyLinkedListApp02()
        {
            // Veri yapılarını IEnumerator ile yazdırma
            var list = new DoublyLinkedList<char>(new char[] { 'x', 'y', 'z' });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void DoublyLinkedListApp03()
        {
            //// Liste başını kaldırma
            //var list = new DoublyLinkedList<char>(new char[] { 'x', 'y', 'z','a','b' });

            //Console.WriteLine($"{list.RemoveFirst()} has been removed from list");
            //// Liste sonunu silme
            //Console.WriteLine($"{list.RemoveLast()} has been removed from list");

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            // Aradaki elemanı silme
            var list = new DoublyLinkedList<int>(new int[] { 23, 44, 55, 61 });
            list.Remove(55);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void GraphApp01Çizge()
        {
            #region Graph Tanımlama
            /*
            var graph = new DataStructures.Graph.AdjancencySet.Graph<char>(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' });
            graph.AddEdge('a', 'b');
            graph.AddEdge('a', 'd');
            graph.AddEdge('c', 'd');
            graph.AddEdge('c', 'e');
            graph.AddEdge('d', 'e');
            graph.AddEdge('e', 'f');
            graph.AddEdge('f', 'g');

            Console.WriteLine("Is there an edge between A and B ? {0}",
                graph.HasEdge('a', 'b') ? "Yes." : "No!");
            Console.WriteLine("Is there an edge between B and A ? {0}",
                graph.HasEdge('a', 'b') ? "Yes." : "No!");
            Console.WriteLine("Is there an edge between B and D ? {0}",
                graph.HasEdge('b', 'd') ? "Yes." : "No!");
            Console.WriteLine("Is there an edge between D and B ? {0}",
                graph.HasEdge('d', 'b') ? "Yes." : "No!");
            Console.WriteLine();

            foreach (var key in graph)
            {
                Console.WriteLine(key);
                foreach (var vertex in graph.GetVertex(key).Edges)
                {
                    Console.WriteLine("   {0}",vertex);
                }
               
            }
            Console.WriteLine($"Number of vertex in graph: {graph.Count}");
            */

            #endregion

            #region WeightedGraph
            //var graph = new DataStructures
            //    .Graph
            //    .AdjancencySet
            //    .WeightedGraph<char, double>(new char[] { 'A', 'B', 'C', 'D' });

            //graph.AddEdge('A', 'B', 1.2);
            //graph.AddEdge('A', 'D', 2.3);
            //graph.AddEdge('D', 'C', 5.5);

            //Console.WriteLine("Is there an edge between A and B? {0}",
            //    graph.HasEdge('A', 'B') ? "Yes." : "No!");
            //Console.WriteLine("Is there an edge between B and A? {0}",
            //    graph.HasEdge('B', 'A') ? "Yes." : "No!");

            //foreach (char vertex in graph)
            //{
            //    Console.WriteLine(vertex);
            //    foreach (char key in graph.GetVertex(vertex))
            //    {
            //        var node = graph.GetVertex(key);
            //        Console.WriteLine($"  {vertex} - " +
            //            $"{node.GetEdge(graph.GetVertex(vertex)).Weight<double>()} - " +
            //            $"{key}");
            //    }
            //}
            //Console.WriteLine($"Number of vertex in graph: {graph.Count}");

            #endregion

            #region DiGraph
            //var graph = new DataStructures
            //    .Graph
            //    .AdjancencySet
            //    .DiGraph<char>(new char[] { 'A', 'B', 'C', 'D', 'E' });

            //graph.AddEdge('B', 'A');
            //graph.AddEdge('A', 'D');
            //graph.AddEdge('D', 'E');
            //graph.AddEdge('C', 'D');
            //graph.AddEdge('C', 'E');
            //graph.AddEdge('C', 'A');
            //graph.AddEdge('C', 'B');

            //Console.WriteLine("Is there an edge between A and B? {0} ", graph.HasEdge('A', 'B') ? "Yes." : "No!");
            //Console.WriteLine("Is there an edge between B and A? {0} ", graph.HasEdge('B', 'A') ? "Yes." : "No!");
            //Console.WriteLine();
            //graph.RemoveVertex('C'); // Silme işlemi

            //foreach (var key in graph)
            //{
            //    Console.WriteLine(key);
            //    foreach (var item in graph.GetVertex(key))
            //    {
            //        Console.WriteLine($"   {item}");
            //    }
            //}
            //Console.WriteLine();
            //Console.WriteLine($"Number of vertex in graph: {graph.Count} ");

            #endregion

            #region WeightedDiGraph
            //var graph = new DataStructures
            //    .Graph
            //    .AdjancencySet
            //    .WeightedDiGraph<char,int>(new char[] { 'A', 'B', 'C', 'D', 'E' });

            //graph.AddEdge('A', 'C',12);
            //graph.AddEdge('A', 'D',60);
            //graph.AddEdge('B', 'A',10);
            //graph.AddEdge('C', 'D',32);
            //graph.AddEdge('C', 'B',20);
            //graph.AddEdge('E', 'A',7);

            //Console.WriteLine("Is there an edge between A and B? {0} ", graph.HasEdge('A', 'B') ? "Yes." : "No!");
            //Console.WriteLine("Is there an edge between B and A? {0} ", graph.HasEdge('B', 'A') ? "Yes." : "No!");
            //Console.WriteLine();

            //foreach (var vertexKey in graph)
            //{
            //    Console.WriteLine(vertexKey);
            //    foreach (char key in graph.GetVertex(vertexKey))
            //    {
            //        var nodeU = graph.GetVertex(vertexKey);
            //        var NodeV = graph.GetVertex(key);
            //        var w = nodeU.GetEdge(NodeV).Weight<int>();

            //        Console.WriteLine($"   {vertexKey} - " +
            //            $"({w}) - " +
            //            $"*{key}*");
            //    }
            //}
            //Console.WriteLine();
            //Console.WriteLine($"Number of vertex in graph: {graph.Count} ");


            #endregion

            #region DepthFirst
            //var graph = new DataStructures
            //    .Graph
            //    .AdjancencySet
            //    .Graph<int>();

            //for (int i = 0; i <= 11; i++)
            //{
            //    graph.AddVertex(i);
            //}

            //graph.AddEdge(0,1);
            //graph.AddEdge(1,4);
            //graph.AddEdge(0,4);
            //graph.AddEdge(0,2);
            //graph.AddEdge(2,5);
            //graph.AddEdge(2,10);
            //graph.AddEdge(10,11);
            //graph.AddEdge(11,9);
            //graph.AddEdge(2,9);
            //graph.AddEdge(5, 7);
            //graph.AddEdge(7, 8);
            //graph.AddEdge(5, 8);
            //graph.AddEdge(5, 6);

            //var algoritm = new DataStructures.Graph.Search.DepthFirst<int>();

            //Console.WriteLine("{0}", algoritm.Find(graph,5) ? "Yes." : "No!");


            #endregion

            #region BreadthFirst
            //var graph = new DataStructures.Graph.AdjancencySet.Graph<int>();

            //for (int i = 0; i < 12; i++)
            //{
            //    graph.AddVertex(i);
            //}

            //graph.AddEdge(0, 1);
            //graph.AddEdge(1, 4);
            //graph.AddEdge(0, 4);
            //graph.AddEdge(0, 2);
            //graph.AddEdge(2, 5);
            //graph.AddEdge(2, 10);
            //graph.AddEdge(10, 11);
            //graph.AddEdge(11, 9);
            //graph.AddEdge(2, 9);
            //graph.AddEdge(5, 7);
            //graph.AddEdge(7, 8);
            //graph.AddEdge(5, 8);
            //graph.AddEdge(5, 6);

            //var algoritm = new DataStructures.Graph.Search.BreadthFirst<int>();

            //Console.WriteLine(algoritm.Find(graph,5) ? "Yes." : "No!");

            #endregion

            #region Prim's Algoritm
            //var graph = new DataStructures.Graph.AdjancencySet.WeightedGraph<int, int>();

            //for (int i = 0; i < 11; i++)
            //{
            //    graph.AddVertex(i);
            //}

            //graph.AddEdge(0, 1, 4);
            //graph.AddEdge(0, 7, 8);
            //graph.AddEdge(1, 7, 11);
            //graph.AddEdge(1, 2, 8);
            //graph.AddEdge(7, 8, 7);
            //graph.AddEdge(7, 6, 1);
            //graph.AddEdge(6, 8, 6);
            //graph.AddEdge(2, 8, 2);
            //graph.AddEdge(2, 3, 7);
            //graph.AddEdge(2, 5, 4);
            //graph.AddEdge(6, 5, 2);
            //graph.AddEdge(3, 5, 14);
            //graph.AddEdge(3, 4, 9);
            //graph.AddEdge(5, 4, 10);

            //var algoritm = new DataStructures.Graph.MinimumSpanning_Tree.Prims<int, int>();
            //algoritm.FindMinimumSpanningTree(graph).ForEach(edge => Console.WriteLine(edge));


            #endregion

            #region Kruskal's Algoritm
            // Graph oluştur
            var graph = new DataStructures.Graph.AdjancencySet.WeightedGraph<int, int>();

            // Vertexleri ekle
            for (int i = 0; i < 11; i++)
            {
                graph.AddVertex(i);
            }

            // Kenarları ekle
            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 7, 8);
            graph.AddEdge(1, 7, 11);
            graph.AddEdge(1, 2, 8);
            graph.AddEdge(7, 8, 7);
            graph.AddEdge(7, 6, 1);
            graph.AddEdge(6, 8, 6);
            graph.AddEdge(2, 8, 2);
            graph.AddEdge(2, 3, 7);
            graph.AddEdge(2, 5, 4);
            graph.AddEdge(6, 5, 2);
            graph.AddEdge(3, 5, 14);
            graph.AddEdge(3, 4, 9);
            graph.AddEdge(5, 4, 10);

            var algoritm = new DataStructures.Graph.MinimumSpanning_Tree.Kruskals<int, int>();

            algoritm.FindMinimumSpanningTree(graph).ForEach(edge => Console.WriteLine(edge));


            #endregion
        }
        private static void QueueApp01Kuyruk()
        {
            var numbers = new int[] { 10, 20, 30, };
            var q1 = new DataStructures.Queue.Queue<int>();
            var q2 = new DataStructures.Queue.Queue<int>(QueueType.LinkedList);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
                q1.EnQueue(number);
                q2.EnQueue(number);
            }
            Console.WriteLine($"q1 Count:{q1.Count}");
            Console.WriteLine($"q2 Count:{q2.Count}");

            Console.WriteLine($"{q1.DeQueue()} has been removed from q1");
            Console.WriteLine($"{q2.DeQueue()} has been removed from q2");

            Console.WriteLine($"q1 Count:{q1.Count}");
            Console.WriteLine($"q2 Count:{q2.Count}");

            Console.WriteLine($"q1 Peek:{q1.Peek()}");
            Console.WriteLine($"q2 Peek:{q2.Peek()}");
        }
        private static void SinglyLinkedListApp01()
        {
            #region Array
            // Array
            //var arrChar = new char[] { 'b', 't', 'k' };
            //Console.WriteLine(arrChar.Length);

            // ArrayList - Type-safe 
            //var arrObj = new ArrayList();
            //arrObj.Add(10); // !0 değeri kutulanır ve obje haline getirilir
            //arrObj.Add('b');
            //Console.WriteLine(arrObj.Count);

            // Objecden int dönüştürme (unboxing)
            //var c = ((int)arrObj[0] + 20);

            // List<T> - Type güvenliği
            //var arrInt = new List<int>();
            //arrInt.Add(10);
            //arrInt.AddRange(new int[] { 1, 2, 3 }); // Ekleme
            //arrInt.RemoveAt(10); // Değeri silme
            //Console.WriteLine(arrInt.Count);
            //foreach (var item in arrInt) 
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Veri yapıları ile ctor
            //var p1 = new DataStructures.Array.Array<int>(1,2,3,4);
            //var p2 = new int[] {8,9,10,11};
            //var p3 = new List<int>() {5,15,20,25 };
            //var p4 = new ArrayList() { 12, 13, 14 };
            #endregion

            #region Diziye ekleme ve çıkartma
            //var arr = new DataStructures
            //    .Array
            //    .Array<int>();
            //for (int i = 0;i < 8;i++)
            //{
            //    arr.Add(i + 1);
            //    Console.WriteLine($"{i+1} has been added to array");
            //    Console.WriteLine($"{arr.Count}/{arr.Capacity}");
            //}

            //Console.WriteLine();
            //for (int i = arr.Count; i >= 1; i--)
            //{
            //    Console.WriteLine($"{arr.Remove()} has been removed from the array");
            //    Console.WriteLine($"{arr.Count}/{arr.Capacity}");
            //}
            //Console.WriteLine();

            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Ekleme
            //arr.Add(23);
            //arr.Add(55);
            //arr.Add(44);
            //arr.Add(12);
            //arr.Add(34);
            //arr.Remove();

            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("---------");
            //arr.Where(x => x%2==0)
            //    .ToList()
            //    .ForEach(x => Console.WriteLine(x));

            //Console.WriteLine($"{arr.Count}/{arr.Capacity}");
            #endregion

            #region Clone

            //var arr = new DataStructures.Array.Array<int>(1,3,5,7);
            //var crr = (DataStructures.Array.Array<int>)arr.Clone();
            //// 2. yöntem: arr.Clone() as DataStructures.Array.Array<int>;
            //arr.Add(99);

            //// Clone ve normal dizeler klonlama işlemi sonrası yeni eleman eklenecek ise otomatik olarak işlem yapmaz manuel yapılması gereklidir.

            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-3}");
            //}
            //Console.WriteLine($"{arr.Count}/{arr.Capacity}");
            //foreach (var item in crr)
            //{
            //    Console.Write($"{item,-3}");
            //}
            //Console.WriteLine($"{arr.Count}/{arr.Capacity}");


            //Console.ReadKey();
            #endregion

            #region Array Sınıfı Genişletme Metodu
            //var arr = new DataStructures.Array.Array<int>(3,5,7,10);
            //var list = new List<int>() {13,23,44,55 };

            //var dictionary = new Dictionary<int, string>();
            //var hashSet = new HashSet<int>();

            #endregion

            #region SinglyLinkedList
            //var linkedlist = new SinglyLinkedList<int>();
            //linkedlist.AddFirst(1);
            //linkedlist.AddFirst(2);
            //linkedlist.AddFirst(3);
            //// 3 2 1 O(1)
            //linkedlist.AddLast(4);
            //linkedlist.AddLast(5);
            //// 3 2 1 4 5 O(n)

            //linkedlist.AddAfter(linkedlist.Head.Next, 32);
            //linkedlist.AddAfter(linkedlist.Head.Next.Next, 33);
            //// 3 2 32 33 1 4 5 O(n)

            //foreach (var item in linkedlist)
            //{
            //    Console.WriteLine(item);
            //}


            // Dolaşma
            //var list = new LinkedList<int>();
            //list.AddFirst(1);
            //list.AddFirst(2);
            //list.AddFirst(3);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in linkedlist)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion
        }
        private static void SinglyLinkedListApp02()
        {
            #region IEnumerable avantajı
            // IEnumerable arayüzü sayesinde tüm veri yapıları kullanılabilir
            //var arr = new char[] { 'a', 'b', 'c', };
            //var list = new List<char>(arr);
            //var clinkedlist = new LinkedList<char>(arr);
            //list.AddRange(new char[] { 'd', 'e', 'f' });

            //var linkedlist = new SinglyLinkedList<char>(list);

            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            //var charset = new List<char>(linkedlist);
            //Console.WriteLine();
            //foreach (var item in charset)
            //{
            //    Console.Write(item + " ");
            //}
            #endregion
        }
        private static void SinglyLinkedListApp03()
        {
            #region Language Integrated Query - LINQ
            //var rnd =  new Random();
            //var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
            //var linkedlist = new SinglyLinkedList<int>(initial);

            //var q = from item in linkedlist
            //        where item%2==1
            //        select item;

            //foreach (var item in q)
            //{
            //    Console.WriteLine(item);
            //}
            //linkedlist.Where(x=> x>5)
            //    .ToList()
            //    .ForEach(x => Console.Write(x + " "));
            #endregion
        }
        private static void SinglyLinkedListApp04()
        {
            #region İlk elemanı kaldırma
            //var rnd = new Random();
            //var initial = Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).ToList();
            //var list = new SinglyLinkedList<int>(initial);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //list.RemoveFirst();
            //Console.WriteLine();
            //foreach (var item in list)
            //{
            //    Console.Write(item);
            //}

            #endregion

            #region Son elemanı kaldırma
            //var rnd = new Random();
            //var initial = Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).ToList();
            //var list = new SinglyLinkedList<int>(initial);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();
            //Console.WriteLine($"{list.RemoveLast()} has been Removed");
            //Console.WriteLine();
            //foreach (var item in list)
            //{
            //    Console.Write(item);
            //}

            #endregion

            #region Ara elemanı kaldırma
            //var list = new SinglyLinkedList<int>(new int[] { 23, 44, 32, 55 });
            //list.Remove(32);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion
        }
        private static void SortingAlgorithms()
        {
            #region SelectionSort
            var arr = new int[] { 16, 23, 44, 12, 55, 40, 6 };
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
            Console.WriteLine();

            DataStructures.SortingAlgorithms.SelectionSort.Sort<int>(arr, DataStructures.Shared.SortDirection.Descending);

            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
            Console.WriteLine();
            DataStructures.SortingAlgorithms.SelectionSort.Sort<int>(arr, DataStructures.Shared.SortDirection.Ascending);

            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            #endregion

            #region BubbleSort
            //var arr = new int[] { 16, 23, 44, 12, 55, 40, 6 };
            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}
            //Console.WriteLine();

            //DataStructures.SortingAlgorithms.BubbleSort.Sort<int>(arr);

            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}

            #endregion

            #region InsentionSort
            //var arr = new int[] { 16, 23, 44, 12, 55, 40, 6 };
            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}

            //DataStructures.SortingAlgorithms.InsertionSort.Sort<int>(arr, DataStructures.Shared.SortDirection.Descending);
            //Console.WriteLine();

            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}

            //DataStructures.SortingAlgorithms.InsertionSort.Sort<int>(arr, DataStructures.Shared.SortDirection.Ascending);
            //Console.WriteLine();
            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}

            #endregion

            #region OuickSort
            //var arr = new int[] { 16, 23, 44, 12, 55, 40, 6 };
            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}

            //DataStructures.SortingAlgorithms.QuickSort.Sort<int>(arr);
            //Console.WriteLine();

            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}

            #endregion

            #region MergeSort
            //var arr = new int[] { 16, 23, 44, 12, 55, 40, 6 };
            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}
            //Console.WriteLine();

            //DataStructures.SortingAlgorithms.MergeSort.Sort<int>(arr);

            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}

            #endregion

            #region HeapSort
            //var arr = new int[] { 16, 23, 44, 12, 55, 40, 6 };
            //foreach (var item in arr)
            //{
            //    Console.Write($"{item,-5}");
            //}

            //Console.WriteLine();

            //var heap = new DataStructures.Heap.MinHeap<int>(arr);
            //foreach (var item in heap)
            //{
            //    Console.Write($"{heap.DeleteMinMax(),-5}");
            //}

            #endregion
        }
        private static void StackApp01Yığın()
        {
            var charset = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var stack1 = new DataStructures.Stack.Stack<char>();
            var stack2 = new DataStructures.Stack.Stack<char>(StackType.LinkedList);

            foreach (var c in charset)
            {
                Console.WriteLine(c);
                stack1.Push(c);
                stack2.Push(c);
            }
            Console.WriteLine("\nPeek");
            Console.WriteLine($"Stack1:{stack1.Peek()}");
            Console.WriteLine($"Stack2:{stack2.Peek()}");

            Console.WriteLine("\nCount");
            Console.WriteLine($"{stack1.Count}");
            Console.WriteLine($"{stack2.Count}");

            Console.WriteLine("\nPop");
            Console.WriteLine($"{stack1.Pop()} has been removed");
            Console.WriteLine($"{stack2.Pop()} has been removed");

            #region PostFixExample
            Console.WriteLine(PostFixExample.Run("231*+9-"));
            #endregion
        }
        private static void TreeApp01()
        {

            #region İkili Ağaç GetEnumerator U.
            var bst = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            foreach (var node in bst)
            {
                Console.WriteLine(node);
            }
            #endregion

            #region Kökten Yapraklara Doğru Olan Yolları Gösterme
            //var bst = new BST<int>(new int[] {23,16,45,3,22,37,99});
            //new BinaryTree<int>().PrintPaths(bst.Root);
            //Console.ReadKey();

            #endregion

            #region İkili Ağaç Yarım ve Tam Düzen
            //var bst = new BST<int>(new int[] {23,16,45,3,22,37,99});
            ////bst.Remove(bst.Root, 37);

            //Console.WriteLine($"Number of Leafs: "+$"{BinaryTree<int>.NumberOfLeafs(bst.Root)}");
            //Console.WriteLine($"Number of full nodes: " + $"{BinaryTree<int>.NumberOfFullNodes(bst.Root)}");
            //Console.WriteLine($"Number of half nodes: " + $"{BinaryTree<int>.NumberOfHalfNodes(bst.Root)}");


            #endregion

            #region Yaprak Sayısı Bulma
            //var bst = new BST<int>(new int[] {23,16,45,3,22,37,99});

            //bst.Remove(bst.Root, 22);
            //Console.WriteLine($"Number of leafs: " + 
            //  $"{BinaryTree<int>.NumberOfLeafs(bst.Root)}");

            #endregion

            #region DeepestNode
            //var bt = new BinaryTree<char>();
            //bt.Root = new Node<char>('F');
            //bt.Root.Left = new Node<char>('A');
            //bt.Root.Right = new Node<char>('T');
            //bt.Root.Left.Left = new Node<char>('D');

            //var list = bt.LevelOrderNonRecursiveTraversal(bt.Root);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine($"Deepest Node: {bt.DeepestNode(bt.Root)}");
            //Console.WriteLine($"Deepest Node: {bt.DeepestNode()}");
            //Console.WriteLine($"Max Depth: {BinaryTree<char>.MaxDepth(bt.Root)}");


            #endregion

            #region MaxDepth - MinDepth
            //var bst = new DataStructures
            //    .Tree
            //    .BST
            //    .BST<byte>(new byte[] { 60,40,70,20,45,65,85,90 });

            //var list = new DataStructures.Tree.BinaryTree.BinaryTree<byte>().InOrder(bst.Root);

            //foreach (var node in list)
            //{
            //    Console.Write($"{node,-3}");
            //}
            //Console.WriteLine();

            //Console.WriteLine($"Min: {bst.FindMin(bst.Root)}");
            //Console.WriteLine($"Max: {bst.FindMax(bst.Root)}");
            //Console.WriteLine($"Depth: {DataStructures.Tree.BinaryTree.BinaryTree<byte>.MaxDepth(bst.Root)}");
            #endregion

            #region BST listesi
            // var BST = new BST<int>(new List<int>() { 23, 16, 45, 3, 22, 37, 99 });

            // var bt = new BinaryTree<int>();
            //bt.InOrder(BST.Root)
            //     .ForEach(Node => Console.Write($"{Node,-3}")) ;
            //Console.WriteLine();
            #endregion

            #region PreOrder(Recursive) - LevelOrder - Inorder
            //bt.ClearList();

            //bt.PreOrder(BST.Root)
            //    .ForEach(Node => Console.Write($"{Node,-3}"));

            //Console.WriteLine();
            //bt.ClearList();
            //bt.PostOrder(BST.Root)
            //     .ForEach(Node => Console.Write($"{Node,-3}"));

            //bt.InOrderNonRecursiveTraversal(BST.Root)
            //    .ForEach(node => Console.Write($"{node,-3}"));
            //Console.WriteLine();

            //bt.PreOrderNonRecursiveTraversal(BST.Root)
            //    .ForEach(node => Console.Write($"{node,-3}"));
            //Console.WriteLine();

            //bt.LevelOrderNonRecursiveTraversal(BST.Root)
            //    .ForEach(node => Console.Write($"{node,-3}"));
            //Console.WriteLine();
            #endregion

            #region Max ve Min değerleri bulma
            //Console.WriteLine($"Minimum value: {BST.FindMin(BST.Root)}");
            //Console.WriteLine($"Maximum value: {BST.FindMax(BST.Root)}");
            #endregion

            #region Direk sayıyı bulma
            //var keyNode = BST.Find(BST.Root,16);
            //Console.WriteLine($"{keyNode.Value} - Left: {keyNode.Left.Value} - Right: {keyNode.Right.Value}");
            #endregion

            #region Remove Metodu
            //Console.WriteLine();
            //BST.Remove(BST.Root, 3);
            //bt.ClearList();
            //bt.InOrder(BST.Root)
            //    .ForEach(Node => Console.Write($"{Node,-3}"));
            #endregion
        }
        private static void ÖncelikliKuyruklarveYığın()
        {
            #region BHeap MinHeap Uygulaması
            //var heap = new DataStructures.Heap.MinHeap<int>(new int[] {4,1,10,8,7,5,9,3,2});
            //Console.WriteLine(heap.DeleteMinMax() + " has been removed");
            //foreach (var item in heap)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();

            #endregion

            #region BHeap MaxHeap Uygulaması
            //var heap = new DataStructures.Heap.MaxHeap<int>(new int[] { 54, 45, 36, 27, 29, 18, 21,99 });
            //foreach (var item in heap)
            //{
            //    Console.Write(item + "  ");
            //}

            #endregion

            #region Paylaşılan Yapılar
            var heap = new DataStructures
                .Heap
                .BinaryHeap<int>(DataStructures.Shared.SortDirection.Descending, new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });
            // .BinaryHeap<int>(DataStructures.Shared.SortDirection.Ascending, new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });


            foreach (var item in heap)
            {
                Console.Write(item + "  ");
            }


            #endregion
        }

    }
}
