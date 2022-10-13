using CarRacing;

public class Race
{
    public static void StartRace()
    {
        Console.WriteLine("Quantos carros:");
        int numCars = Convert.ToInt32(Console.ReadLine());

        var cars = CarDealer.GetCars(numCars);

        Tracks track = new Tracks("Portimão", 100);

        Car winner = null;

        while (winner == null)
        {
            Console.Clear();

            track.PrintTrack();

            foreach (Car car in cars)
            {
                car.Mover();
                car.Print();
                Console.WriteLine();
            }

            track.PrintTrack();

            winner = GetWinner();

            Thread.Sleep(600);
        }

        Console.WriteLine(" O vencedor é {0}, com {1}Kms", winner.Marca, winner.Kms);

        Car GetWinner()
        {
            foreach (var car in cars)
            {
                if (car.Kms >= track.Kms)
                    return car;
            }
            return null;
        } 
    }
}

