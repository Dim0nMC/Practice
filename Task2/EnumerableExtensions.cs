using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> _GetCombines<T>(
        this IEnumerable<T> collection, int k)
        {
            
            k = 2;
            foreach (var item1 in collection)
            {
                
                foreach (var item2 in collection)
                {
                    
                    if(item2 >= item1)
                    {
                        yield return item1;
                        yield return item2;
                    }
                        
                }
            }
        }

        public static void GetAllSubstes<T>(
        this IEnumerable<T> collection)
        {
            
            List<T> a = new List<T>();
            
            foreach (var item1 in collection)
            {
                a.Add(item1);
            }
            for(int i=1; i<=a.Count; i++)
            {
                List<int> b = new List<int>();
                
                for (int j = 0; j +i <= a.Count; j++)
                {
                    Console.Write("[");
                    for(int l = j; l < j + i; l++)
                    {
                        Console.Write(a[l]+",");
                    }
                    Console.WriteLine("]");
                }
            }
            
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
