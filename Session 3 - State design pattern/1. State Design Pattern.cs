#nullable disable

using System;

namespace Session3_State;

// STATE pattern (simple lecture style)
// TV changes behavior based on its current state (ON/OFF).

public interface ITVState
{
	void PressPower(TV tv);
}

public class TV
{
	private ITVState state;

	public TV()
	{
		state = new TvOffState();
	}

	public void SetState(ITVState newState)
	{
		state = newState;
	}

	public void PressPower()
	{
		state.PressPower(this);
	}
}

public class TvOnState : ITVState
{
	public void PressPower(TV tv)
	{
		Console.WriteLine("TV is ON -> turning OFF");
		tv.SetState(new TvOffState());
	}
}

public class TvOffState : ITVState
{
	public void PressPower(TV tv)
	{
		Console.WriteLine("TV is OFF -> turning ON");
		tv.SetState(new TvOnState());
	}
}

public static class StateDemo
{
	public static void Run()
	{
		TV tv = new TV();
		tv.PressPower();
		tv.PressPower();
		tv.PressPower();
	}
}

