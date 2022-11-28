using CarRace.Vehicles;

public static class CarDealer
{
    static Random rnd = new();

    static string[] carMake =
    {"Ferrari", "McLaren", "Mercedes", "Williams", "Haas",
     "Alfa Romeo", "Renault", "Aston Martin", "Honda", "Red Bull"};

    static char[] symbols =
     {'=', '-', '+', '<', '>', '~', '#', '*', '¬', '/'};

    public static List<Car> GetCars(int numCars)
    {
        List<Car> cars = new List<Car>();

        for (int j = 0; j < numCars; j++)
        {
            //var brand = carMake[rnd.Next(carMake.Length)];
            //var symbol = symbols[rnd.Next(symbols.Length)];

            //cars[j] = new Car(brand, symbol);

            int rnd = CarDealer.rnd.Next(carMake.Length);

            Car car = new Car(carMake[rnd], symbols[rnd]);
            cars.Add(car);
        }

        return cars;
    }
}
