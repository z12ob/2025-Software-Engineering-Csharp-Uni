using System;

namespace Session2_Factory;

// Factory Design Pattern
// - Factory returns objects using an interface.
// - Client does not know the concrete class.

public interface IProduct
{
	void GetData();
}

public class Apple : IProduct
{
	public void GetData()
	{
		Console.WriteLine("I am Apple");
	}
}

public class Micro : IProduct
{
	public void GetData()
	{
		Console.WriteLine("I am Microsoft");
	}
}

public class Google : IProduct
{
	public void GetData()
	{
		Console.WriteLine("I am Google");
	}
}

public class ProductFactory
{
	public IProduct GetProduct(int i)
	{
		if (i == 1)
			return new Apple();
		else if (i == 2)
			return new Micro();
		else
			return new Google();
	}
}

public static class FactoryDemo
{
	public static void Run()
	{
		ProductFactory factory = new ProductFactory();

		IProduct p1 = factory.GetProduct(1);
		p1.GetData();

		IProduct p2 = factory.GetProduct(2);
		p2.GetData();
	}
}

