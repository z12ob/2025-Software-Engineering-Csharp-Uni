// Facade Design Pattern is a structural design pattern that provides a simplified interface
// to a complex subsystem, making it easier for clients to interact with the system.
// It hides the complexities of the subsystem and provides a higher-level interface.

class Subsystem1
{
    public void Method1()
    {
        Console.WriteLine("Subsystem1");
    }
}

class Subsystem2
{
    public void Method2()
    {
        Console.WriteLine("Subsystem2");
    }
}

class Facade
{
    // Facade owns subsystem objects.
    private Subsystem1 s1 = new Subsystem1();
    private Subsystem2 s2 = new Subsystem2();

    // One simple method for the client.
    public void Operation()
    {
        // Facade coordinates subsystem calls.
        s1.Method1();
        s2.Method2();
    }
}

class Program
{
    static void Main()
    {
        // Client talks only to the facade.
        Facade f = new Facade();
        f.Operation();
    }
}
