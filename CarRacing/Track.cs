using CarRacing.Veiculos;

public class Track
{
    public int Kms { get; private set; }
    public string Name { get; private set; }
    private Vehicle[] _vehicles;

    public Track(int kms, Vehicle[] vehicles)
    {
        this.Kms = kms;
        _vehicles = vehicles;
    }

    public void Print()
    {
        Console.Clear();

        var border = "".PadLeft(Kms, '-');
        
        Console.WriteLine(border);

        foreach (var vehicle in _vehicles)
            vehicle.Print();

        Console.WriteLine(border);
    }

    public Vehicle GetWinner()
    {
        foreach (var vehicle in _vehicles)
        {
            if (vehicle.Kms >= this.Kms)
                return vehicle;
        }
        return null;
    }

    public void MoveCars()
    {
        foreach (var vehicle in _vehicles)
            
            vehicle.Mover();
    }
}
