// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//EXERCICIO 2
double preco;
double percentagemDesconto;
double desconto;
double precoFinal;


Console.WriteLine("Digite o preço");

preco = double.Parse(console.readline());

Console.WriteLine("Escreva a percentagem (por exemplo 1,2)");

percentagemDesconto = double.Parse(Console.ReadLine());

desconto = (percentagemDesconto / 100) * preco;

Console.WriteLine("O salário atualizado é: {precoFinal}");

Console.ReadLine();
