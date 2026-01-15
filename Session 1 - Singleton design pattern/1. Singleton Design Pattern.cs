// Singleton Design Pattern is a creational design pattern that ensures a class has only one instance
// and provides a global point of access to that instance.

class Singleton
{
    // Holds the single instance.
    private static Singleton instance;

    // Private constructor blocks new from outside.
    private Singleton() { }

    // Global access point.
    public static Singleton GetInstance()
    {
        // Create only once.
        if (instance == null)
            instance = new Singleton();

        // Always return the same object.
        return instance;
    }

    public void DoWork()
    {
        Console.WriteLine("Works");
    }
}

class Program
{
    static void Main()
    {
        // Both variables point to the same object.
        Singleton a = Singleton.GetInstance();
        Singleton b = Singleton.GetInstance();

        Console.WriteLine(object.ReferenceEquals(a, b));
    }
}
