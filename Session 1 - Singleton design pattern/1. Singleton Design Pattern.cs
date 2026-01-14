#nullable enable

using System;

namespace Session1_Singleton;

/*
SINGLETON (Creational)

Intent
- Ensure a class has exactly one instance.
- Provide a global access point to that instance.

Typical uses
- Process-wide configuration, shared cache, shared logger bridge.

Warnings
- Singleton is global state. It can hide dependencies and make testing harder.
- Prefer Dependency Injection for most services.

This example uses Lazy<T> (simple + thread-safe).
*/

public sealed class AppConfig
{
	// Thread-safe lazy initialization.
	private static readonly Lazy<AppConfig> _instance = new(() => new AppConfig());

	public static AppConfig Instance => _instance.Value;

	// Private constructor prevents external instantiation.
	private AppConfig() { }

	public string ApiBaseUrl { get; set; } = "https://api.example.com";
	public int TimeoutSeconds { get; set; } = 10;
}

public static class SingletonDemo
{
	// How to run:
	// - In a Console app, call: Session1_Singleton.SingletonDemo.Run();
	public static void Run()
	{
		var a = AppConfig.Instance;
		var b = AppConfig.Instance;

		Console.WriteLine($"Same instance? {ReferenceEquals(a, b)}");

		a.TimeoutSeconds = 30;
		Console.WriteLine($"b.TimeoutSeconds (should be 30): {b.TimeoutSeconds}");
	}
}

