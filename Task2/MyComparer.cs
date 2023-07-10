using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class MyComparer<T> :
        IEqualityComparer<T>
    {
        private static MyComparer<T>? _instance;

        private MyComparer()
        {

        }

        public static MyComparer<T> Instance =>
            _instance ??= new MyComparer<T>();
        public bool Equals(T? x, T? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            return x.GetType() == y.GetType() && x.Equals(y);
        }
        public int GetHashCode(T? obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }
}
