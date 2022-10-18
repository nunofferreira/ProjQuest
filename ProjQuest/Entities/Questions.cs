namespace ProjQuest.Entities;

internal class Question
{

    public int Id { get; set; }
    public string Subjet { get; set; }
    public string DifLevel { get; set; }
    public string Tag { get; set; }
    public string Name { get; set; }
    public string Tipo { get; set; }
    public bool OnlyTest { get; set; }
    public List<int> Resposta { get; set; }
    public List<string> Respostas { get; set; }
    //criar uma lista de respostas e usar um sistema de numeração para identificar a correta

    //public Question()
    //{

    //}

}
