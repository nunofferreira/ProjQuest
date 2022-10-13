namespace CarRacing;

internal class Car
{
    public string Marca { get; set; }
    public int Kms { get; set; }
    public char Simbolo { get; set; }

    Random _rnd;

    public Car(string marca, char simbolo)
    {
        _rnd = new Random();
        Marca = marca;
        Simbolo = simbolo;
    }

    public void Print()
    {
        for (int i = 0; i < Kms; i++)
            Console.Write(Simbolo);

        Console.WriteLine($" {Marca} >{Kms}Kms");
    }

    public void Mover()
    {
        Kms += _rnd.Next(2, 9);
    }
}
