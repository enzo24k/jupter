using System;
using System.Collections.Generic;
using System.Threading;

public class JUPITER
{
    static List<Produto> listaProdutos = new List<Produto>();
    static string senha123 = "senha123";
    public static void Main()
    {
        string senha = "senha123";
        bool produtos = false;

        while (true)
        {
            Console.WriteLine("--------------------------BEM-VINDO AO--------------------------");
            Console.WriteLine("");
            Console.WriteLine(Logo());

            if (senha == "")
            {
                Console.WriteLine("INFORME A SUA SENHA DE ADMINISTRADOR!");
                senha = Console.ReadLine();
                Console.Clear();
            }
            else if (!produtos)
            {
                produtos = true;
                Console.WriteLine("----------------------ADICIONANDO OS PRODUTOS----------------------");
                Console.WriteLine(".");
                Thread.Sleep(1000);
                Console.WriteLine("..");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                Thread.Sleep(1000);
                AdicionarProduto(1, "Caixa de Bolete", 10);
                AdicionarProduto(2, "Pirulitos un.", 30);
                AdicionarProduto(3, "Heineken", 6);
                AdicionarProduto(4, "Doce de leite", 20);
                AdicionarProduto(5, "Cigarro", 3);
                AdicionarProduto(6, "Paçoca", 15);
                AdicionarProduto(7, "Água 500ml", 10);
                AdicionarProduto(8, "Coca-cola 2Lt", 4);
                Console.Clear();
                Console.WriteLine("PRODUTOS ADICIONADOS!");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar......");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar...");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar..");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------PAINEL DE CONTROLE-----------");
                Console.WriteLine("");
                Console.WriteLine("[1] - Vender Produto");
                Console.WriteLine("[2] - Listar de produtos");
                Console.WriteLine("[3] - Alterar Senha");
                Console.WriteLine("[4] - Fechar Caixa");

                int decisao = Convert.ToInt32(Console.ReadLine());

                switch (decisao)
                {
                    case 1:
                        VenderProduto();
                        break;

                    case 2:
                        ListarProdutos();
                        break;

                    case 3:
                        AlterarSenha();
                        break;

                    case 4:
                        FecharCaixa();
                        return;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }
    }


    public static string Logo()
    {
        string logo = "   JJJJJJJJ  U     U  PPPPPPP   II  TTTTTTTT  EEEEEEE  RRRRRRR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PPPPPPP   II     TT     EEEEE    RRRRRRR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR RR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR   RR\n";
        logo += " JJJJJJ       UUUUU   PP        II     TT     EEEEEEE  RR    RR\n";
        logo += "\n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";
        logo += "          33    33  00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          3333333   00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          33    33  00    00  00    00 00    00     \n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";

        return logo;
    }


    static void AdicionarProduto(int id, string nome, int quantidade)
    {
        Produto produto = new Produto(id, nome, quantidade);
        listaProdutos.Add(produto);
    }


    static void VenderProduto()
    {
        Console.Clear();
        Console.WriteLine("Informe o ID do produto para vender:");
        int idProduto = Convert.ToInt32(Console.ReadLine());
        Produto produto = listaProdutos.Find(p => p.Id == idProduto);

        if (produto != null)
        {
            Console.WriteLine($"Produto: {produto.Nome}");
            Console.WriteLine($"Quantidade disponível: {produto.Quantidade}");

            Console.WriteLine("Digite a quantidade a ser vendida:");
            int quantidadeVendida = Convert.ToInt32(Console.ReadLine());

            if (quantidadeVendida <= produto.Quantidade)
            {
                produto.Quantidade -= quantidadeVendida;
                Console.WriteLine($"Venda realizada com sucesso! Restante em estoque: {produto.Quantidade}");
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente em estoque.");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }

        Console.ReadKey();
    }





    static void ListarProdutos()
    {
        Console.Clear();
        Console.WriteLine("-------- LISTA DE PRODUTOS --------");
        foreach (var produto in listaProdutos)
        {
            Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Quantidade: {produto.Quantidade}");
        }

        Console.ReadKey();
    }


    static void AlterarSenha()
    {
        Console.WriteLine("Informe a senha antiga:");
        string senhaAntiga = Console.ReadLine();

        if (senhaAntiga == senha123)
        {
            Console.WriteLine("Informe a nova senha:");
            senha123 = Console.ReadLine();
            Console.WriteLine("Senha alterada com sucesso!");
        }
        else
        {
            Console.WriteLine("Senha antiga incorreta. Tente novamente.");
        }
    }


    static void FecharCaixa()
    {
        Console.WriteLine("Informe a senha atual para fechar o caixa:");
        string senhaFechamento = Console.ReadLine();

        if (senhaFechamento == senha123)
        {
            Console.Clear();
            Console.WriteLine("-------- PRODUTOS NO CAIXA --------");
            ListarProdutos();

            Console.WriteLine("\nO programa será finalizado em 20 segundos...");
            Thread.Sleep(20000);
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Senha incorreta! Não foi possível fechar o caixa.");
        }
    }
}

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }

    public Produto(int id, string nome, int quantidade)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
    }
}
