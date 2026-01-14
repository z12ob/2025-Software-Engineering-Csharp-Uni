#nullable disable

using System;

namespace Session7_SOLID_DIP;

// DIP: high-level code depends on abstraction (interface), not concrete classes.

public interface IMessageSender
{
	void Send(string message);
}

public class EmailSender : IMessageSender
{
	public void Send(string message)
	{
		Console.WriteLine("Email: " + message);
	}
}

public class SmsSender : IMessageSender
{
	public void Send(string message)
	{
		Console.WriteLine("SMS: " + message);
	}
}

public class Notification
{
	private IMessageSender sender;

	public Notification(IMessageSender sender)
	{
		this.sender = sender;
	}

	public void Notify(string message)
	{
		sender.Send(message);
	}
}

public static class DipDemo
{
	public static void Run()
	{
		Notification n1 = new Notification(new EmailSender());
		n1.Notify("Hello from DIP");

		Notification n2 = new Notification(new SmsSender());
		n2.Notify("Same Notification, different sender");
	}
}

