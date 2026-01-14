#nullable enable

using System;

namespace Session9_ChainOfResponsibility;

/*
CHAIN OF RESPONSIBILITY (Behavioral)

Intent
- Pass a request along a chain of handlers.
- Each handler decides to either handle the request or pass it to the next.

Benefits
- Decouples sender from receivers.
- Easy to add/reorder handlers.

Example: support tickets are routed by category.
*/

public enum TicketCategory
{
	Billing,
	Technical,
	General
}

public sealed class SupportTicket
{
	public required TicketCategory Category { get; init; }
	public required string Message { get; init; }
}

public abstract class TicketHandler
{
	private TicketHandler? _next;

	public TicketHandler SetNext(TicketHandler next)
	{
		_next = next;
		return next;
	}

	public void Handle(SupportTicket ticket)
	{
		if (!TryHandle(ticket) && _next is not null)
		{
			_next.Handle(ticket);
		}
	}

	// Return true if handled, false if should pass to next.
	protected abstract bool TryHandle(SupportTicket ticket);
}

public sealed class BillingHandler : TicketHandler
{
	protected override bool TryHandle(SupportTicket ticket)
	{
		if (ticket.Category != TicketCategory.Billing) return false;

		Console.WriteLine($"[Billing] Handled: {ticket.Message}");
		return true;
	}
}

public sealed class TechnicalHandler : TicketHandler
{
	protected override bool TryHandle(SupportTicket ticket)
	{
		if (ticket.Category != TicketCategory.Technical) return false;

		Console.WriteLine($"[Tech] Handled: {ticket.Message}");
		return true;
	}
}

public sealed class FallbackHandler : TicketHandler
{
	protected override bool TryHandle(SupportTicket ticket)
	{
		Console.WriteLine($"[General] Handled: {ticket.Message}");
		return true;
	}
}

public static class ChainDemo
{
	// How to run:
	// - In a Console app, call: Session9_ChainOfResponsibility.ChainDemo.Run();
	public static void Run()
	{
		// Build the chain.
		var billing = new BillingHandler();
		var tech = new TechnicalHandler();
		var fallback = new FallbackHandler();

		billing.SetNext(tech).SetNext(fallback);

		billing.Handle(new SupportTicket { Category = TicketCategory.Technical, Message = "App crashes on startup" });
		billing.Handle(new SupportTicket { Category = TicketCategory.Billing, Message = "Refund request" });
		billing.Handle(new SupportTicket { Category = TicketCategory.General, Message = "How do I change my password?" });
	}
}

