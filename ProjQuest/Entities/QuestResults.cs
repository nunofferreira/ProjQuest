namespace ProjQuest.Entities;

public class QuestResults
{
    public int QuestId { get; set; }
    public int StudentId { get; set; }
    public List<QuestResult> Results { get; set; }

    public QuestResults()
    {
        Results = new List<QuestResult>();
    }
}

public class QuestResult
{
    public int QuestionId { get; set; }
    public bool RightAnswer { get; set; }

    public QuestResult(int questionId, bool rightAnswer)
    {
        this.QuestionId = questionId;
        this.RightAnswer = rightAnswer;
    }
}


