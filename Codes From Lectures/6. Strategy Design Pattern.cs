public interface IStrategy
{
    void Execute();
}
public class AddStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Addition");
    }
}
public class MultiplyStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Multiplication");
    }
}
public class Context
{
    private IStrategy strategy;
    public void SetStrategy(IStrategy s)
    {
        strategy = s;
    }
    public void Run()
    {
        strategy.Execute();
    }
}

Context context = new Context();
context.SetStrategy(new AddStrategy());
context.Run();
context.SetStrategy(new MultiplyStrategy());
context.Run();
