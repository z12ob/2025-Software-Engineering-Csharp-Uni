#nullable disable

using System;

namespace Session6_SOLID_SRP;

// SRP: one class = one responsibility.

public class Report
{
	public string Title;
	public string Text;

	public Report(string title, string text)
	{
		Title = title;
		Text = text;
	}
}

public class ReportPrinter
{
	public void Print(Report report)
	{
		Console.WriteLine("--- PRINT ---");
		Console.WriteLine(report.Title);
		Console.WriteLine(report.Text);
	}
}

public class ReportSaver
{
	public void Save(Report report)
	{
		Console.WriteLine("--- SAVE ---");
		Console.WriteLine("Saved: " + report.Title);
	}
}

public static class SrpDemo
{
	public static void Run()
	{
		Report report = new Report("SRP Example", "Printing and Saving are separate.");
		new ReportPrinter().Print(report);
		new ReportSaver().Save(report);
	}
}

