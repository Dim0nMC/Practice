using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<int> _GetCombines(
        this IEnumerable<int> collection, int k)
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

        public static void GetAllSubstes(
        this IEnumerable<int> collection)
        {
            
            List<int> a = new List<int>();
            
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

        public static IEnumerable<int> _GetPermutations(this IEnumerable<int> collection, IList<int> arr,string current="")
        {
            
                if (arr.Count == 0) 
                {
                    Console.WriteLine(current);
                    return collection;
                }
                for (int i = 0; i < arr.Count; i++) 
                    List<int> lst = new List<int>(arr);
                    lst.RemoveAt(i);
                    lst._GetPermutations(lst, current + arr[i].ToString());
                }
            
            return collection;
            
        }
    }
}
