#nullable enable

using System;

namespace Session2_Factory;

/*
FACTORY (Creational)

There are many "factory" variants. This file demonstrates a simple Factory Method style.

Intent
- Encapsulate object creation.
- Return an abstraction (interface/base class), not a concrete implementation.

Benefits
- Callers don't depend on concrete classes.
- Central place to enforce creation rules.

Tradeoff
- Adds an extra indirection (the factory) and more types.
*/

public enum NotificationType
{
	Email,
	Sms,
	Push
}

public interface INotification
{
	void Send(string to, string message);
}

public sealed class EmailNotification : INotification
{
	public void Send(string to, string message) =>
		Console.WriteLine($"[EMAIL] To={to} Body='{message}'");
}

public sealed class SmsNotification : INotification
{
	public void Send(string to, string message) =>
		Console.WriteLine($"[SMS] To={to} Body='{message}'");
}

public sealed class PushNotification : INotification
{
	public void Send(string to, string message) =>
		Console.WriteLine($"[PUSH] To={to} Body='{message}'");
}

public static class NotificationFactory
{
	public static INotification Create(NotificationType type) => type switch
	{
		NotificationType.Email => new EmailNotification(),
		NotificationType.Sms => new SmsNotification(),
		NotificationType.Push => new PushNotification(),
		_ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown notification type")
	};
}

public static class FactoryDemo
{
	// How to run:
	// - In a Console app, call: Session2_Factory.FactoryDemo.Run();
	public static void Run()
	{
		INotification notifier = NotificationFactory.Create(NotificationType.Email);
		notifier.Send("student@example.com", "Exam starts at 10:00.");

		notifier = NotificationFactory.Create(NotificationType.Sms);
		notifier.Send("+995-xxx-xxx", "Don’t forget your ID card.");
	}
}

