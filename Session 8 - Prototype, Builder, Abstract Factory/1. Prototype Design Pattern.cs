// Cloneable object
class Address
{
    public string City;
    public Address(string city) { City = city; }
}

class Person
{
    public string Name;
    public int Age;
    public Address Addr;

    public Person(string name, int age, Address addr)
    {
        Name = name;
        Age = age;
        Addr = addr;
    }

    // Prototype: returns a copy (deep copy for Address)
    public Person Clone()
    {
        return new Person(Name, Age, new Address(Addr.City));
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person("Ana", 20, new Address("Tbilisi"));
        Person p2 = p1.Clone();

        p2.Name = "Gio";
        p2.Addr.City = "Kutaisi";

        Console.WriteLine(p1.Name + ", " + p1.Addr.City); // Ana, Tbilisi
        Console.WriteLine(p2.Name + ", " + p2.Addr.City); // Gio, Kutaisi
    }
}
