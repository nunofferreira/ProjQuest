using System.Drawing;

namespace CacaAoTesouso.Vehicles;


public class Moto : Vehicle
{

    public Moto(char symbol)
    {
        Symbol = symbol;
    }

    public static void PrintMoto()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Random random = new Random();

        Console.SetCursorPosition(random.Next(20), random.Next(10));
        Console.Write("M");

        Console.SetCursorPosition(random.Next(20), random.Next(10));
        Console.Write("M");
    }

    public override void Moving()
    {
        Steps += _rnd.Next(2);
    }
}

