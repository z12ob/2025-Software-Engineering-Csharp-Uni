#nullable enable

using System;

namespace Session3_State;

/*
STATE (Behavioral)

Intent
- Let an object change its behavior when its internal state changes.
- Replace large if/switch blocks with polymorphism.

Key idea
- Context delegates to a State object.
- State object can transition the Context to another State.
*/

public sealed class Order
{
	private IOrderState _state = new NewOrderState();

	internal void SetState(IOrderState newState) => _state = newState;

	public string StateName => _state.Name;

	public void Pay() => _state.Pay(this);
	public void Ship() => _state.Ship(this);
	public void Cancel() => _state.Cancel(this);
}

public interface IOrderState
{
	string Name { get; }
	void Pay(Order order);
	void Ship(Order order);
	void Cancel(Order order);
}

public sealed class NewOrderState : IOrderState
{
	public string Name => "New";

	public void Pay(Order order)
	{
		Console.WriteLine("Payment accepted.");
		order.SetState(new PaidOrderState());
	}

	public void Ship(Order order) =>
		Console.WriteLine("Cannot ship: order is not paid.");

	public void Cancel(Order order)
	{
		Console.WriteLine("Order canceled.");
		order.SetState(new CanceledOrderState());
	}
}

public sealed class PaidOrderState : IOrderState
{
	public string Name => "Paid";

	public void Pay(Order order) => Console.WriteLine("Already paid.");

	public void Ship(Order order)
	{
		Console.WriteLine("Order shipped.");
		order.SetState(new ShippedOrderState());
	}

	public void Cancel(Order order)
	{
		Console.WriteLine("Refund issued, order canceled.");
		order.SetState(new CanceledOrderState());
	}
}

public sealed class ShippedOrderState : IOrderState
{
	public string Name => "Shipped";

	public void Pay(Order order) => Console.WriteLine("Already paid and shipped.");
	public void Ship(Order order) => Console.WriteLine("Already shipped.");
	public void Cancel(Order order) => Console.WriteLine("Cannot cancel: already shipped.");
}

public sealed class CanceledOrderState : IOrderState
{
	public string Name => "Canceled";

	public void Pay(Order order) => Console.WriteLine("Cannot pay: order is canceled.");
	public void Ship(Order order) => Console.WriteLine("Cannot ship: order is canceled.");
	public void Cancel(Order order) => Console.WriteLine("Already canceled.");
}

public static class StateDemo
{
	// How to run:
	// - In a Console app, call: Session3_State.StateDemo.Run();
	public static void Run()
	{
		var order = new Order();
		Console.WriteLine($"State: {order.StateName}");

		order.Ship();
		order.Pay();
		Console.WriteLine($"State: {order.StateName}");

		order.Ship();
		Console.WriteLine($"State: {order.StateName}");

		order.Cancel();
	}
}

