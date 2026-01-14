using State.Structural;

ConcreteStateA a = new ConcreteStateA();
var context = new Context( a );

context.Request();

context.Request();

context.Request();

context.Request();

// Wait for user

Console.ReadKey();
