using StatePattern3;

// Demo of simple event-driven state machine
var ctx = new ProcessContext(); // starts in Ordered
Console.WriteLine($"Current: {ctx.StateName}");

// Event 1: Create => Ordered -> Created
ctx.Create();
Console.WriteLine($"Current: {ctx.StateName}");

// Event 2: Disburse => Created -> Active
ctx.Disburse();
Console.WriteLine($"Current: {ctx.StateName}");

// Extra: calling Disburse again has no effect but is handled gracefully
ctx.Disburse();
