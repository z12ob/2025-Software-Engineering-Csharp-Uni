#nullable disable

using System;

namespace Session4_Facade;

// FACADE pattern (simple lecture style)
// Facade provides one simple operation for many subsystem calls.

public class Subsystem1
{
	public void Method1()
	{
		Console.WriteLine("Subsystem1: Method1");
	}
}

public class Subsystem2
{
	public void Method2()
	{
		Console.WriteLine("Subsystem2: Method2");
	}
}

public class SimpleFacade
{
	private Subsystem1 s1;
	private Subsystem2 s2;

	public SimpleFacade()
	{
		s1 = new Subsystem1();
		s2 = new Subsystem2();
	}

	public void Operation()
	{
		Console.WriteLine("Facade: Operation");
		s1.Method1();
		s2.Method2();
	}
}

public static class FacadeDemo
{
	public static void Run()
	{
		SimpleFacade facade = new SimpleFacade();
		facade.Operation();
	}
}

