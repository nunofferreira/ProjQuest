namespace ProjQuest.Entities;

internal class Question
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

  
    //criar uma lista de respostas e usar um sistema de numeração para identificar a correta

    //public Question()
    //{

    //}

}
