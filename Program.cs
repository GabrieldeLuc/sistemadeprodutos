using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var produtos = new List<Produto>();
        string opcao;

        do
        {
            Console.WriteLine(@"
Escolha uma opção:
1 - Cadastrar um produto
2 - Listar produtos
0 - Sair
            ");
            opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("\nCadastro de produto:");

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine()!;

                    Console.Write("Preço: ");
                    double preco;
                    while (!double.TryParse(Console.ReadLine(), out preco))
                    {
                        Console.Write("Preço inválido, digite novamente: ");
                    }

                    Console.Write("Está em promoção? (S/N): ");
                    bool promocao = Console.ReadLine()!.ToUpper() == "S";

                    produtos.Add(new Produto(nome, preco, promocao));
                    Console.WriteLine("Produto cadastrado com sucesso!");
                    break;

                case "2":
                    Console.WriteLine("\nProdutos cadastrados:");

                    foreach (var produto in produtos)
                    {
                        Console.WriteLine(@$"
Nome: {produto.Nome}
Preço: {produto.Preco:C2}
Está em promoção? {(produto.Promocao ? "Sim" : "Não")}
                        ");
                    }
                    break;

                case "0":
                    Console.WriteLine("\nObrigado por usar o sistema, até mais!");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida!");
                    break;
            }
        } while (opcao != "0");
    }
}

class Produto
{
    public string Nome { get; }
    public double Preco { get; }
    public bool Promocao { get; }

    public Produto(string nome, double preco, bool promocao)
    {
        Nome = nome;
        Preco = preco;
        Promocao = promocao;
    }
}






