using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Student:
    IEquatable<Student>
    
    {
        public string FirstName { get; }
        public string SecondName { get; }
        public string Patronymic { get; }
        public string Group { get; }
        public string PracticeCourse { get; }
        public Student(
            string FirstName,
            string SecondName,
            string Patronymic,
            string Group,
            string PracticeCourse)
        {
            this.FirstName = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
            this.SecondName = SecondName ?? throw new ArgumentNullException(nameof(SecondName));
            this.Patronymic = Patronymic ?? throw new ArgumentNullException(nameof(Patronymic));
            this.Group = Group ?? throw new ArgumentNullException(nameof(Group));
            this.PracticeCourse = PracticeCourse ?? throw new ArgumentNullException(nameof(PracticeCourse));
        }

        public int Course
        {
            get
            {
                string group = this.Group;
                DateTime now_date = DateTime.Now;
                int year = Convert.ToInt32(group.Substring(9,2))+2000;
                DateTime admission_date = new DateTime(year, 9, 1);
                string s = Convert.ToString(now_date.Subtract(admission_date));
                s = s.Substring(0, s.IndexOf('.'));
                double course = Math.Ceiling(Convert.ToDouble(s) / 365);
                return (int)course;
            }
           
        }

        public override string ToString()
        {
            return $"[ FirstName: {FirstName}, SecondName: {SecondName}, Patronymic: {Patronymic}, Group: {Group}, PracticeCourse: {PracticeCourse} ]";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, SecondName, Patronymic, Group, PracticeCourse);
            
        }
        
        

        public bool Equals(
            Student? std)
        {
            if (std == null)
            {
                return false;
            }

            return FirstName.Equals(std.FirstName, StringComparison.Ordinal)
                && SecondName.Equals(std.SecondName, StringComparison.Ordinal)
                && Patronymic.Equals(std.Patronymic, StringComparison.Ordinal)
                && Group.Equals(std.Group, StringComparison.Ordinal)
                && PracticeCourse.Equals(std.PracticeCourse, StringComparison.Ordinal);
        }

        

    }
}
