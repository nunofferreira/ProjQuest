using Demos.TreasureHunt;

// como usar:
// Scooter scooter = new(ConsoleColor.Red);

// scooter.Stop();
// ou
// ScooterExtensionMethods.Stop(scooter);

public static class ScooterExtensionMethods
{
    public static void Stop(this Scooter scooter)
    {
        Console.WriteLine("Stopping scooter");
    } 
}