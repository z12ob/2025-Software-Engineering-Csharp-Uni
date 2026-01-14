using System.Xml.Linq;

namespace Singletone
{
    public class Person
    {
        public Person (string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void Display()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Age);
        }

        public string Name { get; set; }

        public int Age
        {
            get;
            set 
            { 
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative");
                }
            }
        }

        public static string Country { get; set; } = "Georgia";
    }
}
