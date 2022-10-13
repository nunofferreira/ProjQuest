using CarRacing;
public class Tracks
{
    public string Nome { get; set; }
    public int Kms { get; set; }
    private Car[] _cars;

    public Tracks(string nome, int kms)
    {
        Nome = nome;
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

