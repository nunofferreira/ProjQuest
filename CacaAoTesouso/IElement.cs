using CacaAoTesouro.Vehicles;

public interface IElement
{
    void BuildWall()
    {
        int lin = 10;
        int col = 20;
        string[,] matrix = new string[lin, col];

        if (lin == 0 || col == 0 || lin == matrix.GetUpperBound(0) || col == matrix.GetUpperBound(1))
            matrix[lin, col] = "X";
    }







}

