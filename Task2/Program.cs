namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OwnArray myarray = new OwnArray();
            myarray.Insert(1, 0);
            myarray.Insert(2, 1);
            myarray.Insert(3, 2);
            myarray.Insert(4, 3);
            Console.WriteLine(myarray.ToString());
            myarray.GetCombines();
            Console.WriteLine();
            myarray.GetAllSubstes();
            Console.WriteLine();
            myarray.GetPermutations(myarray);
        }
    }
}
