// Facade Design Pattern is a structural design pattern that provides a simplified interface
// to a complex subsystem, making it easier for clients to interact with the system.

// Subsystems
class CPU
{
    public void Freeze() => Console.WriteLine("CPU: Freeze");
    public void Jump(long pos) => Console.WriteLine("CPU: Jump " + pos);
    public void Execute() => Console.WriteLine("CPU: Execute");
}

class Memory
{
    public void Load(long pos, string data) => Console.WriteLine("Memory: Load " + data + " at " + pos);
}

class HardDrive
{
    public string Read(long lba, int size) => "DATA";
}

// Facade provides simple interface
class ComputerFacade
{
    private CPU cpu = new CPU();
    private Memory memory = new Memory();
    private HardDrive hd = new HardDrive();

    public void Start()
    {
        cpu.Freeze();
        string data = hd.Read(0, 1024);
        memory.Load(0, data);
        cpu.Jump(0);
        cpu.Execute();
    }
}

class Program
{
    static void Main()
    {
        ComputerFacade pc = new ComputerFacade();
        pc.Start(); // Client calls one method instead of multiple subsystems
    }
}
