public class Floresta
{
    private int _altura;
    private int _largura;

    List<Veiculo> _veiculos;
    IElement[,] _terreno;

    public Floresta(int altura, int largura)
    {
        _altura = altura;
        _largura = largura;
        _veiculos = new List<Veiculo>();
        _terreno = new IElement[altura, largura];

        CriarParede();
        ColocarTesouro();
        ColocarVeiculos();
    }

    public void Imprmir()
    {
        for (int i = 0; i < _terreno.GetLength(0); i++)
        {
            for (int j = 0; j < _terreno.GetLength(1); j++)
            {
                var cell = _terreno[i, j];

                if (cell == null)
                    Console.Write(".");
                else
                    cell.Print();
            }
            Console.WriteLine();
        }
    }

    private void ColocarVeiculos()
    {
        var s1 = new Scooter(ConsoleColor.DarkRed);
        var s2 = new Scooter(ConsoleColor.DarkGreen);

        _veiculos.Add(s1);
        _veiculos.Add(s2);

        _terreno[5, 5] = s1;
        _terreno[2, 4] = s2;
    }

    private void ColocarTesouro()
    {
        _terreno[7, 7] = new Treasure();
    }

    private void CriarParede()
    {
        for (int i = 0; i < _terreno.GetLength(0); i++)
        {
            for (int j = 0; j < _terreno.GetLength(1); j++)
            {
                if (i == 0 || j == 0 || i == _terreno.GetUpperBound(0) || j == _terreno.GetUpperBound(1))
                {
                    _terreno[i, j] = new Wall();
                }
            }
        }
    }


}
