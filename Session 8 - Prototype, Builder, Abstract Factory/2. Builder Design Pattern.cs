#nullable disable

using System;

namespace Session8_Builder;

// BUILDER pattern (simple lecture style)
// Build an object step-by-step.

public class House
{
	public string Walls;
	public string Roof;
	public string Door;

	public void Show()
	{
		Console.WriteLine("House: " + Walls + ", " + Roof + ", " + Door);
	}
}

public class HouseBuilder
{
	private House house;

	public HouseBuilder()
	{
		house = new House();
	}

	public HouseBuilder BuildWalls(string walls)
	{
		house.Walls = walls;
		return this;
	}

	public HouseBuilder BuildRoof(string roof)
	{
		house.Roof = roof;
		return this;
	}

	public HouseBuilder BuildDoor(string door)
	{
		house.Door = door;
		return this;
	}

	public House GetHouse()
	{
		return house;
	}
}

public static class BuilderDemo
{
	public static void Run()
	{
		HouseBuilder builder = new HouseBuilder();
		House house = builder
			.BuildWalls("Brick walls")
			.BuildRoof("Red roof")
			.BuildDoor("Wood door")
			.GetHouse();

		house.Show();
	}
}

