#nullable disable

using System;

namespace Session7_SOLID_LSP;

// LSP: base type should not force behavior that some subtypes can't do.
// Not all birds can fly, so "Fly" is a separate interface.

public abstract class Bird
{
	public void Eat()
	{
		Console.WriteLine("Bird eats");
	}
}

public interface IFly
{
	void Fly();
}

public class Sparrow : Bird, IFly
{
	public void Fly()
	{
		Console.WriteLine("Sparrow flies");
	}
}

public class Penguin : Bird
{
	public void Swim()
	{
		Console.WriteLine("Penguin swims");
	}
}

public static class LspDemo
{
	public static void Run()
	{
		Bird b1 = new Sparrow();
		b1.Eat();
		((IFly)b1).Fly();

		Bird b2 = new Penguin();
		b2.Eat();
		((Penguin)b2).Swim();
	}
}

