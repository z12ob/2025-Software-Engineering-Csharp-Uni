#nullable disable

using System;

namespace Session9_Adapter;

// ADAPTER (simple lecture style)
// Convert one interface to another.

public interface ITarget
{
	void Request();
}

public class Adaptee
{
	public void SpecificRequest()
	{
		Console.WriteLine("Adaptee: SpecificRequest");
	}
}

public class Adapter : ITarget
{
	private Adaptee adaptee;

	public Adapter(Adaptee adaptee)
	{
		this.adaptee = adaptee;
	}

	public void Request()
	{
		adaptee.SpecificRequest();
	}
}

public static class AdapterDemo
{
	public static void Run()
	{
		ITarget target = new Adapter(new Adaptee());
		target.Request();
	}
}

