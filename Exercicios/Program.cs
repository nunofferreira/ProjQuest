// Entradas:
// Preço, percentagem de desconto

using System;
using System.Security.AccessControl;



CalcularSalario();

void CalcularSalario()
{
    double salario;
    int aumento;
    double salarioFinal;

    //AplicarDesconto();

    // Representar um aumento de 20% sobre o salário

    //obter salario
    Console.WriteLine("Qual o salario?");
    string str = Console.ReadLine();
    salario = int.Parse(str);


    //obter aumento
    Console.WriteLine("Qual o aumnto (1 a 100)?");
    str = Console.ReadLine();
    aumento = int.Parse(str);

    //calcular o salario final
    salarioFinal = salario - (salario * (aumento / 100.0));

    Console.WriteLine("salario: {1} preco: {0} salarioFinal: {2}", salario, aumento, salarioFinal);
    //apresentar o preco final
    Console.WriteLine("salario: {1} preco: {0} salarioFinal: {2}", salario, aumento, salarioFinal);
}



class Console2
{

}

