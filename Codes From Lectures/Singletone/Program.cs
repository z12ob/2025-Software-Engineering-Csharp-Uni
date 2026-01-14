using Singletone;

/*

Person x = new Person("John", 25);

Person y = new Person("Giorgi", 30);
Console.WriteLine(Person.Country);

*/

Singleton singleton = Singleton.getInstance();
Singleton singleton2 = Singleton.getInstance();

ICar car = new BMW();
car.GetData();

car = new Mercedes();
car.GetData();

BMW bmw = new BMW();
bmw.GetData();