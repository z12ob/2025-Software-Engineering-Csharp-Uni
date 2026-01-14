#nullable disable

using System;

namespace Session10_Facade;

// FACADE (simple lecture style)
// One method does many subsystem steps.

public class CPU
{
	public void Freeze() { Console.WriteLine("CPU: Freeze"); }
	public void Jump(long position) { Console.WriteLine("CPU: Jump " + position); }
	public void Execute() { Console.WriteLine("CPU: Execute"); }
}

public class Memory
{
	public void Load(long position, string data)
	{
		Console.WriteLine("Memory: Load " + data + " at " + position);
	}
}

public class HardDrive
{
	public string Read(long lba, int size)
	{
		return "DATA";
	}
}

public class ComputerFacade
{
	private CPU cpu;
	private Memory memory;
	private HardDrive hardDrive;

	public ComputerFacade()
	{
		cpu = new CPU();
		memory = new Memory();
		hardDrive = new HardDrive();
	}

	public void Start()
	{
		cpu.Freeze();
		string data = hardDrive.Read(0, 1024);
		memory.Load(0, data);
		cpu.Jump(0);
		cpu.Execute();
	}
}

public static class FacadeDemo
{
	public static void Run()
	{
		ComputerFacade pc = new ComputerFacade();
		pc.Start();
	}
}

