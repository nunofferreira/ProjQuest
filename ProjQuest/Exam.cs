namespace ProjQuest;

internal class Exam
{
    public string Name { get; set; }
    public string Questions { get; set; }
    public DateTime AvailablePeriod { get; set; }

    Exam(string name, string questions, DateTime availablePeriod)
    {
        Name = name;
        Questions = questions;
        AvailablePeriod = availablePeriod;
    }
}
