#nullable disable

using System;

namespace Session7_SOLID_ISP;

// ISP: don't force a class to implement methods it doesn't need.

public interface IPrinter
{
	void Print();
}

public interface IScanner
{
	void Scan();
}

public class SimplePrinter : IPrinter
{
	public void Print()
	{
		Console.WriteLine("Printing...");
	}
}

public class AllInOne : IPrinter, IScanner
{
	public void Print()
	{
		Console.WriteLine("Printing...");
	}

	public void Scan()
	{
		Console.WriteLine("Scanning...");
	}
}

public static class IspDemo
{
	public static void Run()
	{
		IPrinter printer = new SimplePrinter();
		printer.Print();

		AllInOne a = new AllInOne();
		a.Print();
		a.Scan();
	}
}

