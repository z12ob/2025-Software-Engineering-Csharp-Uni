// Base class has only safe behaviors.
abstract class Bird
{
    public void Eat()
    {
        Console.WriteLine("Bird eats");
    }
}

// Separate interface for flying capability.
interface IFly
{
    void Fly();
}

// Can fly, implements IFly.
class Sparrow : Bird, IFly
{
    public void Fly()
    {
        Console.WriteLine("Sparrow flies");
    }
}

// Cannot fly. Extra behavior is separate.
class Penguin : Bird
{
    public void Swim()
    {
        Console.WriteLine("Penguin swims");
    }
}

class Program
{
    static void Main()
    {
        Bird s = new Sparrow();
        s.Eat();
        ((IFly)s).Fly();  // Only birds that fly implement IFly

        Bird p = new Penguin();
        p.Eat();
        ((Penguin)p).Swim(); // Only penguin swims
    }
}
