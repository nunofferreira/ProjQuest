namespace ProjQuest.Entities;

public class Question
{

    public int Id { get; set; }
    public string Subject { get; set; }
    public string DifLevel { get; set; }
    public string Tag { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool OnlyTest { get; set; }
    public List<int> CorrectAnswer { get; set; }
    public List<string> PossAnswers { get; set; }

    public Question()
    {
       

    }

    public void PrintQuestions(bool printCorrect)
    {

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
            Console.WriteLine($"{i+1}) {answer}{correctExpression}");
            Console.WriteLine();
        }

        Console.WriteLine("-----------");
    }
  
    //criar uma lista de respostas e usar um sistema de numeração para identificar a correta

    //public Question()
    //{

    //}

}
