#nullable disable

using System;

namespace Session8_AbstractFactory;

// ABSTRACT FACTORY pattern (simple lecture style)
// Create families of related objects.

public interface IButton
{
	void Draw();
}

public interface ICheckbox
{
	void Draw();
}

public interface IGuiFactory
{
	IButton CreateButton();
	ICheckbox CreateCheckbox();
}

public class WinButton : IButton
{
	public void Draw() { Console.WriteLine("Windows Button"); }
}

public class WinCheckbox : ICheckbox
{
	public void Draw() { Console.WriteLine("Windows Checkbox"); }
}

public class WindowsFactory : IGuiFactory
{
	public IButton CreateButton() { return new WinButton(); }
	public ICheckbox CreateCheckbox() { return new WinCheckbox(); }
}

public class MacButton : IButton
{
	public void Draw() { Console.WriteLine("Mac Button"); }
}

public class MacCheckbox : ICheckbox
{
	public void Draw() { Console.WriteLine("Mac Checkbox"); }
}

public class MacFactory : IGuiFactory
{
	public IButton CreateButton() { return new MacButton(); }
	public ICheckbox CreateCheckbox() { return new MacCheckbox(); }
}

public static class AbstractFactoryDemo
{
	public static void Run()
	{
		IGuiFactory factory = new WindowsFactory();
		factory.CreateButton().Draw();
		factory.CreateCheckbox().Draw();

		Console.WriteLine();

		factory = new MacFactory();
		factory.CreateButton().Draw();
		factory.CreateCheckbox().Draw();
	}
}

