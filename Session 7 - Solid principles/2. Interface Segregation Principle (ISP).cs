// Split interfaces to avoid forcing unnecessary methods
interface IPrinter
{
    void Print();
}

interface IScanner
{
    void Scan();
}

// Implements only what it needs
class SimplePrinter : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Printing...");
    }
}

// Implements multiple interfaces if needed
class AllInOne : IPrinter, IScanner
{
    public void Print()
    {
        Console.WriteLine("Printing...");
    }

    public void Scan()
    {
        Console.WriteLine("Scanning...");
    }
}

class Program
{
    static void Main()
    {
        IPrinter p = new SimplePrinter();
        p.Print(); // Only printing behavior

        AllInOne a = new AllInOne();
        a.Print();
        a.Scan(); // Both behaviors
    }
}
