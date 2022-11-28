public enum Direction
{
    North = 0,
    South = 1,
    East = 2,
    West = 3
}
//MovementOfStar();

//static void MovementOfStar()
//{
//    int row = 40, col = 12;
//    Console.CursorVisible = false;
//    Console.SetCursorPosition(row, col);

//    int direction = 0;
//    Random r = new Random();

//    for (int i = 0; i < 1000; i++)   // count of movement
//    {
//        Console.Write("*");
//        Thread.Sleep(100);
//        Console.Write('\b');
//        Console.Write("_");

//  Console.Clear(); 

//        direction = r.Next(5);
//        while (direction == 0)
//            direction = r.Next(5);

//        switch (direction)
//        {
//            case 1:
//                if (row + 1 >= 80)
//                    row = 0;
//                Console.SetCursorPosition(row++, col);
//                break;
//            case 2:
//                if (row - 1 <= 0)
//                    row = 79;
//                Console.SetCursorPosition(row--, col);
//                break;
//            case 3:
//                if (col + 1 >= 25)
//                    col = 0;
//                Console.SetCursorPosition(row, col++);
//                break;
//            case 4:
//                if (col - 1 <= 0)
//                    col = 24;
//                Console.SetCursorPosition(row, col--);
//                break;

//        }


//    }
//}






//static void randomMovement(Forest forest)
//{
//    Random randMove = new Random();
//    int x = 1;
//    int y = 1;
//    Console.CursorLeft = x;
//    Console.CursorTop = y;



//    while (true)
//    {
//        int[,] forest1 = new int[x, y];

//        int lin = 10;
//        int col = 20;
//        int[,] matrix = new int[lin, col];


//        int irandom = randMove.Next(1);
//        if (irandom == 0 && matrix[y, x - 1] == 0)
//        {
//            x--;
//            Scooter.PrintMove(forest);
//            break;
//        }
//        else if (irandom == 1 && matrix[y, x + 1] == 0)
//        {
//            x++;
//            Scooter.PrintMove(forest);
//            break;
//        }
//        else if (irandom == 2 && matrix[y - 1, x] == 0)
//        {
//            y--;
//            Scooter.PrintMove(forest);
//            break;
//        }
//        else if (matrix[y + 1, x] == 0)
//        {
//            y++;
//            Scooter.PrintMove(forest);
//            break;
//        }
//    }
//    Thread.Sleep(1000);
//    randomMovement(forest);
//}

//private static void Write(int x, int y, char ch)
//{
//    Console.SetCursorPosition(2 * x + 1, y + 1);
//    if (ch == Character)
//    {
//        Console.Write('╠'); Console.Write('╣');
//    }
//    else
//    {
//        Console.Write(ch); Console.Write(ch);
//    }
//}

//private static void DrawMap(char[,] map)
//{
//    for (int x = 0; x < MapWidth; x++)
//    {
//        for (int y = 0; y < MapHeight; y++)
//        {
//            Write(x, y, map[x, y]);
//        }
//    }
//}

//private static char[,] GenerateMap()
//{
//    var map = new char[MapWidth, MapHeight];

//    for (int i = 0; i < MapWidth; i++)
//    {
//        map[i, 0] = Wall;
//    }
//    for (int i = 0; i < MapWidth; i++)
//    {
//        map[i, MapHeight - 1] = Wall;
//    }
//    for (int i = 0; i < MapHeight; i++)
//    {
//        map[0, i] = Wall;
//    }
//    for (int i = 0; i < MapHeight; i++)
//    {
//        map[MapWidth - 1, i] = Wall;
//    }

//    // Add some inside wall
//    for (int i = 8; i < MapHeight - 5; i++)
//    {
//        map[12, i] = Wall;
//    }

//    return map;
//}

//const int MapWidth = 20;
//const int MapHeight = 20;
//const char Wall = '█';
//const char Character = 'H';

//static void Main(string[] args)
//{
//    int xCursor = 5, yCursor = 5;
//    int xLastCollision = -1, yLastCollision = -1;
//    bool isGameOver = false;

//    Console.Clear();
//    Console.CursorVisible = false; // Make the default console cursor invisible

//    char[,] map = GenerateMap();
//    DrawMap(map);

//    // Set inital cursor position
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Write(xCursor, yCursor, Character);
//    do
//    {
//        ConsoleKeyInfo consoleKey = Console.ReadKey(true);

//        // Clear old cursor position
//        Write(xCursor, yCursor, ' ');

//        int oldX = xCursor, oldY = yCursor;
//        switch (consoleKey.Key) // Movement of Character
//        {
//            case ConsoleKey.UpArrow:
//                yCursor--;
//                break;
//            case ConsoleKey.DownArrow:
//                yCursor++;
//                break;
//            case ConsoleKey.LeftArrow:
//                xCursor--;
//                break;
//            case ConsoleKey.RightArrow:
//                xCursor++;
//                break;
//            case ConsoleKey.Escape:
//                isGameOver = true;
//                break;
//        }
//        //Detect collisions with walls
//        if (map[xCursor, yCursor] == Wall)
//        { // We hit the wall, restore old position
//            if (xCursor != xLastCollision && yCursor != yLastCollision)
//            {
//                Console.Beep(800, 100);
//                xLastCollision = xCursor;
//                yLastCollision = yCursor;
//            }
//            xCursor = oldX;
//            yCursor = oldY;
//        }
//        else
//        {
//            xLastCollision = -1;
//            yLastCollision = -1;
//        }
//        Write(xCursor, yCursor, Character);
//    } while (!isGameOver);
//}


