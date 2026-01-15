// Base handler
abstract class Handler
{
    protected Handler next;

    public void SetNext(Handler next) { this.next = next; }

    public abstract void Handle(int amount);
}

// Handles hundreds
class HundredsHandler : Handler
{
    public override void Handle(int amount)
    {
        if (amount >= 100)
            Console.WriteLine("Hundreds: " + amount);
        else
            next?.Handle(amount); // pass to next
    }
}

// Handles fifties
class FiftiesHandler : Handler
{
    public override void Handle(int amount)
    {
        if (amount >= 50)
            Console.WriteLine("Fifties: " + amount);
        else
            next?.Handle(amount);
    }
}

// Default handler
class TensHandler : Handler
{
    public override void Handle(int amount)
    {
        Console.WriteLine("Tens (default): " + amount);
    }
}

class Program
{
    static void Main()
    {
        // Build the chain
        Handler h1 = new HundredsHandler();
        Handler h2 = new FiftiesHandler();
        Handler h3 = new TensHandler();

        h1.SetNext(h2);
        h2.SetNext(h3);

        h1.Handle(120);
        h1.Handle(70);
        h1.Handle(20);
    }
}
