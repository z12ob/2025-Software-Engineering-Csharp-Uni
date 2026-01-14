using System;

namespace Session1_Singleton;

// Singleton Design Pattern
// - Only one object is created.
// - Private constructor + public GetInstance().
// Note: simplest version for studying (not thread-safe).

public class Singleton
{
	private static Singleton instance;

	private Singleton() { }

	public static Singleton GetInstance()
	{
		if (instance == null)
		{
			instance = new Singleton();
		}
		return instance;
	}

	public void DoSomething()
	{
		Console.WriteLine("Singleton works!");
	}
}

public static class SingletonDemo
{
	// Usage:
	// Singleton obj = Singleton.GetInstance();
	public static void Run()
	{
		Singleton s1 = Singleton.GetInstance();
		Singleton s2 = Singleton.GetInstance();

		Console.WriteLine("Same object? " + Object.ReferenceEquals(s1, s2));
		s1.DoSomething();
	}
}

