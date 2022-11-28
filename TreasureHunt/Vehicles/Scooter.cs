namespace Demos.TreasureHunt;

public class Scooter : Vehicle
{
    public Scooter() : base(ConsoleColor.Blue, "S", "Scooter")
    {
    }

    public override void MoveNorth()
    {
        var destination = new Coordinate(Coordinates.Row - 1, Coordinates.Column);
        var alternativeDestination = new Coordinate(Coordinates.Row - 2, Coordinates.Column);
        Move(destination, alternativeDestination);
    }
    public override void MoveSouth()
    {
        var destination = new Coordinate(Coordinates.Row + 1, Coordinates.Column);
        var alternativeDestination = new Coordinate(Coordinates.Row + 2, Coordinates.Column);
        Move(destination, alternativeDestination);
    }

    public override void MoveEast()
    {
        var destination = new Coordinate(Coordinates.Row, Coordinates.Column + 1);
        var alternativeDestination = new Coordinate(Coordinates.Row, Coordinates.Column + 2);
        Move(destination, alternativeDestination);
    }

    public override void MoveWest()
    {
        var destination = new Coordinate(Coordinates.Row, Coordinates.Column - 1);
        var alternativeDestination = new Coordinate(Coordinates.Row, Coordinates.Column - 2);
        Move(destination, alternativeDestination);
    }

    private void Move(Coordinate destination, Coordinate alternativeDestination)
    {
        var elementDest = Forest.GetElement(destination);

        switch (elementDest)
        {
            case Treasure _:
                Forest.LaunchEventFoundTreasure(this);
                break;
            case null:
                Forest.MoveElement(Coordinates, destination);
                break;
            case Vehicle _:

                elementDest = Forest.GetElement(alternativeDestination);
                switch (elementDest)
                {
                    case Treasure _:
                        Forest.LaunchEventFoundTreasure(this);
                        break;
                    case null:
                        Forest.MoveElement(Coordinates, alternativeDestination);
                        break;
                }
                break;
        }
    }
}



