#nullable disable

using System;

namespace Session9_ChainOfResponsibility;

// CHAIN OF RESPONSIBILITY (simple lecture style)
// Pass request through handlers until someone handles it.

public abstract class Handler
{
	protected Handler next;

	public void SetNext(Handler next)
	{
		this.next = next;
	}

	public abstract void Handle(int amount);
}

public class HundredsHandler : Handler
{
	public override void Handle(int amount)
	{
		if (amount >= 100)
		{
			Console.WriteLine("Hundreds handler: " + amount);
		}
		else if (next != null)
		{
			next.Handle(amount);
		}
	}
}

public class FiftiesHandler : Handler
{
	public override void Handle(int amount)
	{
		if (amount >= 50)
		{
			Console.WriteLine("Fifties handler: " + amount);
		}
		else if (next != null)
		{
			next.Handle(amount);
		}
	}
}

public class TensHandler : Handler
{
	public override void Handle(int amount)
	{
		Console.WriteLine("Tens handler (default): " + amount);
	}
}

public static class ChainDemo
{
	public static void Run()
	{
		Handler h1 = new HundredsHandler();
		Handler h2 = new FiftiesHandler();
		Handler h3 = new TensHandler();

		h1.SetNext(h2);
		h2.SetNext(h3);

		h1.Handle(120);
		h1.Handle(70);
		h1.Handle(20);
	}
}

