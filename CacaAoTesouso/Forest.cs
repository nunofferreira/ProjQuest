using CacaAoTesouso.Vehicles;

public class Forest : IElement
{
    public int InitPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    private static  Vehicle[] _vehicles;

    public void BuildWall()
    {
        int lin = 10;
        int col = 20;
        string[,] matrix = new string[lin, col];

        if (lin == 0 || col == 0 || lin == matrix.GetUpperBound(0) || col == matrix.GetUpperBound(1))
            matrix[lin, col] = "X";
        Console.WriteLine(matrix);
    }

    public static void PrintWall()
    {
        int lin = 10;
        int col = 20;
        string[,] matrix = new string[lin, col];

        for (int i = 0; i < lin; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (i == 0 || j == 0 || i == matrix.GetUpperBound(0) || j == matrix.GetUpperBound(1))
                    matrix[i, j] = "X";
                Console.Write(matrix);
            }
            Console.WriteLine();
        }

    }

    public static void DrawForest(string[,] m, char c)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (i == 0 || i == m.GetLength(0) - 1 || j == 0 || j == m.GetLength(1) - 1)
                    m[i, j] = c.ToString();
            }
        }
    }

    public static void PrintForest(string[,] matrix)
    {
        int lines = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var p = matrix[i, j] == null ? "." : matrix[i, j];
                Console.Write(p);
            }
            Console.WriteLine();
        }
    }
    public static void PrintTreasure()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Random random = new Random();

        Console.SetCursorPosition(random.Next(10), random.Next(20));

        Console.Write("$");
    }

    static void Main(string[] args)
    {
        while (true)
        {
            //var game = new Game();
            ////initialization logic       
            //game.Run();

            Console.WriteLine("Press any key to restart, press Esc to close.");
            var userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.Escape)
                return;
        }
    }

    public static void MoveVehicles()
    {
        foreach (var vehicle in _vehicles)

            vehicle.Move();
    }

    public static void Print()
    {

        foreach (var vehicle in _vehicles)
            vehicle.Print();
    }
}

