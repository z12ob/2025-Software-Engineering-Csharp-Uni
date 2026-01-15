// Adapter Design Pattern is a structural design pattern that allows objects with incompatible interfaces
// to work together. It acts as a bridge between two incompatible interfaces.

// Target interface expected by client
interface ITarget
{
    void Request();
}

// Existing class with incompatible interface
class Adaptee
{
    public void SpecificRequest() => Console.WriteLine("Adaptee: SpecificRequest");
}

// Adapter converts Adaptee to ITarget
class Adapter : ITarget
{
    private Adaptee adaptee;
    public Adapter(Adaptee a) { adaptee = a; }
    public void Request() => adaptee.SpecificRequest();
}

class Program
{
    static void Main()
    {
        ITarget target = new Adapter(new Adaptee());
        target.Request(); // Client works with target interface
    }
}
