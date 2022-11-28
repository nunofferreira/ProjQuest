//Floresta floresta = new(largura: 10, altura: 10);
//floresta.Imprmir();

//Console.ReadLine();


// Extension methods 

// Console.WriteLine(Utils.Formatar(matricula));


// métodos idênticos



public static class ScooterExtensionMethods
{
    public static void Stop(this Scooter scooter)
    {
        Console.WriteLine("Stopping scooter");
    }

    public static void Start(this Scooter scooter)
    {
        Console.WriteLine("Start Scooter from extension method");
    }
}

