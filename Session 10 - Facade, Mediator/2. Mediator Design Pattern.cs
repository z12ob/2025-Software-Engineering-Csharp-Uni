// Mediator Design Pattern is a behavioral design pattern that defines an object
// that encapsulates how a set of objects interact. This pattern promotes loose coupling
// by keeping objects from referring to each other explicitly, and it lets you vary
// their interaction independently.

// Mediator handles communication
class ChatRoom
{
    private List<User> users = new List<User>();

    public void Register(User u)
    {
        users.Add(u);
        u.SetRoom(this);
    }

    public void Send(string from, string to, string msg)
    {
        foreach (var u in users)
        {
            if (u.Name == to)
            {
                u.Receive(from, msg);
                return;
            }
        }
        Console.WriteLine("User not found: " + to);
    }
}

// Colleague communicates through mediator
class User
{
    private ChatRoom room;
    public string Name;

    public User(string name) { Name = name; }

    public void SetRoom(ChatRoom r) { room = r; }

    public void Send(string to, string msg) => room.Send(Name, to, msg);

    public void Receive(string from, string msg) => Console.WriteLine($"{Name} received from {from}: {msg}");
}

class Program
{
    static void Main()
    {
        ChatRoom room = new ChatRoom();
        User a = new User("Ana");
        User b = new User("Gio");

        room.Register(a);
        room.Register(b);

        a.Send("Gio", "Hello");
        b.Send("Ana", "Hi");
    }
}
