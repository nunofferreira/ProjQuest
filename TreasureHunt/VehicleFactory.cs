using Demos.TreasureHunt;
using TreasureHunt;

internal class VehicleFactory
{
    public static T Create<T>(Forest forest) where T : Vehicle, new()
    {
        return new T { Forest = forest };
    }

    public static IEnumerable<IElement> Build(int numVehicles, Forest forest)
    {
        var elements = new List<IElement>();

        for (var i = 0; i < numVehicles; i++)
        {
            switch (i % 3) //resto da divisão de 3 => 0,1,2 ; 0,1,2 ...
            {
                case 0:
                    elements.Add(Create<Scooter>(forest));
                    break;
                case 1:
                    elements.Add(Create<Tank>(forest));
                    break;
                case 2:
                    elements.Add(Create<Digger>(forest));
                    break;
            }
        }
        return elements;
    }
}
