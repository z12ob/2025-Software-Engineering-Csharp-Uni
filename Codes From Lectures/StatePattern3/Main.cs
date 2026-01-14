using System;
namespace StatePattern3;

// State contract: define allowed events on the process
// Refactored to use an abstract base class instead of an interface
public abstract class ProcessState
{
    public abstract string Name { get; }

    // Provide safe defaults; concrete states override allowed transitions
    public virtual void Create(ProcessContext context)
    {
        Console.WriteLine($"Create not allowed in {Name} state.");
    }

    public virtual void Disburse(ProcessContext context)
    {
        Console.WriteLine($"Disburse not allowed in {Name} state.");
    }
}

// Context: manages the current state and exposes events
public class ProcessContext
{
    private ProcessState _state;

    public ProcessContext()
    {
        _state = new OrderedState();
        Console.WriteLine($"Initialized in state: {_state.Name}");
    }

    public string StateName => _state.Name;

    internal void TransitionTo(ProcessState newState)
    {
        Console.WriteLine($"Transition: {_state.Name} -> {newState.Name}");
        _state = newState;
    }

    // Events
    public void Create() => _state.Create(this);
    public void Disburse() => _state.Disburse(this);
}

// Ordered state: only allows Create -> Created
public class OrderedState : ProcessState
{
    public string Name => "Ordered";

    public override void Create(ProcessContext context)
    {
        context.TransitionTo(new CreatedState());
    }

    public override void Disburse(ProcessContext context)
    {
        Console.WriteLine("Disburse not allowed in Ordered state. Call Create first.");
    }
}

// Created state: only allows Disburse -> Active
public class CreatedState : ProcessState
{
    public string Name => "Created";

    public override void Create(ProcessContext context)
    {
        Console.WriteLine("Already Created. No transition performed.");
    }

    public override void Disburse(ProcessContext context)
    {
        context.TransitionTo(new ActiveState());
    }
}

// Active state: terminal for this example (no further transitions)
public class ActiveState : ProcessState
{
    public string Name => "Active";

    public override void Create(ProcessContext context)
    {
        Console.WriteLine("Create not allowed in Active state.");
    }

    public override void Disburse(ProcessContext context)
    {
        Console.WriteLine("Already Active. Disburse has no effect.");
    }
}
