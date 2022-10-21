namespace ProjQuest.Entities;

public class ExamResults
{
    public int ExamId { get; set; }
    public int StudentId { get; set; }
    public List<ExamResult> Results { get; set; }

    public ExamResults()
    {
        Results = new List<ExamResult>();
    }
}

public class ExamResult
{
    public int QuestionId { get; set; }
    public bool RightAnswer { get; set; }

    public ExamResult( int questionId, bool rightAnswer)
    {
        this.QuestionId = questionId;
        this.RightAnswer = rightAnswer;
    }
}
