namespace ProjQuest.Entities;

public class Exam
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> QuestionIds { get; set; }
    public DateTime AvailableUntil { get; set; }
    public DateTime StartingTime { get; set; }

    public Exam()
    {
        QuestionIds = new List<int>();
    }
}
