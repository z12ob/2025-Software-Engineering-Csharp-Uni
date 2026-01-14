#nullable disable

using System;
using System.Collections.Generic;

namespace Session10_Mediator;

// MEDIATOR (simple lecture style)
// Users talk through ChatRoom, not directly.

public class ChatRoom
{
	private List<User> users = new List<User>();

	public void Register(User user)
	{
		users.Add(user);
		user.SetRoom(this);
	}

	public void Send(string from, string to, string message)
	{
		for (int i = 0; i < users.Count; i++)
		{
			if (users[i].Name == to)
			{
				users[i].Receive(from, message);
				return;
			}
		}
		Console.WriteLine("User not found: " + to);
	}
}

public class User
{
	private ChatRoom room;
	public string Name;

	public User(string name)
	{
		Name = name;
	}

	public void SetRoom(ChatRoom room)
	{
		this.room = room;
	}

	public void Send(string to, string message)
	{
		room.Send(Name, to, message);
	}

	public void Receive(string from, string message)
	{
		Console.WriteLine(Name + " received from " + from + ": " + message);
	}
}

public static class MediatorDemo
{
	public static void Run()
	{
		ChatRoom room = new ChatRoom();
		User a = new User("Ana");
		User b = new User("Gio");

		room.Register(a);
		room.Register(b);

		a.Send("Gio", "Hello");
		b.Send("Ana", "Hi");
	}
}

