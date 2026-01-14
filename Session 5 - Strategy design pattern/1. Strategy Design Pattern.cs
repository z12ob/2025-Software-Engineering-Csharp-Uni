#nullable disable

using System;

namespace Session5_Strategy;

// STRATEGY pattern (simple lecture style)
// Choose different algorithms at runtime.

public interface IStrategy
{
	int DoOperation(int a, int b);
}

public class AddStrategy : IStrategy
{
	public int DoOperation(int a, int b)
	{
		return a + b;
	}
}

public class MultiplyStrategy : IStrategy
{
	public int DoOperation(int a, int b)
	{
		return a * b;
	}
}

public class Context
{
	private IStrategy strategy;

	public Context(IStrategy strategy)
	{
		this.strategy = strategy;
	}

	public void SetStrategy(IStrategy strategy)
	{
		this.strategy = strategy;
	}

	public int Execute(int a, int b)
	{
		return strategy.DoOperation(a, b);
	}
}

public static class StrategyDemo
{
	public static void Run()
	{
		Context context = new Context(new AddStrategy());
		Console.WriteLine("10 + 5 = " + context.Execute(10, 5));

		context.SetStrategy(new MultiplyStrategy());
		Console.WriteLine("10 * 5 = " + context.Execute(10, 5));
	}
}

