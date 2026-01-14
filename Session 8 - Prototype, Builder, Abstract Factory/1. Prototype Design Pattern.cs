#nullable disable

using System;

namespace Session8_Prototype;

// PROTOTYPE pattern (simple lecture style)
// Create a new object by cloning an existing object.

public class Person
{
	public string Name;
	public int Age;
	public Address Address;

	public Person(string name, int age, Address address)
	{
		Name = name;
		Age = age;
		Address = address;
	}

	public Person Clone()
	{
		Address newAddress = new Address(Address.City);
		return new Person(Name, Age, newAddress);
	}
}

public class Address
{
	public string City;

	public Address(string city)
	{
		City = city;
	}
}

public static class PrototypeDemo
{
	public static void Run()
	{
		Person p1 = new Person("Ana", 20, new Address("Tbilisi"));
		Person p2 = p1.Clone();
		p2.Name = "Gio";
		p2.Address.City = "Kutaisi";

		Console.WriteLine("Original: " + p1.Name + ", " + p1.Address.City);
		Console.WriteLine("Clone   : " + p2.Name + ", " + p2.Address.City);
	}
}

