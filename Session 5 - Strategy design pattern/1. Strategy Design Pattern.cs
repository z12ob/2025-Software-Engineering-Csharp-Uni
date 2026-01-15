interface IStrategy
{
    // Common algorithm interface.
    int DoOperation(int a, int b);
}

// One concrete algorithm.
class AddStrategy : IStrategy
{
    public int DoOperation(int a, int b)
    {
        return a + b;
    }
}

// Another concrete algorithm.
class MultiplyStrategy : IStrategy
{
    public int DoOperation(int a, int b)
    {
        return a * b;
    }
}

class Context
{
    // Holds current strategy.
    private IStrategy strategy;

    // Strategy is injected.
    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    // Strategy is changeable at runtime.
    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    // Context delegates work to strategy.
    public int Execute(int a, int b)
    {
        return strategy.DoOperation(a, b);
    }
}

class Program
{
    static void Main()
    {
        Context c = new Context(new AddStrategy());
        Console.WriteLine(c.Execute(10, 5));

        // Same context. Different behavior.
        c.SetStrategy(new MultiplyStrategy());
        Console.WriteLine(c.Execute(10, 5));
    }
}
