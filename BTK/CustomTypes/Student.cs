using System.ComponentModel.DataAnnotations;

namespace CustomTypes
{
    public class Student : IComparable
    {
        public Student()
        {
            
        }
        public Student(int id, string name, double gPA)
        {
            Id = id;
            Name = name;
            GPA = gPA;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public int CompareTo(object? obj)
        {
            var other = (Student)obj;
            //if (this.GPA < other.GPA)
            //{
            //    return -1;
            //}
            //else if (this.GPA.Equals(other.GPA))
            //{
            //    return 0;
            //}
            //else
            //{
            //    return +1;
            //}
            return this.GPA.CompareTo(other.GPA);
        }
        public override string ToString()
        {
            return $"{Id,-5} {Name,-10} {GPA,-5}";
        }
    }
}
