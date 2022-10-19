namespace ProjQuest.Entities;

public class ExamResults
{
    public int ExamId { get; set; }
    public int StudentId { get; set; }
    public List<(int QuestionId, bool RightAnswer)> Results { get; set; }
}
