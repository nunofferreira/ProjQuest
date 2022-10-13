namespace Demos
{
    public static class Roleta
    {
        static string[] programmers = new[]
        {
            "Diogo Correia",
            "Eduardo Fernandes",
            "Inês Ataíde",
            "João Soares",
            "João Teixeira",
            "Jonathas Azer",
            "Luís Sarmento",
            "Nuno Ferreira",
            "Pedro Amaro",
            "Pedro Maia",
            "Sandra Gomes",
            "Ubiracy Neto"
        };

        public static void Run()
        {
            do
            {
                var programmer = programmers[Random.Shared.Next(programmers.Length)];

                Console.WriteLine(programmer);
            } while (Console.ReadLine().ToUpper() != "E");
        }
    }

}
