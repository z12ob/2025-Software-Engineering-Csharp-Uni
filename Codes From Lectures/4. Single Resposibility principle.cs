public class UserManager 
{ 
    public void CreateUser(string name) 
    { 
        Console.WriteLine("User created"); 
    } 
} 
 
public class Logger 
{ 
    public void Log(string message) 
    { 
        Console.WriteLine(message); 
    } 
}
// გამოყენება:
// UserManager userManager = new UserManager();
// userManager.CreateUser("JohnDoe");