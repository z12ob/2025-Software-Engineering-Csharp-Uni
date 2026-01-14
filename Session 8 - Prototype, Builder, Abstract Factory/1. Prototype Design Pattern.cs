#nullable enable

using System;
using System.Collections.Generic;

namespace Session8_Prototype;

/*
PROTOTYPE (Creational)

Intent
- Create new objects by copying (cloning) existing ones.

Why it’s useful
- When object creation is expensive.
- When you want a "template" instance and then create variations quickly.

Important detail: shallow vs deep copy
- Shallow copy: references inside the object are shared.
- Deep copy: nested objects are also cloned (no shared references).
*/

public interface IPrototype<T>
{
	T Clone();
}

public sealed class Document : IPrototype<Document>
{
	public required string Title { get; set; }

	// Nested reference-type data.
	public List<Page> Pages { get; } = new();

	// Deep clone implementation.
	public Document Clone()
	{
		var copy = new Document { Title = Title };
		foreach (var page in Pages)
		{
			copy.Pages.Add(page.Clone());
		}

		return copy;
	}
}

public sealed class Page : IPrototype<Page>
{
	public required string Text { get; set; }

	public Page Clone()
	{
		// Strings are immutable, so copying the reference is safe.
		return new Page { Text = Text };
	}
}

public static class PrototypeDemo
{
	// How to run:
	// - In a Console app, call: Session8_Prototype.PrototypeDemo.Run();
	public static void Run()
	{
		var template = new Document { Title = "Exam Template" };
		template.Pages.Add(new Page { Text = "Page 1: Introduction" });
		template.Pages.Add(new Page { Text = "Page 2: Questions" });

		var versionA = template.Clone();
		versionA.Title = "Exam A";
		versionA.Pages[1].Text = "Page 2: Questions (Variant A)";

		var versionB = template.Clone();
		versionB.Title = "Exam B";

		Console.WriteLine($"Template Title: {template.Title}");
		Console.WriteLine($"Template Page2: {template.Pages[1].Text}");
		Console.WriteLine();

		Console.WriteLine($"VersionA Title: {versionA.Title}");
		Console.WriteLine($"VersionA Page2: {versionA.Pages[1].Text}");
		Console.WriteLine();

		Console.WriteLine($"VersionB Title: {versionB.Title}");
		Console.WriteLine($"VersionB Page2: {versionB.Pages[1].Text}");
	}
}

