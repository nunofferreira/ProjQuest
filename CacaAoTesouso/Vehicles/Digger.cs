namespace CacaAoTesouso.Vehicles;

public class Digger : Vehicle
{

    public Digger(char symbol)
    {
        Symbol = symbol;
    }

    public static void PrintDigger()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Random random = new Random();

        Console.SetCursorPosition(random.Next(20), random.Next(10));
        Console.Write("D");

        Console.SetCursorPosition(random.Next(20), random.Next(10));
        Console.Write("D");
    }

    public override void Moving()
    {
        Steps += _rnd.Next(1);
    }
}

