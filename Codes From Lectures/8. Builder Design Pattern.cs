public class House
{
    public string Walls;
    public string Roof;
}
public interface IHouseBuilder
{
    void BuildWalls();
    void BuildRoof();
    House GetHouse();
}
public class HouseBuilder : IHouseBuilder
{
    private House house = new House();
    public void BuildWalls()
    {
        house.Walls = "Concrete walls";
    }
    public void BuildRoof()
    {
        house.Roof = "Metal roof";
    }
    public House GetHouse()
    {
        return house;
    }
}

IHouseBuilder builder = new HouseBuilder();

builder.BuildWalls();
builder.BuildRoof();

House house = builder.GetHouse();
