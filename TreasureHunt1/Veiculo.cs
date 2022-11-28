// See https://aka.ms/new-console-template for more information

public class Veiculo : IElement
{
    public ConsoleColor Color { get; set; }

    public virtual void Print()
    {
        throw new NotImplementedException();
    }

    public virtual void Start()
    {
        Console.WriteLine("Start from Veiculo");
    }
}