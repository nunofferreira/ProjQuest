namespace Demos.Utils;

public class Math2
{
    /// <summary>
    /// Try...catch...throw example
    /// </summary>
    public static void CallExceptionExample()
    {
        try
        {
            var x = Math2.Min(-10, 20);
            Console.WriteLine(x);
        }
        catch (Exception)
        {
            Console.WriteLine("Não pode passar números negativos");
            throw;
        }
        finally
        {
            Console.WriteLine("Este bloco é sempre executado");
        }
    }
    /// <summary>
    /// Devolve o valor mínimo entre x e y
    /// </summary>
    /// <returns></returns>
    /// < remarks>
    /// Lança exceção se x ou y for negativo 
    /// </remarks>
    public static int Min(int x, int y)
    {
        if (x < 0 || y < 0)
            throw new Exception("x e y devem ser positivos");

        if (x > y)
        {
            return y;
        }
        return x;
    }

    public static int Min2(int x, int y)
    {
        // operador ternário
        return x > y ? y : x;
    }

    public static int Max(int x, int y)
    {
        if (x < y)

            return x;

        return y;
    }

    public static int Max2(int x, int y)
    {
        // operador ternário
        // <condição> ? {expressão se true} : {expressão se false}
        return x > y ? x : y;
    }
    public static bool AreEqual(int x, int y)
    {
        return x == y;
    }

    public static bool AreEqual2(int x, int y)
    {
        return x == y ? true : false;
    }

    public static int Sum(int x, int y)
    {
        return x + y;
    }

    public static void Swap(ref int n1, ref int n2)
    {
        int aux = n2;
        n2 = n1;
        n1 = aux;
    }

    //usando o TUPLO
    public static (int, int) Swap2(int n1, int n2)
    {
        return (n2, n1);
    }

    //Implementação do Swap com parâmetros do tipo out

    //public static bool Swap3(int n1, int n2);
    //{
    //Console.WriteLine(message);

    //return int.TryParse(Console.Readline())
    //}

}


