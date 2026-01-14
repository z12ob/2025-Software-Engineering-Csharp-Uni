using System;

static void PrintMenu()
{
    Console.WriteLine("\nDesign Patterns Study Runner");
    Console.WriteLine("---------------------------");
    Console.WriteLine(" 1) Singleton");
    Console.WriteLine(" 2) Factory");
    Console.WriteLine(" 3) State");
    Console.WriteLine(" 4) Facade (Session 4)");
    Console.WriteLine(" 5) Strategy");
    Console.WriteLine(" 6) SRP");
    Console.WriteLine(" 7) OCP");
    Console.WriteLine(" 8) LSP");
    Console.WriteLine(" 9) ISP");
    Console.WriteLine("10) DIP");
    Console.WriteLine("11) Prototype");
    Console.WriteLine("12) Builder");
    Console.WriteLine("13) Abstract Factory");
    Console.WriteLine("14) Chain of Responsibility");
    Console.WriteLine("15) Decorator");
    Console.WriteLine("16) Adapter");
    Console.WriteLine("17) Facade (Session 10)");
    Console.WriteLine("18) Mediator");
    Console.WriteLine(" 0) Exit");
    Console.Write("Choose: ");
}

while (true)
{
    PrintMenu();
    var input = Console.ReadLine();

    if (!int.TryParse(input, out var choice))
        continue;

    Console.WriteLine();

    switch (choice)
    {
        case 0:
            return;
        case 1:
            Session1_Singleton.SingletonDemo.Run();
            break;
        case 2:
            Session2_Factory.FactoryDemo.Run();
            break;
        case 3:
            Session3_State.StateDemo.Run();
            break;
        case 4:
            Session4_Facade.FacadeDemo.Run();
            break;
        case 5:
            Session5_Strategy.StrategyDemo.Run();
            break;
        case 6:
            Session6_SOLID_SRP.SrpDemo.Run();
            break;
        case 7:
            Session6_SOLID_OCP.OcpDemo.Run();
            break;
        case 8:
            Session7_SOLID_LSP.LspDemo.Run();
            break;
        case 9:
            Session7_SOLID_ISP.IspDemo.Run();
            break;
        case 10:
            Session7_SOLID_DIP.DipDemo.Run();
            break;
        case 11:
            Session8_Prototype.PrototypeDemo.Run();
            break;
        case 12:
            Session8_Builder.BuilderDemo.Run();
            break;
        case 13:
            Session8_AbstractFactory.AbstractFactoryDemo.Run();
            break;
        case 14:
            Session9_ChainOfResponsibility.ChainDemo.Run();
            break;
        case 15:
            Session9_Decorator.DecoratorDemo.Run();
            break;
        case 16:
            Session9_Adapter.AdapterDemo.Run();
            break;
        case 17:
            Session10_Facade.FacadeDemo.Run();
            break;
        case 18:
            Session10_Mediator.MediatorDemo.Run();
            break;
        default:
            Console.WriteLine("Unknown choice.");
            break;
    }
}
