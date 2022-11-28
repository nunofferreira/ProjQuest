using CarRace.Vehicles;
public class Track
{
    public string Nome { get; set; }
    public int Kms { get; set; }
    private Vehicle[] _vehicles;

    public Track(int kms, Vehicle[] vehicles)
    {
        _vehicles = vehicles;
        Kms = kms;
    }

    public void PrintTrack()
    {
        var border = "".PadLeft(Kms, '-');
        Console.WriteLine(border);



        Console.WriteLine(border);

        //for (char i = '-'; i < 150; i++)
        //    Console.Write('-');
        //Console.WriteLine();
    }
    


}

