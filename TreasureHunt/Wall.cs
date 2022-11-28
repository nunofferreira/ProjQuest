using Demos.TreasureHunt;

class Wall : IElement
{
    public Coordinate Coordinates { get; set; }
    public ConsoleColor Colour { get; set; }

    public Wall()
    {
        Colour = ConsoleColor.DarkBlue;
    }

    public void Print()
    {
        Console.ForegroundColor = Colour;
        Console.Write("█");
    }
}