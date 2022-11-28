// See https://aka.ms/new-console-template for more information

public class Scooter : Veiculo
{
    public Scooter(ConsoleColor color)
    {
        Color = color;
    }

    public override void Print()
    {
        Console.ForegroundColor = Color;
        Console.Write("S");
        Console.ResetColor();
    }

    public override void Start()
    {
        Console.WriteLine("Start from Scooter");
    }
}