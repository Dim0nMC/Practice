using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class ExtensionsSort
    {
        public enum SortingMode
        {
            Ascending,
            Descending
        }
        public enum Algorithm
        {
            HeapSort,
            InsertionSort,
            QuickSort,
            MergeSort,
            SelectionSort
        }
        private static bool CompareInner<T>(T x, T y, SortingMode sortingMode, IComparer<T> comparer)
        {
            return ((sortingMode == SortingMode.Ascending) & (comparer.Compare(x, y) < 0));
        }

        private static void Swap<T>(T[] a, int i, int j)
        {
            (a[i], a[j]) = (a[j], a[i]);
        }

        public static T[] Sort<T>(this T[] collection, SortingMode sortingMode, Algorithm sortingMethod)
            where T : IComparable<T>
        {
            var comparer = Comparer<T>.Default;
            return collection.Sort(sortingMode, sortingMethod, comparer);
        }
        public static T[] Sort<T>(
        this T[] collection, SortingMode sortingMode, Algorithm sortingMethod, Comparer<T> comparer)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            switch (sortingMethod)
            {
                case Algorithm.InsertionSort:
                    return InsertionSorting(collection, sortingMode, comparer);
                case Algorithm.SelectionSort:
                    return SelectionSorting(collection, sortingMode, comparer);
                case Algorithm.MergeSort:
                    return MergeSorting(collection, sortingMode, comparer);
                case Algorithm.HeapSort:
                    return HeapSorting(collection, sortingMode, comparer);
                default:
                    return QuickSorting(collection, sortingMode, comparer);
            }
        }
        public static T[] Sort<T>(this T[] collection, SortingMode sortingMode, Algorithm sortingMethod, IComparer<T> comparer)
        {
            switch (sortingMethod)
            {
                case Algorithm.InsertionSort:
                    return InsertionSorting(collection, sortingMode, comparer);
                case Algorithm.SelectionSort:
                    return SelectionSorting(collection, sortingMode, comparer);
                case Algorithm.MergeSort:
                    return MergeSorting(collection, sortingMode, comparer);
                case Algorithm.HeapSort:
                    return HeapSorting(collection, sortingMode, comparer);
                default:
                    return QuickSorting(collection, sortingMode, comparer);
            }
        }

        public static T[] Sort<T>(this T[] collection, SortingMode sortingMode, Algorithm sortingMethod, Comparison<T> comparison)
        {
            var comparer = Comparer<T>.Create(comparison);
            return collection.Sort(sortingMode, sortingMethod, comparer);
        }


        private static T[] InsertionSorting<T>(T[] keys, SortingMode sortingMode, IComparer<T> comparer)
        {
            T[] toReturn = new T[keys.Length];
            toReturn[0] = keys[0];

            for (int i = 0; i < keys.Length - 1; i++)
            {
                T t = keys[i + 1];

                int j = i;
                while (j >= 0 && CompareInner(t, toReturn[j], sortingMode, comparer))
                {
                    toReturn[j + 1] = toReturn[j];
                    j--;
                }

                toReturn[j + 1] = t;
            }

            return toReturn;
        }

        
        private static T[] SelectionSorting<T>(T[] keys, SortingMode sortingMode, IComparer<T> comparer)
        {
            T[] toReturn = (T[])keys.Clone();

            for (int i = 0; i < toReturn.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < toReturn.Length; j++)
                {
                    if (CompareInner(toReturn[j], toReturn[min], sortingMode, comparer))
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Swap(toReturn, i, min);
                }
            }
            return toReturn;
        }

        
        private static T[] HeapSorting<T>(T[] keys, SortingMode sortingMode, IComparer<T> comparer)
        {
            
            T[] toReturn = (T[])keys.Clone();

            int n = toReturn.Length;
            for (int i = n >> 1; i >= 1; i--)
            {
                DownHeap(toReturn, i, n, sortingMode, comparer);
            }

            for (int i = n; i > 1; i--)
            {
                Swap(toReturn, 0, i - 1);
                DownHeap(toReturn, 1, i - 1, sortingMode, comparer);
            }

            return toReturn;
        }

        private static void DownHeap<T>(T[] keys, int i, int n, SortingMode sortingMode, IComparer<T> comparer)
        {
            T d = keys[i - 1];
            while (i <= n >> 1)
            {
                int child = 2 * i;
                if (child < n && CompareInner(keys[child - 1], keys[child], sortingMode, comparer))
                {
                    child++;
                }

                if (!CompareInner(d, keys[child - 1], sortingMode, comparer))
                    break;

                keys[i - 1] = keys[child - 1];
                i = child;
            }

            keys[i - 1] = d;
        }

        
        private static T[] QuickSorting<T>
            (T[] keys, SortingMode sortingMode, IComparer<T> comparer)
        {
            T[] toReturn = (T[])keys.Clone();

            QuickSortingInner(toReturn, 0, toReturn.Length - 1, sortingMode, comparer);

            return toReturn;
        }

        private static void QuickSortingInner<T>
            (T[] keys, int leftBound, int rightBound, SortingMode sortingMode, IComparer<T> comparer)
        {
            if (leftBound < rightBound)
            {
                int pivot = Partition(keys, leftBound, rightBound, sortingMode, comparer);
                QuickSortingInner(keys, leftBound, pivot - 1, sortingMode, comparer);
                QuickSortingInner(keys, pivot + 1, rightBound, sortingMode, comparer);
            }
        }

        private static int Partition<T>
            (T[] keys, int leftBound, int rightBound, SortingMode sortingMode, IComparer<T> comparer)
        {
            T pivot = keys[rightBound];
            int i = leftBound - 1;
            for (int j = leftBound; j < rightBound; j++)
            {
                if (CompareInner(keys[j], pivot, sortingMode, comparer))
                {
                    ++i;
                    Swap(keys, i, j);
                }
            }

            Swap(keys, i + 1, rightBound);
            return (i + 1);
        }

        
        private static T[] MergeSorting<T>(T[] keys, SortingMode sortingMode, IComparer<T> comparer)
        {
            T[] toReturn = (T[])keys.Clone();
            if (keys.Length == 1) return toReturn;
            int middle = keys.Length / 2;

            return Merge(MergeSorting(toReturn.Take(middle).ToArray(), sortingMode, comparer),
                MergeSorting(toReturn.Skip(middle).ToArray(), sortingMode, comparer), sortingMode, comparer);
        }

        private static T[] Merge<T>(T[] first, T[] second, SortingMode sortingMode, IComparer<T> comparer)
        {
            int ptr1 = 0, ptr2 = 0;
            T[] merged = new T[first.Length + second.Length];

            for (int i = 0; i < merged.Length; ++i)
            {
                if (ptr1 < first.Length && ptr2 < second.Length)
                {
                    merged[i] = CompareInner(second[ptr2], first[ptr1], sortingMode, comparer) ? second[ptr2++] : first[ptr1++];
                }
                else
                {
                    merged[i] = ptr2 < second.Length ? second[ptr2++] : first[ptr1++];
                }
            }

            return merged;
        }

       

        
    }
}
