using CarRace.Vehicles;

public class Race
{
    public static void StartRace()
    {
        Console.WriteLine("Quantos veículos:");
        int numVehic = Convert.ToInt32(Console.ReadLine());

        var vehicles = CarDealer.GetCars(numVehic);

        Track track = new Track(100,);

        Car winner = null;

        while (winner == null)
        {
            Console.Clear();

            track.PrintTrack();

            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.Mover();
                vehicle.Print();
                Console.WriteLine();
            }

            track.PrintTrack();

            winner = GetWinner();

            Thread.Sleep(600);
        }

        Console.WriteLine(" O vencedor é {0}, com {1}Kms", winner.Marca, winner.Kms);

       
    }
}

