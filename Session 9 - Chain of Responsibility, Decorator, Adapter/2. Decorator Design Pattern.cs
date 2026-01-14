#nullable enable

using System;

namespace Session9_Decorator;

/*
DECORATOR (Structural)

Intent
- Attach additional responsibilities to an object dynamically.
- Decorators provide a flexible alternative to subclassing.

Key idea
- A decorator implements the same interface as the wrapped object.
- It forwards calls and adds behavior before/after.
*/

public interface IMessageSender
{
	void Send(string to, string message);
}

// Concrete component
public sealed class EmailSender : IMessageSender
{
	public void Send(string to, string message)
	{
		Console.WriteLine($"Sending EMAIL to {to}: '{message}'");
	}
}

// Base decorator
public abstract class MessageSenderDecorator : IMessageSender
{
	private readonly IMessageSender _inner;

	protected MessageSenderDecorator(IMessageSender inner)
	{
		_inner = inner;
	}

	public virtual void Send(string to, string message) => _inner.Send(to, message);
}

public sealed class LoggingSenderDecorator : MessageSenderDecorator
{
	public LoggingSenderDecorator(IMessageSender inner) : base(inner) { }

	public override void Send(string to, string message)
	{
		Console.WriteLine($"[LOG] About to send message to {to}");
		base.Send(to, message);
		Console.WriteLine("[LOG] Message sent");
	}
}

public sealed class RetrySenderDecorator : MessageSenderDecorator
{
	private readonly int _maxAttempts;

	public RetrySenderDecorator(IMessageSender inner, int maxAttempts) : base(inner)
	{
		if (maxAttempts < 1) throw new ArgumentOutOfRangeException(nameof(maxAttempts));
		_maxAttempts = maxAttempts;
	}

	public override void Send(string to, string message)
	{
		for (var attempt = 1; attempt <= _maxAttempts; attempt++)
		{
			try
			{
				Console.WriteLine($"[Retry] Attempt {attempt}/{_maxAttempts}");
				base.Send(to, message);
				return;
			}
			catch (Exception ex) when (attempt < _maxAttempts)
			{
				Console.WriteLine($"[Retry] Failed: {ex.Message}");
			}
		}
	}
}

public static class DecoratorDemo
{
	// How to run:
	// - In a Console app, call: Session9_Decorator.DecoratorDemo.Run();
	public static void Run()
	{
		IMessageSender sender = new EmailSender();

		// Wrap base sender with extra behaviors.
		sender = new RetrySenderDecorator(sender, maxAttempts: 3);
		sender = new LoggingSenderDecorator(sender);

		sender.Send("student@example.com", "Decorator pattern demo");
	}
}

