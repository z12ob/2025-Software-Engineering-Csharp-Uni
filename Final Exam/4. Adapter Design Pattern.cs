// Adapter Design Pattern is a structural design pattern that allows
// incompatible interfaces to work together. It acts as a bridge between two incompatible interfaces.

// Target interface
interface ITarget
{
    string GetRequest();
}

// Adaptee with a different interface
class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific request.";
    }
}

// Adapter makes Adaptee's interface compatible with Target's interface
class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public string GetRequest()
    {
        return _adaptee.GetSpecificRequest();
    }
}

class Program
{
    static void Main()
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);

        Console.WriteLine(target.GetRequest()); // Outputs: Specific request.
    }
}
