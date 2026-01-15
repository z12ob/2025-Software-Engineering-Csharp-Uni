interface IShape
{
    // Behavior is abstract.
    double Area();
}

// Existing class.
class Rectangle : IShape
{
    public double W, H;

    public Rectangle(double w, double h)
    {
        W = w;
        H = h;
    }

    public double Area()
    {
        return W * H;
    }
}

// New class added later.
// No existing code is touched.
class Circle : IShape
{
    public double R;

    public Circle(double r)
    {
        R = r;
    }

    public double Area()
    {
        return Math.PI * R * R;
    }
}

class AreaCalculator
{
    // Closed for modification.
    // Works for any new shape.
    public double TotalArea(List<IShape> shapes)
    {
        double sum = 0;
        foreach (IShape s in shapes)
            sum += s.Area();

        return sum;
    }
}

class Program
{
    static void Main()
    {
        List<IShape> shapes = new List<IShape>();
        shapes.Add(new Rectangle(3, 4));
        shapes.Add(new Circle(2));

        AreaCalculator c = new AreaCalculator();
        Console.WriteLine(c.TotalArea(shapes));
    }
}
