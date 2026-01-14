#nullable enable

using System;

namespace Session8_AbstractFactory;

/*
ABSTRACT FACTORY (Creational)

Intent
- Provide an interface for creating families of related objects
  without specifying their concrete classes.

How it differs from Factory
- Factory Method usually creates ONE product.
- Abstract Factory creates a FAMILY of products that should work together.

Example here: UI widgets for different "themes" (Windows vs Mac).
*/

// Products (family members)
public interface IButton
{
	void Render();
}

public interface ICheckbox
{
	void Render();
}

// Abstract Factory
public interface IWidgetFactory
{
	IButton CreateButton();
	ICheckbox CreateCheckbox();
}

// Concrete products: Windows
public sealed class WindowsButton : IButton
{
	public void Render() => Console.WriteLine("[Windows] Button");
}

public sealed class WindowsCheckbox : ICheckbox
{
	public void Render() => Console.WriteLine("[Windows] Checkbox");
}

public sealed class WindowsWidgetFactory : IWidgetFactory
{
	public IButton CreateButton() => new WindowsButton();
	public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}

// Concrete products: Mac
public sealed class MacButton : IButton
{
	public void Render() => Console.WriteLine("[Mac] Button");
}

public sealed class MacCheckbox : ICheckbox
{
	public void Render() => Console.WriteLine("[Mac] Checkbox");
}

public sealed class MacWidgetFactory : IWidgetFactory
{
	public IButton CreateButton() => new MacButton();
	public ICheckbox CreateCheckbox() => new MacCheckbox();
}

// Client code depends only on the abstract factory and product interfaces.
public sealed class SettingsScreen
{
	private readonly IButton _saveButton;
	private readonly ICheckbox _analyticsCheckbox;

	public SettingsScreen(IWidgetFactory factory)
	{
		_saveButton = factory.CreateButton();
		_analyticsCheckbox = factory.CreateCheckbox();
	}

	public void Render()
	{
		_saveButton.Render();
		_analyticsCheckbox.Render();
	}
}

public static class AbstractFactoryDemo
{
	// How to run:
	// - In a Console app, call: Session8_AbstractFactory.AbstractFactoryDemo.Run();
	public static void Run()
	{
		IWidgetFactory factory = new WindowsWidgetFactory();
		var windowsScreen = new SettingsScreen(factory);
		windowsScreen.Render();

		Console.WriteLine();

		factory = new MacWidgetFactory();
		var macScreen = new SettingsScreen(factory);
		macScreen.Render();
	}
}

