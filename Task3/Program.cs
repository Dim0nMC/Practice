

using System;

namespace Task3
{
    internal class Program
    {   
        public static string PrintArray(int[] selectionSorted)
        {
            string s = "[";
            foreach(var item in selectionSorted)
            {
                s += " " + item + ",";
            }
            s+= "]";
            return s;
        }
        static void Main(string[] args)
        {
            static int Comparison(int x, int y)
            {
                return (x - y);
            }


            int[] arr = { -1, 5, 8, -8, 10, 22 };

            Console.WriteLine("Insertion sorted");
            var insertionSorted = arr.Sort(ExtensionsSort.SortingMode.Ascending, ExtensionsSort.Algorithm.InsertionSort, MyComparer.Instance);
            Console.WriteLine(PrintArray(insertionSorted));

            Console.WriteLine("Selection sorted");
            var selectionSorted = arr.Sort(ExtensionsSort.SortingMode.Ascending, ExtensionsSort.Algorithm.SelectionSort);
            Console.WriteLine(PrintArray(selectionSorted));
            
            Console.WriteLine("Heap sorted");
            var heapSorted = arr.Sort(ExtensionsSort.SortingMode.Ascending, ExtensionsSort.Algorithm.HeapSort, Comparison);
            Console.WriteLine(PrintArray(heapSorted));

            Console.WriteLine("Quick sorted");
            var quickSorted = arr.Sort(ExtensionsSort.SortingMode.Ascending, ExtensionsSort.Algorithm.QuickSort);
            Console.WriteLine(PrintArray(quickSorted));

            Console.WriteLine("Merge sorted");
            var mergeSorted = arr.Sort(ExtensionsSort.SortingMode.Ascending, ExtensionsSort.Algorithm.MergeSort, new MyComparer());
            Console.WriteLine(PrintArray(mergeSorted));
                     

        }
    }
}
