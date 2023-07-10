using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class MyComparer : IEqualityComparer<int>, IComparer<int>
    {
        private static MyComparer? _instance;

        public MyComparer()
        {

        }

        public static MyComparer Instance =>
            _instance ??= new MyComparer();
        public bool Equals(int x, int y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return (x == y);
        }

        public int GetHashCode(int obj)
        {
            return obj.GetHashCode();
        }

        public int Compare(int x, int y)
        {
            return (x - y);
        }

        
    }
}
