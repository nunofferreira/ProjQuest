using System.ComponentModel.DataAnnotations;

public class Calculator
{
    public Calculator()
    {

    }

    public int Sum(int n1, int n2)
    {
        return n2 + n1;
    }

    public int Sum(params int[] nums)
    {
        var result = 0;

        for (int i = 0; i < nums.Length; i++)
            result += nums[i];

        return result;
    }

    public int Subtract(int n1, int n2)
    {
        return n1 - n2;
    }

    public int Max(int n1, int n2)
    {
        if (n1 > n2)
            return n1;
        else
            return n2;
    }

    public bool Prime(int n)
    {
        bool prime = false;
        int numDivision = 0;

        for (var i = 1; i <= n; i++)
        {
            if (n == 0)
                continue;
            if (n % i == 0)
                numDivision++;
        }
        if (numDivision == 2)
            prime= true;
        else
            prime= false;

        return prime;
    }

    public int Division(int n1, int n2)
    {
        return n1 / n2;
    }
}