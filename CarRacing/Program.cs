using CarRacing.Veiculos;

var trackTam = 100;
var delay = 500;
var numCars = 7;

var cars = CarDealer.GetCars(numCars);
var moto = new Moto(ConsoleColor.Green);
var motoRed = new Moto(ConsoleColor.Red);


List<Vehicle> vehicles = new List<Vehicle>();
vehicles.AddRange(cars);
vehicles.Add(moto);
vehicles.Add(motoRed);


moto.Make = "Suzuki";
moto.Symbol = '*';


var track = new Track(trackTam, vehicles.ToArray());
var race = new Race(track, cars);

Vehicle winner = race.Start(delay);
Console.WriteLine("O vencedor é {0} {1} Kms", winner.Make, winner.Kms);
Console.Beep();

public class Animal : object
{
    public string Nome { get; set; }
    public int Idade { get; set; }
}

public class AnimalDomestico : Animal
{
    public string Dono { get; set; }
}

public class Gato : AnimalDomestico
{
    public string RacaoPreferida { get; set; }
}

public class Cao : AnimalDomestico
{

}

public class AnimalSelvagem
{
    public string Habitat { get; set; }
}




public class Leopardo
{
    public string NumPintas { get; set; }
}