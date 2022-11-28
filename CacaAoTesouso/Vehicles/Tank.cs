namespace CacaAoTesouso.Vehicles;

public class Tank : Vehicle
{
    public Tank(char symbol)
    {

        Symbol = symbol;
    }

    public static void PrintTank()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Random random = new Random();

        Console.SetCursorPosition(random.Next(20), random.Next(10));
        Console.Write("T");

        Console.SetCursorPosition(random.Next(20), random.Next(10));
        Console.Write("T");


    }

    public override void Moving()
    {
        Steps += _rnd.Next(1);
    }
}

