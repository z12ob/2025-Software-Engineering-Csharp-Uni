// Abstract Factory Design Pattern is a creational design pattern that provides an interface
// for creating families of related or dependent objects without specifying their concrete classes.

// Abstract products
interface IButton { void Draw(); }
interface ICheckbox { void Draw(); }

// Abstract factory
interface IGuiFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Windows products
class WinButton : IButton { public void Draw() => Console.WriteLine("Windows Button"); }
class WinCheckbox : ICheckbox { public void Draw() => Console.WriteLine("Windows Checkbox"); }

// Concrete Mac products
class MacButton : IButton { public void Draw() => Console.WriteLine("Mac Button"); }
class MacCheckbox : ICheckbox { public void Draw() => Console.WriteLine("Mac Checkbox"); }

// Concrete factories
class WindowsFactory : IGuiFactory
{
    public IButton CreateButton() => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}

class MacFactory : IGuiFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}

class Program
{
    static void Main()
    {
        IGuiFactory f = new WindowsFactory();
        f.CreateButton().Draw();
        f.CreateCheckbox().Draw();

        f = new MacFactory();
        f.CreateButton().Draw();
        f.CreateCheckbox().Draw();
    }
}
