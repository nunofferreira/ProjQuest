namespace ProjQuest;

internal class Question
{
    Random rnd;

    public Question()
    {
        rnd = new Random();
    }

    public Question(string tipo) : this()
    {
        Tipo = tipo;
    }

    public Question(string nome, string resposta) : this()
    {
        Nome = nome;
        Resposta = resposta;
    }

    public int Id { get; set; }
    public string Assunto { get; set; }
    public string Nivel { get; set; }
    public string Tag { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public bool OnlyQuest { get; set; }
    public string Resposta { get; set; }
    //criar uma lista de respostas e usar um sistema de numeração para identificar a correta



}
