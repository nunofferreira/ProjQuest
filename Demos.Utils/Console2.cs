namespace Demos.Utils;

public static class Console2
{
    public static double ReadDouble(string message)
    {
        Console.WriteLine(message);

        string str = Console.ReadLine();

        double result;
        double.TryParse(str, out result);

        return result;
    }

    public static int ReadInt(string message)
    {
        Console.WriteLine(message);

        string str = Console.ReadLine();

        int result;
        int.TryParse(str, out result);
        
        return result;
    }


    public static void PrintNumbersOrderedBy(int a, int b, int c, bool isAsc)
    {
        if (a > b)
            Math2.Swap(ref a, ref b);

        if (b > c)
            Math2.Swap(ref b, ref c);

        if (a > b)
            Math2.Swap(ref a, ref b);

        if (isAsc)
            Console.WriteLine($"{a},{b},{c}");
        else
            Console.WriteLine($"{c},{b},{a}");
    }

    public static bool ReadInt2(string message, out int result)
    {
        //USANDO  FUNÇÃO OUT
        bool sucesso = true;
        result = 0;
        Console.WriteLine(message);

        sucesso = int.TryParse(Console.ReadLine(), out result);

        return sucesso;
    }

    public static bool ReadInt(string message, out int result)
    {
        //ESTA FUNÇÃO VAI DEVOLVER UM BOLEANO, 
        //SE CONSEGUIU OU NAO LER O NUMERO CORRECTO DO UTILIZADOR
        Console.WriteLine(message);

        return int.TryParse(Console.ReadLine(), out result);
    }

    public static void EnableUTF8Encoding()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    }
}

