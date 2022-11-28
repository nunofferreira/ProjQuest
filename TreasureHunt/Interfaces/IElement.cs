namespace Demos.TreasureHunt;

public interface IElement
{
    Coordinate Coordinates { get; set; }
    ConsoleColor Colour { get; set; }
    void Print();
}
