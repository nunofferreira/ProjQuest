using CarRacing.Veiculos;

static class CarDealer
{
    static Random rnd = new ();

    static string makes = "Seat,Opel,Maserati,BMW,Mazda,Hyunday,Volvo,Bugati,Mercedes,McLaren,Ferrari,Porsche";
    static char[] symbols = new char[] { '.', '+', '-', '*', '~', '»', '«' };
    internal static Car[] GetCars(int numCars)
    {
        var separators = new char[] { ' ', ',' };
        var brands = makes.Split(separators); // [Seat, open, Maserati,...]

        var cars = new Car[numCars];

        for (int i = 0; i < numCars; i++)
        {
            var brand = brands[rnd.Next(brands.Length)];
            var symbol = symbols[rnd.Next(symbols.Length)];

            cars[i] = new Car(brand, symbol);
        }

        return cars;
    }
}