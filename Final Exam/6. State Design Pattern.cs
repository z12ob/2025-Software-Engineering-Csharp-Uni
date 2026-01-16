// State Design Pattern is a behavioral design pattern that allows an object
// to change its behavior when its internal state changes. The object will appear to change its class.

interface ITVState
{
    // State handles behavior.
    void PressPower(TV tv);
}

class TV
{
    // Current state object.
    private ITVState state;

    public TV()
    {
        // Initial state.
        state = new TvOffState();
    }

    // State transition happens here.
    public void SetState(ITVState newState)
    {
        state = newState;
    }

    // Context delegates behavior to state.
    public void PressPower()
    {
        state.PressPower(this);
    }
}

// Concrete state.
class TvOnState : ITVState
{
    public void PressPower(TV tv)
    {
        Console.WriteLine("ON -> OFF");
        // Change state at runtime.
        tv.SetState(new TvOffState());
    }
}

// Concrete state.
class TvOffState : ITVState
{
    public void PressPower(TV tv)
    {
        Console.WriteLine("OFF -> ON");
        tv.SetState(new TvOnState());
    }
}

class Program
{
    static void Main()
    {
        TV tv = new TV();

        // Same call. Different behavior.
        tv.PressPower();
        tv.PressPower();
    }
}
