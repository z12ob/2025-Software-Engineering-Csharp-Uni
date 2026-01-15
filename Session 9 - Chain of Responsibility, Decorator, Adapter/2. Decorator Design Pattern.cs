// Base component
interface ICoffee
{
    string GetDescription();
    int GetCost();
}

// Concrete component
class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Coffee";
    public int GetCost() => 5;
}

// Base decorator
abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;
    protected CoffeeDecorator(ICoffee coffee) { this.coffee = coffee; }
    public virtual string GetDescription() => coffee.GetDescription();
    public virtual int GetCost() => coffee.GetCost();
}

// Add milk behavior
class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }
    public override string GetDescription() => coffee.GetDescription() + "+Milk";
    public override int GetCost() => coffee.GetCost() + 2;
}

// Add sugar behavior
class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }
    public override string GetDescription() => coffee.GetDescription() + "+Sugar";
    public override int GetCost() => coffee.GetCost() + 1;
}

class Program
{
    static void Main()
    {
        ICoffee coffee = new SimpleCoffee();
        coffee = new MilkDecorator(coffee);
        coffee = new SugarDecorator(coffee);

        Console.WriteLine(coffee.GetDescription()); // Coffee+Milk+Sugar
        Console.WriteLine(coffee.GetCost());        // 8
    }
}
