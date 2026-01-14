public interface IState
{
    void Handle();
}
public class OnState : IState
{
    public void Handle()
    {
        Console.WriteLine("Device is ON");
    }
}
public class OffState : IState
{
    public void Handle()
    {
        Console.WriteLine("Device is OFF");
    }
}
public class Device
{
    private IState state;
    public void SetState(IState newState)
    {
        state = newState;
    }
    public void PressButton()
    {
        state.Handle();
    }
}

Device device = new Device();
device.SetState(new OnState());
device.PressButton();
device.SetState(new OffState());
device.PressButton();
