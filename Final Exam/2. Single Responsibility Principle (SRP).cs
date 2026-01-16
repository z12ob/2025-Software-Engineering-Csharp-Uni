// Single Responsibility Principle (SRP) states that a class should have only one reason to change,
// meaning it should have only one job or responsibility.

class Report
{
    // Data only. No actions.
    public string Title;
    public string Text;

    public Report(string title, string text)
    {
        Title = title;
        Text = text;
    }
}

class ReportPrinter
{
    // One responsibility. Printing.
    public void Print(Report report)
    {
        Console.WriteLine(report.Title);
        Console.WriteLine(report.Text);
    }
}

class ReportSaver
{
    // One responsibility. Saving.
    public void Save(Report report)
    {
        Console.WriteLine("Saved " + report.Title);
    }
}

class Program
{
    static void Main()
    {
        Report r = new Report("SRP", "One reason to change");
        new ReportPrinter().Print(r);
        new ReportSaver().Save(r);
    }
}
