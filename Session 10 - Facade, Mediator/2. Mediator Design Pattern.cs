#nullable enable

using System;
using System.Collections.Generic;

namespace Session10_Mediator;

/*
MEDIATOR (Behavioral)

Intent
- Define an object (Mediator) that encapsulates how a set of objects interact.
- Promotes loose coupling by preventing objects from referring to each other explicitly.

Benefit
- Instead of many-to-many connections between colleagues, you have:
  Colleague -> Mediator -> Colleague(s)

Example: Chat room.
- Users don't call each other directly.
- They send messages through the ChatRoom mediator.
*/

public interface IChatRoom
{
	void Register(User user);
	void Send(string from, string to, string message);
	void Broadcast(string from, string message);
}

public sealed class ChatRoom : IChatRoom
{
	private readonly Dictionary<string, User> _users = new(StringComparer.OrdinalIgnoreCase);

	public void Register(User user)
	{
		_users[user.Name] = user;
		user.SetChatRoom(this);
	}

	public void Send(string from, string to, string message)
	{
		if (_users.TryGetValue(to, out var receiver))
		{
			receiver.Receive(from, message);
		}
		else
		{
			Console.WriteLine($"[ChatRoom] User '{to}' not found.");
		}
	}

	public void Broadcast(string from, string message)
	{
		foreach (var kv in _users)
		{
			// Optional: don't send broadcast to sender.
			if (string.Equals(kv.Key, from, StringComparison.OrdinalIgnoreCase))
				continue;

			kv.Value.Receive(from, message);
		}
	}
}

public sealed class User
{
	private IChatRoom? _chatRoom;

	public User(string name)
	{
		Name = name;
	}

	public string Name { get; }

	internal void SetChatRoom(IChatRoom chatRoom) => _chatRoom = chatRoom;

	public void SendTo(string to, string message)
	{
		if (_chatRoom is null) throw new InvalidOperationException("User is not registered in a chat room.");
		_chatRoom.Send(Name, to, message);
	}

	public void Broadcast(string message)
	{
		if (_chatRoom is null) throw new InvalidOperationException("User is not registered in a chat room.");
		_chatRoom.Broadcast(Name, message);
	}

	public void Receive(string from, string message)
	{
		Console.WriteLine($"[{Name}] received from {from}: {message}");
	}
}

public static class MediatorDemo
{
	// How to run:
	// - In a Console app, call: Session10_Mediator.MediatorDemo.Run();
	public static void Run()
	{
		var room = new ChatRoom();

		var ana = new User("Ana");
		var gio = new User("Gio");
		var mari = new User("Mari");

		room.Register(ana);
		room.Register(gio);
		room.Register(mari);

		ana.SendTo("Gio", "Hi! Are you ready for the exam?");
		gio.SendTo("Ana", "Almost. Reviewing patterns now.");
		mari.Broadcast("Good luck everyone!");
	}
}

