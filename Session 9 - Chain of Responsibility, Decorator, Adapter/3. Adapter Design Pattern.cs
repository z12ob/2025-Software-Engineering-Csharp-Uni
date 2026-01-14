#nullable enable

using System;

namespace Session9_Adapter;

/*
ADAPTER (Structural)

Intent
- Convert the interface of a class into another interface clients expect.
- Lets classes work together that couldn’t otherwise due to incompatible interfaces.

Example
- Your code expects IPaymentProcessor.Process(decimal amount).
- A legacy SDK provides LegacyPaymentSdk.PayInCents(int cents).
Adapter translates between them.
*/

// The interface our application wants to use.
public interface IPaymentProcessor
{
	void Process(decimal amount);
}

// Legacy / third-party class we cannot change.
public sealed class LegacyPaymentSdk
{
	public void PayInCents(int cents)
	{
		Console.WriteLine($"Legacy SDK paid {cents} cents");
	}
}

// Adapter: makes LegacyPaymentSdk look like IPaymentProcessor.
public sealed class LegacyPaymentAdapter : IPaymentProcessor
{
	private readonly LegacyPaymentSdk _legacy;

	public LegacyPaymentAdapter(LegacyPaymentSdk legacy)
	{
		_legacy = legacy;
	}

	public void Process(decimal amount)
	{
		// Convert dollars/gel/etc. to cents.
		var cents = (int)Math.Round(amount * 100m, MidpointRounding.AwayFromZero);
		_legacy.PayInCents(cents);
	}
}

public static class AdapterDemo
{
	// How to run:
	// - In a Console app, call: Session9_Adapter.AdapterDemo.Run();
	public static void Run()
	{
		IPaymentProcessor processor = new LegacyPaymentAdapter(new LegacyPaymentSdk());
		processor.Process(12.34m);
	}
}

