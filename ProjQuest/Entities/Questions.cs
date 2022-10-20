namespace ProjQuest.Entities;

public class Question
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string DifLevel { get; set; }
    public string Tag { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool ExamOnly{ get; set; }
    public List<int> CorrectAnswer { get; set; }
    public List<string> PossAnswers { get; set; }

    public Question()
    {


    }

    public void PrintQuestions(bool printCorrect)
    {
        Console.WriteLine($"{this.Name}");
        for (int i = 0; i < this.PossAnswers.Count; i++)
        {
            string correctExpression = "";
            var answer = this.PossAnswers[i];

            if (printCorrect)
            {
                foreach (var correct in this.CorrectAnswer)
                {
                    if (correct == i + 1)
                    {
                        correctExpression = " (Correct)";
                    }
                }
            }

            Console.WriteLine($"{i + 1}) {answer}{correctExpression}");
            Console.WriteLine();
        }

        Console.WriteLine("-----------");
    }
}
