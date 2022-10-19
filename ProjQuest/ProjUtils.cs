using System.Globalization;

namespace ProjQuest;

public class ProjUtils
{
    public static void EnableUTF8Encoding()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    }

    public static DateTime ReadDatetime(string message)
    {
        while (true)
        {
            Console.WriteLine(message);

            string str = Console.ReadLine();

            var isOk = DateTime.TryParseExact(str, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result);
            //var valid = DateTime.TryParse(str, out var result);

            if (isOk)
                return result;
            Console.Clear();
        }
    }

    public static double ReadDouble(string message)
    {
        while (true)
        {
            Console.WriteLine(message);

            string str = Console.ReadLine();

            var isOk = double.TryParse(str, out var result);
            
            if (isOk)
                return result;
            Console.Clear();
        }
    }

    public static int ReadInt(string message)
    {
        while (true)
        {
            Console.WriteLine(message);

            string str = Console.ReadLine();

            var isOk = int.TryParse(str, out var result);

            if (isOk)
                return result;
            Console.Clear();
        }
    }

    public static int ReadChar(string message)
    {
        while (true)
        {
            Console.WriteLine(message);

            string str = Console.ReadLine();

            var isOk = char.TryParse(str, out var result);
            
            if (isOk)
                return result;
            Console.Clear();
        }
    }

    public static int CreateGuid(string[] args)
    {
        Guid obj = Guid.NewGuid();
        Console.WriteLine("New Guid is " + obj.ToString());
        Console.ReadLine();
        return -1;
    }

    public static void PrintLogo()
    {
        Console.WriteLine(@"
           ____                  _   
          / __ \                | |  
         | |  | |_   _  ___  ___| |_ 
         | |  | | | | |/ _ \/ __| __|
         | |__| | |_| |  __/\__ \ |_ 
          \___\_\\__,_|\___||___/\__|
                            ");
    }
}
