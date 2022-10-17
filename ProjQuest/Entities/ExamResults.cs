namespace ProjQuest.Entities;

internal class ExamResults
{
    public int ExamId { get; set; }
    public int AlunoId { get; set; }
    public List<(int QuestionId, bool RightAnwser)> Results { get; set; }
}
