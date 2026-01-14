
#nullable enable

using System;

namespace Session5_Strategy;

/*
STRATEGY (Behavioral)

Intent
- Define a family of algorithms, encapsulate each one, and make them interchangeable.

Key idea
- A "Context" class uses a Strategy interface.
- You can swap strategies at runtime (without changing the context).

This example is practical:
- We calculate a final price using different discount strategies.
*/

public interface IDiscountStrategy
{
	decimal ApplyDiscount(decimal originalPrice);
}

public sealed class NoDiscount : IDiscountStrategy
{
	public decimal ApplyDiscount(decimal originalPrice) => originalPrice;
}

public sealed class StudentDiscount : IDiscountStrategy
{
	private readonly decimal _percent;

	public StudentDiscount(decimal percent)
	{
		if (percent is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(percent));
		_percent = percent;
	}

	public decimal ApplyDiscount(decimal originalPrice)
	{
		var factor = (100m - _percent) / 100m;
		return Math.Round(originalPrice * factor, 2, MidpointRounding.AwayFromZero);
	}
}

public sealed class FixedAmountDiscount : IDiscountStrategy
{
	private readonly decimal _amount;

	public FixedAmountDiscount(decimal amount)
	{
		if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
		_amount = amount;
	}

	public decimal ApplyDiscount(decimal originalPrice)
	{
		return Math.Max(0, originalPrice - _amount);
	}
}

public sealed class Checkout
{
	private IDiscountStrategy _discountStrategy;

	public Checkout(IDiscountStrategy discountStrategy)
	{
		_discountStrategy = discountStrategy;
	}

	public void SetDiscountStrategy(IDiscountStrategy discountStrategy) => _discountStrategy = discountStrategy;

	public decimal FinalPrice(decimal originalPrice)
	{
		if (originalPrice < 0) throw new ArgumentOutOfRangeException(nameof(originalPrice));
		return _discountStrategy.ApplyDiscount(originalPrice);
	}
}

public static class StrategyDemo
{
	// How to run:
	// - In a Console app, call: Session5_Strategy.StrategyDemo.Run();
	public static void Run()
	{
		var checkout = new Checkout(new NoDiscount());

		var price = 100m;
		Console.WriteLine($"Original: {price:C}");
		Console.WriteLine($"No discount: {checkout.FinalPrice(price):C}");

		checkout.SetDiscountStrategy(new StudentDiscount(percent: 15));
		Console.WriteLine($"Student 15%: {checkout.FinalPrice(price):C}");

		checkout.SetDiscountStrategy(new FixedAmountDiscount(amount: 25));
		Console.WriteLine($"Fixed -25: {checkout.FinalPrice(price):C}");
	}
}

