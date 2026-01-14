#nullable enable

using System;

namespace Session10_Facade;

/*
FACADE (Structural)

Intent
- Offer a simple API for a complex subsystem.

This example uses a "Home Theater" subsystem.
Without a facade, the client must coordinate multiple classes in the right order.
With a facade, the client calls WatchMovie() and EndMovie().
*/

public sealed class Amplifier
{
	public void On() => Console.WriteLine("Amplifier: on");
	public void Off() => Console.WriteLine("Amplifier: off");
	public void SetVolume(int level) => Console.WriteLine($"Amplifier: volume {level}");
}

public sealed class DvdPlayer
{
	public void On() => Console.WriteLine("DVD: on");
	public void Off() => Console.WriteLine("DVD: off");
	public void Play(string movie) => Console.WriteLine($"DVD: playing '{movie}'");
	public void Stop() => Console.WriteLine("DVD: stop");
}

public sealed class Projector
{
	public void On() => Console.WriteLine("Projector: on");
	public void Off() => Console.WriteLine("Projector: off");
	public void WideScreenMode() => Console.WriteLine("Projector: widescreen mode");
}

public sealed class TheaterLights
{
	public void Dim(int level) => Console.WriteLine($"Lights: dim to {level}%");
	public void On() => Console.WriteLine("Lights: on");
}

// The Facade: simple methods for common use cases.
public sealed class HomeTheaterFacade
{
	private readonly Amplifier _amp;
	private readonly DvdPlayer _dvd;
	private readonly Projector _projector;
	private readonly TheaterLights _lights;

	public HomeTheaterFacade(Amplifier amp, DvdPlayer dvd, Projector projector, TheaterLights lights)
	{
		_amp = amp;
		_dvd = dvd;
		_projector = projector;
		_lights = lights;
	}

	public void WatchMovie(string movie)
	{
		Console.WriteLine("\nGet ready to watch a movie...");
		_lights.Dim(10);
		_projector.On();
		_projector.WideScreenMode();
		_amp.On();
		_amp.SetVolume(7);
		_dvd.On();
		_dvd.Play(movie);
	}

	public void EndMovie()
	{
		Console.WriteLine("\nShutting movie theater down...");
		_dvd.Stop();
		_dvd.Off();
		_amp.Off();
		_projector.Off();
		_lights.On();
	}
}

public static class FacadeDemo
{
	// How to run:
	// - In a Console app, call: Session10_Facade.FacadeDemo.Run();
	public static void Run()
	{
		var theater = new HomeTheaterFacade(
			new Amplifier(),
			new DvdPlayer(),
			new Projector(),
			new TheaterLights());

		theater.WatchMovie("Design Patterns: The Movie");
		theater.EndMovie();
	}
}

