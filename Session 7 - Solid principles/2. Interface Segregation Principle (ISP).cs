#nullable enable

using System;

namespace Session7_SOLID_ISP;

/*
ISP — Interface Segregation Principle

Definition
- "Clients should not be forced to depend on interfaces they do not use."

Symptom
- A "fat" interface with many unrelated methods.
- Implementers must provide dummy implementations or throw NotSupportedException.

Goal
- Split into small, role-focused interfaces.
*/

// --- BAD: a fat interface ---
public interface IMultiFunctionDevice_Bad
{
	void Print(string content);
	void Scan();
	void Fax();
}

// A simple printer doesn't scan or fax, but the interface forces it.
public sealed class BasicPrinter_Bad : IMultiFunctionDevice_Bad
{
	public void Print(string content) => Console.WriteLine($"Printing: {content}");
	public void Scan() => throw new NotSupportedException("Scanner not available");
	public void Fax() => throw new NotSupportedException("Fax not available");
}

// --- GOOD: split into small interfaces ---
public interface IPrinter
{
	void Print(string content);
}

public interface IScanner
{
	void Scan();
}

public interface IFax
{
	void Fax();
}

public sealed class BasicPrinter : IPrinter
{
	public void Print(string content) => Console.WriteLine($"Printing: {content}");
}

public sealed class OfficeAllInOne : IPrinter, IScanner, IFax
{
	public void Print(string content) => Console.WriteLine($"Printing: {content}");
	public void Scan() => Console.WriteLine("Scanning...");
	public void Fax() => Console.WriteLine("Faxing...");
}

public static class IspDemo
{
	// How to run:
	// - In a Console app, call: Session7_SOLID_ISP.IspDemo.Run();
	public static void Run()
	{
		IPrinter printer = new BasicPrinter();
		printer.Print("Exam notes");

		var allInOne = new OfficeAllInOne();
		allInOne.Scan();
		allInOne.Fax();
	}
}

