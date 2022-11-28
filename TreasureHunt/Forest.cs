using Demos.TreasureHunt;

namespace TreasureHunt;

public class Forest
{
    public delegate void FoundTreasureHandler(object sender, EventArgs e);
    public event FoundTreasureHandler FoundTreasure;

    private const int SideMin = 10;
    private const int SideMax = 100;

    private readonly List<IElement> _elements;
    private readonly IElement[,] _terrain;
    private readonly int _row;
    private readonly int _col;

    public IElement[,] Terrain => _terrain;

    public Forest(int height, int width)
    {
        _row = GetValidLenght(height);
        _col = GetValidLenght(width);
        _elements = new List<IElement>();
        _terrain = new IElement[_row, _col];
        BuildWall();
    }
    public List<Vehicle> GetVehicles()
    {
        var vehicles = _elements.Where(e => e is Vehicle);
        return vehicles.Cast<Vehicle>().ToList();
    }

    public void MoveElement(Coordinate origin, Coordinate destination)
    {
        var ElementDestination = _terrain[destination.Row, destination.Column];

        _terrain[destination.Row, destination.Column] = _terrain[origin.Row, origin.Column];
        _terrain[origin.Row, origin.Column] = null;

        _terrain[destination.Row, destination.Column].Coordinates = destination;

        // Tank destroys vehicle
        if (ElementDestination is Vehicle vehicle)
            RemoveVehicle(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        _ = _elements.Remove(vehicle);
    }

    public void LaunchEventFoundTreasure(Vehicle vehicle)
    {
        FoundTreasure?.Invoke(vehicle, EventArgs.Empty);
    }

    public IElement GetElement(Coordinate coordinate)
    {
        return _terrain[coordinate.Row, coordinate.Column];
    }

    public void Print()
    {
        Console.Clear();

        for (int i = 0; i < _row; i++)
        {
            for (int j = 0; j < _col; j++)
            {
                var cell = _terrain[i, j];

                if (cell == null)
                    Console.Write(".");
                else
                    cell.Print();

                if (j == _col - 1)
                    Console.WriteLine("");
            }
        }
    }

    public void ElementPositioning(IEnumerable<IElement> elements)
    {
        var newElements = elements.ToList();
        _elements.AddRange(newElements);

        var rnd = new Random();

        foreach (var element in newElements)
        {
            Coordinate newCoord;

            do
            {
                newCoord = GetCoordinate();
            } while (Terrain[newCoord.Row, newCoord.Column] != null);

            element.Coordinates = newCoord;
            Terrain[newCoord.Row, newCoord.Column] = element;
        }

        Coordinate GetCoordinate()
        {
            return new Coordinate(rnd.Next(_row), rnd.Next(_col));
        }
    }

    private void BuildWall()
    {
        //var wall = new Wall();

        //for (var i = 0; i < _row; i++)
        //{
        //    Terrain[i, 0] = wall;
        //    Terrain[i, _col - 1] = wall;
        //}
        //for (var i = 0; i < _col; i++)
        //{
        //    Terrain[0, i] = wall;
        //    Terrain[_row - 1, i] = wall;
        //}
        for (int i = 0; i < _terrain.GetLength(0); i++)
            for (int j = 0; j < _terrain.GetLength(1); j++)
                if (i == 0 || j == 0 || i == _terrain.GetUpperBound(0) || j == _terrain.GetUpperBound(1))
                    _terrain[i, j] = new Wall();
    }

    private int GetValidLenght(int value)
        => value < SideMin ? SideMin : value > SideMax ? SideMax : value;
}