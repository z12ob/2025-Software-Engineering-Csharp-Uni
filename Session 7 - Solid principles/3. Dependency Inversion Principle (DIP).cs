#nullable enable

using System;

namespace Session7_SOLID_DIP;

/*
DIP — Dependency Inversion Principle

Definition
- High-level modules should not depend on low-level modules.
  Both should depend on abstractions.
- Abstractions should not depend on details.
  Details should depend on abstractions.

Practical meaning
- Write code against interfaces.
- Inject dependencies (constructor injection).
- This improves testability and flexibility.
*/

public interface IPaymentGateway
{
	void Charge(decimal amount);
}

// Low-level detail #1
public sealed class StripeGateway : IPaymentGateway
{
	public void Charge(decimal amount) => Console.WriteLine($"Stripe charged {amount:C}");
}

// Low-level detail #2
public sealed class FakeGatewayForTests : IPaymentGateway
{
	public decimal TotalCharged { get; private set; }
	public void Charge(decimal amount)
	{
		TotalCharged += amount;
		Console.WriteLine($"FAKE gateway charged {amount:C}");
	}
}

// High-level module: business workflow
public sealed class OrderService
{
	private readonly IPaymentGateway _gateway;

	public OrderService(IPaymentGateway gateway)
	{
		_gateway = gateway;
	}

	public void PlaceOrder(decimal total)
	{
		if (total <= 0) throw new ArgumentOutOfRangeException(nameof(total));

		// Business policy would live here (discounts, fraud checks, etc.)
		_gateway.Charge(total);

		Console.WriteLine("Order placed successfully.");
	}
}

public static class DipDemo
{
	// How to run:
	// - In a Console app, call: Session7_SOLID_DIP.DipDemo.Run();
	public static void Run()
	{
		var prodService = new OrderService(new StripeGateway());
		prodService.PlaceOrder(120);

		var fake = new FakeGatewayForTests();
		var testService = new OrderService(fake);
		testService.PlaceOrder(10);
		testService.PlaceOrder(5);

		Console.WriteLine($"Fake total charged: {fake.TotalCharged:C}");
	}
}

