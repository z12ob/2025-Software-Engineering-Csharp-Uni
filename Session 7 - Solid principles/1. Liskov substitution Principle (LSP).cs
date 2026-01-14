#nullable enable

using System;

namespace Session7_SOLID_LSP;

/*
LSP — Liskov Substitution Principle

Definition
- If S is a subtype of T, then objects of type T should be replaceable with objects of type S
  without breaking the program's correctness.

Practical meaning
- A derived class must honor the base class contract.
- It must not remove behavior, throw “not supported” for base behavior, or weaken invariants.

Classic symptom
- You call a method on the base type, and a subclass throws at runtime.
*/

// --- BAD DESIGN (LSP violation) ---
public abstract class Bird_Bad
{
	public abstract void Fly();
}

public sealed class Sparrow_Bad : Bird_Bad
{
	public override void Fly() => Console.WriteLine("Sparrow flies.");
}

public sealed class Penguin_Bad : Bird_Bad
{
	public override void Fly() => throw new NotSupportedException("Penguins cannot fly.");
}

// If your code expects Bird_Bad.Fly() to always work, Penguin_Bad breaks that expectation.

// --- BETTER DESIGN (LSP-friendly) ---
public abstract class Bird
{
	public abstract void Eat();
}

public interface IFlyable
{
	void Fly();
}

public sealed class Sparrow : Bird, IFlyable
{
	public override void Eat() => Console.WriteLine("Sparrow eats seeds.");
	public void Fly() => Console.WriteLine("Sparrow flies.");
}

public sealed class Penguin : Bird
{
	public override void Eat() => Console.WriteLine("Penguin eats fish.");
	public void Swim() => Console.WriteLine("Penguin swims.");
}

public static class LspDemo
{
	// How to run:
	// - In a Console app, call: Session7_SOLID_LSP.LspDemo.Run();
	public static void Run()
	{
		Console.WriteLine("LSP violation example:");
		Bird_Bad b1 = new Sparrow_Bad();
		b1.Fly();

		Bird_Bad b2 = new Penguin_Bad();
		try
		{
			b2.Fly();
		}
		catch (NotSupportedException ex)
		{
			Console.WriteLine($"Runtime failure: {ex.Message}");
		}

		Console.WriteLine();
		Console.WriteLine("LSP-friendly design:");

		Bird penguin = new Penguin();
		penguin.Eat();

		Bird sparrow = new Sparrow();
		sparrow.Eat();

		IFlyable flyer = (IFlyable)sparrow;
		flyer.Fly();
	}
}

