#nullable enable

using System;

namespace Session4_Facade;

/*
FACADE (Structural)

Intent
- Provide a simplified interface to a complex subsystem.

Benefits
- Reduces dependencies on the subsystem.
- Makes the subsystem easier to use.

Typical uses
- When a system is complex and requires multiple classes to work together.
*/

public class SubsystemA
{
	public void OperationA() => Console.WriteLine("Subsystem A, Operation A");
}

public class SubsystemB
{
	public void OperationB() => Console.WriteLine("Subsystem B, Operation B");
}

public class Facade
{
	private readonly SubsystemA _subsystemA = new();
	private readonly SubsystemB _subsystemB = new();

	public void Operation() 
	{
		Console.WriteLine("Facade initializes subsystems:");
		_subsystemA.OperationA();
		_subsystemB.OperationB();
	}
}

public static class FacadeDemo
{
	// How to run:
	// - In a Console app, call: Session4_Facade.FacadeDemo.Run();
	public static void Run()
	{
		var facade = new Facade();
		facade.Operation();
	}
}

