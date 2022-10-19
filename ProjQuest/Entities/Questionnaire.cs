namespace ProjQuest.Entities;

public class Questionnaire
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public List<int> QuestionIds { get; set; }

    public Questionnaire()
    {
        QuestionIds = new List<int>();
    }
}
