namespace CarRacing.Veiculos;

public class Car : Vehicle
{
    public Car()
    {
        _rnd = new Random();
        _color = (ConsoleColor)_rnd.Next(1, 16);
    }

    public Car(Car car) : this()
    {
        Kms = car.Kms;
        Make = car.Make;
        Symbol = car.Symbol;
        _color = car._color;
    }

    public Car(string make) : this()
    {
        Make = make;
        Symbol = '.';
    }

    // Call another constructor (constructor chaining) that accepts only the Make
    // but helps to construct the Car
    public Car(string make, char symbol) : this(make)
    {
        Symbol = symbol;
    }

    public static int KmsPercorridos()
    {
        return 10;
    }

    public override void Mover() 
    {
            Kms += _rnd.Next(5, 10);
    }
}