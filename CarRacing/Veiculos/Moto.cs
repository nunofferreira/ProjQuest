namespace CarRacing.Veiculos;

public class Moto : Vehicle
{
    public Moto(ConsoleColor color)
    {
        _color = color;
    }

    public override void Mover()
    {
        Kms += _rnd.Next(1, 6);
    }
}


