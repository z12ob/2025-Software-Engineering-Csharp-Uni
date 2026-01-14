public interface IProduct
{
    void GetData();

}

public class Apple : IProduct
{
    public void GetData()
    {
        Console.WriteLine("I am Apple");
    }
}

public class Micro : IProduct
{
    public void GetData()
    {
        Console.WriteLine("I am Microsoft");
    }
}

public class Google : IProduct
{
    public void GetData()
    {
        Console.WriteLine("I am Google");
    }
}

public class ProductFactory
{
    public IProduct GetProduct(int i)
    {
        if (i == 1) 
            return new Apple();
        else if (i == 2)
            return new Micro();
        else 
            return new Google();
    }
}