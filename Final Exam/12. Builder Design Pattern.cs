// Builder Design Pattern is a creational design pattern that separates the construction of a complex object
// from its representation, allowing the same construction process to create different representations.

// Product
class House
{
    public string Walls;
    public string Roof;
    public string Door;

    public void Show()
    {
        Console.WriteLine(Walls + ", " + Roof + ", " + Door);
    }
}

// Builder builds step by step
class HouseBuilder
{
    private House house = new House();

    public HouseBuilder BuildWalls(string w) { house.Walls = w; return this; }
    public HouseBuilder BuildRoof(string r) { house.Roof = r; return this; }
    public HouseBuilder BuildDoor(string d) { house.Door = d; return this; }

    // Returns final product
    public House GetHouse() { return house; }
}

class Program
{
    static void Main()
    {
        House h = new HouseBuilder()
            .BuildWalls("Brick")
            .BuildRoof("Red")
            .BuildDoor("Wood")
            .GetHouse();

        h.Show();
    }
}
