namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OwnArray<int> myarray = new OwnArray<int>();
            myarray.Insert(1, 0);
            myarray.Insert(2, 1);
            myarray.Insert(3, 2);
            myarray.Insert(4, 3);
            
            Console.WriteLine(myarray.ToString());
            var a = myarray.GetCombines(3, MyComparer<int>.Instance).ToList();
            foreach (var item in a)
            {
                foreach (var i in item)
                {
                    Console.Write(i);
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine();
            var b = myarray.GetAllSubstes(MyComparer<int>.Instance).ToList();
            foreach (var item in b)
            {
                foreach (var i in item)
                {
                    Console.Write(i);
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine();
            myarray.GetPermutations(myarray);
        }
    }
}
