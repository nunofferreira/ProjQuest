namespace CacaAoTesouso.Vehicles;


public abstract class Vehicle : IElement
{
    public ConsoleColor Colour { get; set; }

    public int Steps { get; set; }
    public char Symbol { get; set; }
    public int InitPosition { get; set; }
    public int Direction { get; set; }

    protected Random _rnd = new();



    public Vehicle()
    {

    }
    private const int MIN_X = 156;
    private const int MAX_X = 501;
    private int _x;

    //your TL(probably) will tell you to use Enum 
    private bool _toLeft;

    public void Monster()
    {
        _toLeft = false;
        _x = MIN_X;
    }

    public virtual void Move()
    {
        if (_toLeft)
        {
            _x--;
        }
        else
        {
            _x++;
        }
        CheckEdges();
    }

    private void CheckEdges()
    {
        if (_x == MAX_X || _x == MIN_X)
            _toLeft = !_toLeft;
    }
    public void BuildWall()
    {
        throw new NotImplementedException();
    }

    public void Print()
    {
        Console.ForegroundColor = Colour;

        for (int i = 0; i < Steps; i++)
            Console.Write(Symbol);

        Console.ResetColor();
    }

    public virtual void Moving()
    {
        Steps++;
    }
}

