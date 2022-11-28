// See https://aka.ms/new-console-template for more information

internal class Treasure : IElement
{
    public void Print()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("$");
        Console.ResetColor();
    }
}