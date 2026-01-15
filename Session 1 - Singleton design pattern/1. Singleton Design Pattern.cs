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
