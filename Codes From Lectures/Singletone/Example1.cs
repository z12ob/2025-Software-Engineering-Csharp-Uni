interface ICar 
{
    void GetData();
}

public class BMW : ICar
{
    public void GetData()
    {
        Console.WriteLine("I am BMW");
    }
}

public class Mercedes : ICar
{
    public void GetData()
    {
        Console.WriteLine("I am Mercedes");
    }
}