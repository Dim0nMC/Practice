using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class OwnArray<T>:
        IEnumerable<T>
    {
        private List<T> _array;

        public OwnArray()
        {
            _array = new List<T>();
        }

        private OwnArray(
            List<T> array)
        {
            _array = new List<T>(array);
        }



       public void Insert(T value, int index)
        {
            _array.Insert(index, value);
            

        }

        public override string ToString()
        {
            string s ="";
            foreach(var item in _array) 
            {
                s = s + Convert.ToString(item)+" ";
            }
            return s;
        }

        public void GetCombines()
        {
            int i = 0;
            foreach (var item in _array._GetCombines(2))
            {
                if (i % 2 == 0)
                {
                    Console.Write("["+ item +", ");
                }
                if (i % 2 == 1)
                {
                    Console.WriteLine(item + "]");
                }
                i++;
            }
        }
        
        public void GetPermutations(OwnArray<T> myarray)
        {
            List<T> a = new List<T>();
            foreach(var item in myarray) 
            {
                a.Add(item);
            }
            _array._GetPermutations(a);
        }


        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < _array.Count; i++)
            {
                yield return _array[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
