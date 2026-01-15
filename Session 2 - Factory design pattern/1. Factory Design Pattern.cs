interface IProduct
{
    // Common operation for all products.
    void GetData();
}

// Concrete product.
class Apple : IProduct
{
    public void GetData()
    {
        Console.WriteLine("Apple");
    }
}

// Another concrete product.
class Google : IProduct
{
    public void GetData()
    {
        Console.WriteLine("Google");
    }
}

class ProductFactory
{
    // Factory decides which object to create.
    public IProduct Create(int type)
    {
        // Creation logic is hidden here.
        if (type == 1)
            return new Apple();
        else
            return new Google();
    }
}

class Program
{
    static void Main()
    {
        // Client talks to factory.
        ProductFactory factory = new ProductFactory();

        // Client depends on interface only.
        IProduct p = factory.Create(1);
        p.GetData();
    }
}
