namespace ProjQuest.Entities;

internal class Exam
{
    public string Name { get; set; }
    public List<int> QuestionIds { get; set; }
    public DateTime AvailablePeriod { get; set; }
    public DateTime StartingTime { get; set; }

    public Exam()
    {
        QuestionIds = new List<int>();
    }
    //Exam(string name, string questions, DateTime availablePeriod)
    //{
    //    Name = name;
    //    Questions = questions;
    //    AvailablePeriod = availablePeriod;
    //}
}
