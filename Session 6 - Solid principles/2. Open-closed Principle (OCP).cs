#nullable disable

using System;
using System.Collections.Generic;

namespace Session6_SOLID_OCP;

// OCP: add new classes (extension) without changing old code.

public interface IShape
{
	double Area();
}

public class Circle : IShape
{
	public double Radius;

	public Circle(double radius)
	{
		Radius = radius;
	}

	public double Area()
	{
		return Math.PI * Radius * Radius;
	}
}

public class Rectangle : IShape
{
	public double Width;
	public double Height;

	public Rectangle(double width, double height)
	{
		Width = width;
		Height = height;
	}

	public double Area()
	{
		return Width * Height;
	}
}

public class Triangle : IShape
{
	public double BaseLength;
	public double Height;

	public Triangle(double baseLength, double height)
	{
		BaseLength = baseLength;
		Height = height;
	}

	public double Area()
	{
		return (BaseLength * Height) / 2;
	}
}

public class AreaCalculator
{
	public double TotalArea(List<IShape> shapes)
	{
		double sum = 0;
		for (int i = 0; i < shapes.Count; i++)
		{
			sum += shapes[i].Area();
		}
		return sum;
	}
}

public static class OcpDemo
{
	public static void Run()
	{
		List<IShape> shapes = new List<IShape>();
		shapes.Add(new Circle(2));
		shapes.Add(new Rectangle(3, 4));
		shapes.Add(new Triangle(10, 2));

		AreaCalculator calculator = new AreaCalculator();
		Console.WriteLine("Total area: " + calculator.TotalArea(shapes));
	}
}

