using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class EnumerableExtensions
    {
        private static void Similarity<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            var tmp = collection.Distinct(comparer);
            if (collection.Count() != collection.Distinct(comparer).Count())
            {
                throw new ArgumentException(nameof(collection));
            }
        }
        public static IEnumerable<IEnumerable<T>> GetCombines<T>(
        this IEnumerable<T> collection, int k, MyComparer<T> comparer)
        where T : IComparable
        {
           collection.Similarity(comparer);
            return k == 0 ? new[] { Array.Empty<T>() } : collection.SelectMany((e, i) => collection.Skip(i).GetCombines(k - 1,comparer).Select(c => (new[] { e }).Concat(c)));
        }

        public static IEnumerable<IEnumerable<T>> GetAllSubstes<T>(
        this IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            collection.Similarity(comparer);
            var ar = collection.ToList();

            var res = new List<List<T>>();

            int size = ar.Count;

            for (int i = 0; i < (1 << size); i++)
            {
                res.Add(new List<T>());
                for (int j = 0; j < size; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        res.Last().Add(ar[j]);
                    }
                }
            }

            return res;

        }

        public static void _GetPermutations<T>(this IEnumerable<T> collection, IList<T> arr,string current="")
        {
            
                if (arr.Count == 0) //если все элементы использованы, выводим на консоль получившуюся строку и возвращаемся
                {
                    Console.WriteLine(current);
                return;
                }
                for (int i = 0; i < arr.Count; i++) //в цикле для каждого элемента прибавляем его к итоговой строке, создаем новый список из оставшихся элементов, и вызываем эту же функцию рекурсивно с новыми параметрами.
                {
                    List<T> lst = new List<T>(arr);
                    lst.RemoveAt(i);
                    lst._GetPermutations(lst, current + arr[i].ToString());
                }

            return;
            
        }

     

    }
}
