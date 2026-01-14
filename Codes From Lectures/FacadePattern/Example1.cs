public class DVDplayer
{
    public void Play() => Console.WriteLine("The DVD player is playing");
    public void Stop() => Console.WriteLine("The DVD player is stopped");
}

public class Screen
{
    public void Lower()
    {
        Console.WriteLine("The screen is lowering");
    }
    public void Upper() => Console.WriteLine("The screen is going up");
}

public class Lights()
{
    public void On() => Console.WriteLine("The lights are on");
    public void Off() => Console.WriteLine("The lights are off");
}

public class Projector()
{
    public void On() => Console.WriteLine("The projector is on");
    public void Off() => Console.WriteLine("The projector is off");
}

public class Facade
{
    private DVDplayer dvdplayer;
    private Screen screen;
    private Lights lights;
    private Projector projector;

    public Facade()
    {
        dvdplayer = new DVDplayer();
        screen = new Screen();
        lights = new Lights();
        projector = new Projector();
    }

    public void StartMovie()
    {
        screen.Lower();
        lights.Off();
        projector.On();
        dvdplayer.Play();
    }

    public void EndMovie()
    {
        dvdplayer.Stop();
        lights.On();
        projector.Off();
        screen.Upper();
    }
}