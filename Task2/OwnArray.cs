using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class OwnArray:
        IEnumerable<int>
    {
        private List<int> _array;

        public OwnArray()
        {
            _array = new List<int>();
        }

        private OwnArray(
            List<int> array)
        {
            _array = new List<int>(array);
        }



       public void Insert(int value, int index)
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
        
        public void GetPermutations(OwnArray myarray)
        {
            List<int> a = new List<int>();
            foreach(var item in myarray) 
            {
                a.Add(item);
            }
            _array._GetPermutations(a);
        }


        public IEnumerator<int> GetEnumerator()
        {
            foreach (var arrayItem in _array)
            {
                yield return arrayItem;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
