using Demos.TreasureHunt;

class Treasure : IElement
{
    public Coordinate Coordinates { get; set; }
    public ConsoleColor Colour { get; set; }

    public Treasure()
    { 
    this.Colour = ConsoleColor.Red;
    }

    public void Print()
    {
        var PreviousColour = Console.ForegroundColor;
        Console.ForegroundColor = Colour;
        Console.Write("$");
        Console.ForegroundColor = PreviousColour;
    }
}



