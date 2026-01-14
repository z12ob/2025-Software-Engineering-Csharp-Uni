#nullable enable

using System;
using System.Collections.Generic;

namespace Session6_SOLID_OCP;

/*
OCP — Open/Closed Principle

Definition
- "Software entities should be open for extension, but closed for modification."

Meaning in practice
- You should be able to add new behavior (new feature) without editing tested, stable code.
- You usually achieve this with interfaces + polymorphism (or composition).

This example uses Shapes:
- Bad approach: switch(type) to compute area.
- OCP approach: each shape knows how to compute its own area.
*/

public interface IShape
{
	double Area();
}

public sealed class Circle : IShape
{
	public Circle(double radius) => Radius = radius;
	public double Radius { get; }
	public double Area() => Math.PI * Radius * Radius;
}

public sealed class Rectangle : IShape
{
	public Rectangle(double width, double height)
	{
		Width = width;
		Height = height;
	}

	public double Width { get; }
	public double Height { get; }

	public double Area() => Width * Height;
}

// NEW FEATURE (extension): adding Triangle does not require modifying the calculator.
public sealed class Triangle : IShape
{
	public Triangle(double baseLength, double height)
	{
		BaseLength = baseLength;
		Height = height;
	}

	public double BaseLength { get; }
	public double Height { get; }

	public double Area() => (BaseLength * Height) / 2.0;
}

public static class AreaCalculator
{
	// Note: no switch, no "if (shape is Circle)", etc.
	public static double TotalArea(IEnumerable<IShape> shapes)
	{
		double total = 0;
		foreach (var s in shapes)
		{
			total += s.Area();
		}

		return total;
	}
}

public static class OcpDemo
{
	// How to run:
	// - In a Console app, call: Session6_SOLID_OCP.OcpDemo.Run();
	public static void Run()
	{
		var shapes = new List<IShape>
		{
			new Circle(2),
			new Rectangle(3, 4),
			new Triangle(10, 2)
		};

		Console.WriteLine($"Total area: {AreaCalculator.TotalArea(shapes):0.00}");
	}
}

