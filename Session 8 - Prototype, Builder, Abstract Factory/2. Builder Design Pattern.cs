#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Session8_Builder;

/*
BUILDER (Creational)

Intent
- Separate the construction of a complex object from its representation.

When to use
- You have many optional parameters / combinations.
- You want readable object construction (instead of huge constructors).

This example builds a Pizza with optional parts.
*/

public sealed class Pizza
{
	public required string Size { get; init; }
	public required string Dough { get; init; }
	public required string Sauce { get; init; }
	public IReadOnlyList<string> Toppings { get; init; } = Array.Empty<string>();

	public override string ToString() =>
		$"Pizza(Size={Size}, Dough={Dough}, Sauce={Sauce}, Toppings=[{string.Join(", ", Toppings)}])";
}

public sealed class PizzaBuilder
{
	private string? _size;
	private string _dough = "Regular";
	private string _sauce = "Tomato";
	private readonly List<string> _toppings = new();

	public PizzaBuilder Size(string size)
	{
		_size = size;
		return this;
	}

	public PizzaBuilder Dough(string dough)
	{
		_dough = dough;
		return this;
	}

	public PizzaBuilder Sauce(string sauce)
	{
		_sauce = sauce;
		return this;
	}

	public PizzaBuilder AddTopping(string topping)
	{
		_toppings.Add(topping);
		return this;
	}

	public Pizza Build()
	{
		if (string.IsNullOrWhiteSpace(_size))
			throw new InvalidOperationException("Size must be set before Build().");

		return new Pizza
		{
			Size = _size,
			Dough = _dough,
			Sauce = _sauce,
			Toppings = _toppings.ToList()
		};
	}
}

public static class BuilderDemo
{
	// How to run:
	// - In a Console app, call: Session8_Builder.BuilderDemo.Run();
	public static void Run()
	{
		var margherita = new PizzaBuilder()
			.Size("Medium")
			.Dough("Thin")
			.Sauce("Tomato")
			.AddTopping("Mozzarella")
			.AddTopping("Basil")
			.Build();

		var meatLovers = new PizzaBuilder()
			.Size("Large")
			.AddTopping("Pepperoni")
			.AddTopping("Sausage")
			.AddTopping("Bacon")
			.Build();

		Console.WriteLine(margherita);
		Console.WriteLine(meatLovers);
	}
}

