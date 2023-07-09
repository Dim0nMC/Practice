using System.Xml;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student obj1 = new Student("Дмитрий", "Селивёрстов", "Сергеевич", "М8О-201Б-21", "C#");
            Student obj2 = new Student("Иван", "Иванов", "Иванович", "М8О-210Б-22", "GO");
            try
            {
                Student obj3 = new Student(null,null,null,null,null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                //obj1.FirstName = "Сергей"; 

                Console.WriteLine(obj1.FirstName);
                Console.WriteLine(obj2.Group + "\n");

                Console.WriteLine(obj1.getCourse());
                Console.WriteLine(obj2.getCourse() + "\n");

                Console.WriteLine(obj1.GetHashCode());
                Console.WriteLine(obj2.GetHashCode() + "\n");

                Console.WriteLine(obj1.ToString());
                Console.WriteLine(obj2.ToString() + "\n");

                Console.WriteLine(obj1.Equals(obj2));
                Student obj3 = new Student("Дмитрий", "Селивёрстов", "Сергеевич", "М8О-201Б-21", "C#");
                Console.WriteLine(obj1.Equals(obj3) + "\n");

                Console.WriteLine(obj1.Equals((object)obj3) + "\n");

                Console.WriteLine(obj1.Equals(obj3.ToString()) + "\n");

                Console.WriteLine(obj1.Equals(obj2.GetHashCode()) + "\n");

            }
            

            
        }
    }
}
