using System.Drawing;

namespace CarRacing.Veiculos;

public abstract class Vehicle
{
    public int Kms { get; set; }
    public string Make { get; set; }
    public char Symbol { get; set; }

    protected Random _rnd = new Random();

    // Modificador de acesso que torna a propriedade 
    // disponível tb para as subclasses
    protected ConsoleColor _color;

    public Vehicle()
    {
        Make = "Default";
        Symbol = '«';
    }

    public void Print()
    {
        Console.ForegroundColor = _color;

        for (int i = 0; i < Kms; i++)
            Console.Write(Symbol);

        Console.WriteLine(Make + $" ({Kms}Kms)");

        Console.ResetColor();
    }

    public virtual void Mover()
    {
        Kms++;
    }
}
