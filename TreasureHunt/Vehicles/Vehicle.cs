using TreasureHunt;

namespace Demos.TreasureHunt;

public abstract class Vehicle : IVehicle, IElement
{
    public string Name { get; set; }
    protected string Symbol { get; set; }
    public Coordinate Coordinates { get; set; }
    public ConsoleColor Colour { get; set; }
    public Forest Forest { get; set; }

    protected Vehicle(ConsoleColor colour, string symbol, string name)
    {
        Colour = colour;
        Symbol = symbol;
        Name = name;
    }

    public Direction Direction { get; set; }

    public void SetDirection()
    {
        Random rnd = new();
        Direction = (Direction)(rnd.Next() % 4);
    }

    public void Print()
    {
        var PreviousColour = Console.ForegroundColor;
        Console.ForegroundColor = Colour;
        Console.Write(Symbol);
        Console.ForegroundColor = PreviousColour;
    }

    public void Move()
    {
        SetDirection();

        switch (Direction)
        {
            case Direction.North:
                MoveNorth();
                break;
            case Direction.South:
                MoveSouth();
                break;
            case Direction.East:
                MoveEast();
                break;
            case Direction.West:
                MoveWest();
                break;
        }
    }

    public abstract void MoveNorth();
    public abstract void MoveSouth();
    public abstract void MoveEast();
    public abstract void MoveWest();

}



