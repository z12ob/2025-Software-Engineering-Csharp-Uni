#nullable disable

using System;

namespace Session9_Decorator;

// DECORATOR (simple lecture style)
// Add extra behavior to an object by wrapping it.

public interface ICoffee
{
	string GetDescription();
	int GetCost();
}

public class SimpleCoffee : ICoffee
{
	public string GetDescription() { return "Coffee"; }
	public int GetCost() { return 5; }
}

public abstract class CoffeeDecorator : ICoffee
{
	protected ICoffee coffee;

	protected CoffeeDecorator(ICoffee coffee)
	{
		this.coffee = coffee;
	}

	public virtual string GetDescription() { return coffee.GetDescription(); }
	public virtual int GetCost() { return coffee.GetCost(); }
}

public class MilkDecorator : CoffeeDecorator
{
	public MilkDecorator(ICoffee coffee) : base(coffee) { }
	public override string GetDescription() { return coffee.GetDescription() + "+Milk"; }
	public override int GetCost() { return coffee.GetCost() + 2; }
}

public class SugarDecorator : CoffeeDecorator
{
	public SugarDecorator(ICoffee coffee) : base(coffee) { }
	public override string GetDescription() { return coffee.GetDescription() + "+Sugar"; }
	public override int GetCost() { return coffee.GetCost() + 1; }
}

public static class DecoratorDemo
{
	public static void Run()
	{
		ICoffee coffee = new SimpleCoffee();
		coffee = new MilkDecorator(coffee);
		coffee = new SugarDecorator(coffee);

		Console.WriteLine(coffee.GetDescription());
		Console.WriteLine("Cost: " + coffee.GetCost());
	}
}

