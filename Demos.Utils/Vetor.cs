namespace Demos.Utils;
using System.Linq;

public static class Vetor
{


    public static int Max(int[] v)
    {
        if (v == null || v.Length == 0)     //Validação
            return 0;

        var max = v[0];

        for (int i = 1; i < v.Length; i++)
        {
            if (v[i] > max)
                max = v[i];
        }
        return max;
    }

    public static int Min(int[] v)
    {
        for (int i = 0; i < v.Length; i++)
            if (v[i] < v[i + 1])
                return v[i];
        return -1;
    }

    public static double Average(int[] v)
    {
        double sum = 0;

        for (int i = 0; i < v.Length; i++)
            sum += v[i];

        return sum / v.Length;
    }

    // [1, 2, 5, 7], [5, 34, 9] -> [1, 2, 5, 7, 5, 34, 9]
    //Concat
    public static int[] Concat(int[] v1, int[] v2)
    {
        //1. Criar um vetor com n elementos
        var result = new int[v1.Length + v2.Length];

        for (int i = 0; i < v1.Length; i++)
        {
            result[i] = v1[i];
        }

        for (int i = 0; i < v2.Length; i++)
        {
            result[v1.Length + i] = v2[i];
        }

        return result;
    }

    //[1, 2, 5], 5 -> [6, 7, 10]
    //Add
    public static int[] Add(int[] v)
    {
        var res = new int[v.Length];

        for (int i = 0; i < v.Length; i++)
        {
            res[i] = v[i] + 5;
        }
        return res;

        //var v1 = new int[] { 1, 2, 5 };
        //var v2 = new int[] { 6, 7, 10 };
        //Vetor.Print2(Vetor.Add2(v1, v2));
    }

    //[1, 2, 5], [6, 7, 10] -> [7, 9, 15]
    //Add
    public static int[] Add2(int[] v1, int[] v2)
    {
        var res = new int[v1.Length]; //se a lenght do v2 for maior?
                                      //da para fazer um if?  
        for (int i = 0; i < v1.Length; i++)
        {
            res[i] = v1[i] + v2[i];
        }
        return res;
    }

    //[1, 2, 5] -> [5, 2, 1]
    //Reverse
    public static int[] Reverse(int[] v)
    {
        var reversed = new int[v.Length];
        var j = v.Length - 1;

        foreach (var item in v)
        {
            reversed[j--] = item;
        }
        return reversed;
    }

    public static int[] Reverse2(int[] v)
    {
        var res = new int[v.Length];
        var j = v.Length - 1;

        for (int i = 0; i < v.Length; i++)
        {
            res[j--] = v[i];
        }
        return res;
    }

    //[1, 2, 5] -> [1, 5, 2]
    //Randomize
    public static void Randomize(int[] v, int v1)
    {
        var res = new int[v.Length];


        Random rnd = new Random();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(rnd.Next(1, 5));
        }



    }

    //recebe tamanho do vetor a criar e valor do primeiro elemento
    //tam: 3, first: 100 -> [10, 101, 102]
    //Initialize
    public static int[] Initialize(int[] v)
    {
        throw new NotImplementedException();
    }

    //[1, 2, 5] -> e.g. 5 ou 2 ou 1
    //GetRandomElement
    public static int[] GetRandomElement(int[] v)
    {
        var res = new int[v.Length];

        return res;
    }

    //[1, 2, 5] -> 8
    //Sum
    public static void Sum(int[] v)
    {
        int[] a = new int[2];
        int res = 0;


        for (int i = 0; i < v.Length; i++)
        {
            res += v[i];
        }

    }

    //[1, 2, 5], 2 -> [2, 4, 10]
    //Multiply
    public static int[] Multiply(int[] v)
    {
        var res = new int[v.Length];

        for (int i = 0; i < v.Length; i++)
        {
            res[i] = v[i] * 2;
        }
        return res;
    }

    // [1, 2, 5, 7]
    //declarar variavel no Program.cs
    //var v1 = new int[] { 1, 2, 5, 7 }; 
    public static void Print(int[] v1)
    {
        Console.Write("[");
        for (int i = 0; i < v1.Length - 1; i++)
        {
            Console.Write(v1[i]);
            Console.Write(", ");
        }

        for (int i = v1.Length - 1; i < v1.Length; i++)
        {
            Console.Write(v1[i]);
        }
        Console.Write("]");

        //OU com foreach
        //    Console.Write("[");
        //    foreach (var item in v1)
        //    {
        //        Console.Write(item);
        //        Console.Write(", ");
        //    }
        //    Console.Write("]");

        //Vetor.Print(v1);
    }

    public static void Print2(int[] v1)
    {
        var str = $"[{string.Join(", ", v1)}]";

        Console.WriteLine(str);
    }
}

