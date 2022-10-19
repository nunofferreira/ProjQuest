namespace ProjQuest.Entities;

public class Exam
{
    public string Name { get; set; }
    public List<int> QuestionIds { get; set; }
    public DateTime AvailableUntil { get; set; }
    public DateTime StartingTime { get; set; }

    public Exam()
    {
        QuestionIds = new List<int>();
    }
    //Exam(string name, string questions, DateTime availablePeriod)
    //{
    //    Name = name;
    //    Questions = questions;
    //    AvailableUntil = availablePeriod;
    //}


}
