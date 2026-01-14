public abstract class Handler
{
    protected Handler next;
    public void SetNext(Handler handler)
    {
        next = handler;
    }
    public abstract void Handle(int value);
}
public class SmallNumberHandler : Handler
{
    public override void Handle(int value)
    {
        if (value < 10)
            Console.WriteLine("Handled by SmallNumberHandler");
        else if (next != null)
            next.Handle(value);
    }
}
public class LargeNumberHandler : Handler
{
    public override void Handle(int value)
    {
        if (value >= 10)
            Console.WriteLine("Handled by LargeNumberHandler");
    }
}

Handler h1 = new SmallNumberHandler();
Handler h2 = new LargeNumberHandler();

h1.SetNext(h2);
h1.Handle(5);
h1.Handle(20);
