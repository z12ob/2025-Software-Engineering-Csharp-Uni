// Dependency Inversion Principle (DIP) states that high-level modules should not depend on low-level modules.
// Both should depend on abstractions. Abstractions should not depend on details.

// High-level code depends on abstraction, not concrete classes
interface IMessageSender
{
    void Send(string message);
}

// Concrete implementation 1
class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine("Email: " + message);
    }
}

// Concrete implementation 2
class SmsSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine("SMS: " + message);
    }
}

// High-level module depends on interface
class Notification
{
    private IMessageSender sender;

    // Dependency injected via constructor
    public Notification(IMessageSender sender)
    {
        this.sender = sender;
    }

    public void Notify(string message)
    {
        sender.Send(message);
    }
}

class Program
{
    static void Main()
    {
        Notification n1 = new Notification(new EmailSender());
        n1.Notify("Hello DIP");

        Notification n2 = new Notification(new SmsSender());
        n2.Notify("Same Notification, different sender");
    }
}
