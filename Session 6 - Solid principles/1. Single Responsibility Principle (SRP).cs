#nullable enable

using System;

namespace Session6_SOLID_SRP;

/*
SRP — Single Responsibility Principle

Definition
- "A class should have only one reason to change."

How to spot SRP violations
- A single class does: business rules + formatting + persistence + networking.
- Changes in one area force you to modify the same class.

Goal
- Separate responsibilities into focused classes.
*/

// Small domain model.
public sealed class StudentGrade
{
	public required string StudentName { get; init; }
	public required string Course { get; init; }
	public required int Score { get; init; }
}

// Responsibility #1: Formatting only.
public static class GradeReportFormatter
{
	public static string Format(StudentGrade grade)
	{
		// If you later want JSON or HTML, only this formatter changes.
		return $"Student: {grade.StudentName}\nCourse: {grade.Course}\nScore: {grade.Score}";
	}
}

// Responsibility #2: Storage only.
public interface IReportStore
{
	void Save(string reportText);
}

public sealed class ConsoleReportStore : IReportStore
{
	public void Save(string reportText)
	{
		Console.WriteLine("--- SAVED REPORT ---");
		Console.WriteLine(reportText);
	}
}

// Responsibility #3: Orchestration / workflow only.
public sealed class GradeReportService
{
	private readonly IReportStore _store;

	public GradeReportService(IReportStore store)
	{
		_store = store;
	}

	public void CreateAndSave(StudentGrade grade)
	{
		var text = GradeReportFormatter.Format(grade);
		_store.Save(text);
	}
}

public static class SrpDemo
{
	// How to run:
	// - In a Console app, call: Session6_SOLID_SRP.SrpDemo.Run();
	public static void Run()
	{
		var grade = new StudentGrade { StudentName = "Nino", Course = "Software Engineering", Score = 95 };
		var service = new GradeReportService(new ConsoleReportStore());
		service.CreateAndSave(grade);
	}
}

