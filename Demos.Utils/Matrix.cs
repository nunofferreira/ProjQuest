namespace Demos.Utils;

public class Matrix
{
    public static void DrawX(string[,] m)
    {
        int dim = 5;
        string[,] matrix = new string[dim, dim];

        int numLines = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);

        for (int i = 0; i < numLines; i++)
        {
            //Diagonal line
            matrix[i, i] = "X";

            //Reverse diagonal
            matrix[i, numCols - 1 - i] = "X";
        }
    }

    public static void DrawSquare(string[,] m, char c)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                m[i, j] = c.ToString();
            }
        }
    }

    public static void DrawCross(string[,] m, char c)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (j == m.GetLength(1) / 2 || i == m.GetLength(0) / 2)
                    m[i, j] = c.ToString();
            }
        }
    }

    public static void DrawBorder(string[,] m, char c)
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

    public static void DrawTriangle(string[,] m, char c)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (i == m.GetLength(1) - 1 || j == 0 || i == j || j == i - 1)
                    //falta o ultimo x ser dinamico...
                    m[i, j] = c.ToString();
            }


        }
    }
    public static void Print(string[,] matrix)
    {
        int numLines = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);

        for (int i = 0; i < numLines; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                if (matrix[i, j] == null)
                    Console.Write("  ");
                else
                    Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void Print2(string[,] matrix)
    {
        int numLines = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);

        //Print Matrix com Operador ternário
        for (int i = 0; i < numLines; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                var p = matrix[i, j] == null ? " " : matrix[i, j];
                Console.Write(p + " ");
            }
            Console.WriteLine();
        }
    }
    //int lin = 4;
    //int col = 4;
    //string[,] matrix = new string[lin, col];



    //    Matrix.DrawTriangle(matrix, 'x');
    //Matrix.Print(matrix);




}

