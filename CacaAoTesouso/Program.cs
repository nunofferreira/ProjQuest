using CacaAoTesouso.Vehicles;

//int lin = 10;
//int col = 20;
//string[,] matrix = new string[lin, col];

//Forest.DrawForest(matrix, 'X');
//Forest.PrintForest(matrix);

//Digger.PrintDigger();
//Moto.PrintMoto();
//Tank.PrintTank();
//Forest.PrintTreasure();

//Console.ReadLine();

//Random randMove = new Random();
//int x = 1;
//int y = 1;
//Console.CursorLeft = x;
//Console.CursorTop = y;

//Console.SetCursorPosition(y, x);

//Console.ReadLine();

static void PrintVehicles()
{
    while (true)
    {
        for (int i = 0; i < 15; i++)
        {
            Console.Clear();
            Console.ResetColor();

            int lin = 10;
            int col = 20;
            string[,] matrix = new string[lin, col];

            Forest.DrawForest(matrix, 'X');
            Forest.PrintForest(matrix);
            Forest.PrintTreasure();

            Tank.PrintTank();
            Digger.PrintDigger();
            Moto.PrintMoto();

            Thread.Sleep(1000);
        }
    }
}
PrintVehicles();

Console.ReadLine();

static void randomMovement()
{
    Random randMove = new Random();
    int x = 1;
    int y = 1;
    Console.CursorLeft = x;
    Console.CursorTop = y;
    
    while (true)
    {

        int lin = 10;
        int col = 20;
        int[,] matrix = new int[lin, col];

        int irandom = randMove.Next(4);
        if (irandom == 0 && matrix[y, x - 1] == 0)
        {
            x--;
            PrintVehicles();
            break;
        }
        else if (irandom == 1 && matrix[y, x + 1] == 0)
        {
            x++;
            PrintVehicles();
            break;
        }
        else if (irandom == 2 && matrix[y - 1, x] == 0)
        {
            y--;
            PrintVehicles();
            break;
        }
        else if (matrix[y + 1, x] == 0)
        {
            y++;
            PrintVehicles();
            break;
        }
    }
    randomMovement();
}