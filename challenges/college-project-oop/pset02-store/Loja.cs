using System;
using System.Collections.Generic;

class Loja
{
    public List<Pedido> listaPedidos;
    public List<Produto> produtos;
    public Pedido pedido { get; set; }
    public Gerente gerente;
    public Estagiario estagiario;

    public Loja()
    {
        listaPedidos = new List<Pedido>();

        gerente = new Gerente("12345", "João", 234589);
        estagiario = new Estagiario("Carlos", 111122);

        produtos = new List<Produto>();
        produtos.Add(new Produto("Geladeira", 1, 2000.00f, "Geladeira duas portas"));
        produtos.Add(new Produto("Fogão", 2, 500.00f, "Quatro bocas"));
        produtos.Add(new Produto("Microondas", 3, 700.00f, "Espelhado"));
    }

    public void main()
    {
        System.Console.WriteLine("Bem vindo a loja!");
        while (true)
        {
            System.Console.WriteLine("\n1 - Mostrar Menu\n2 - Fazer um Pedido\n3 - Buscar Pedido\n4 - Remover Pedido\n5 - Sair");
            System.Console.WriteLine("Digite o número da operação que deseja realizar: ");
            int op = Int32.Parse(Console.ReadLine());

            switch (op)
            {
                case 1: menu(); break;
                case 2: inserirPedido(); break;
                case 3: buscarPedido(); break;
                case 4: removerPedido(); break;
            }
            if (op == 5) break;
        }
    }

    public void menu()
    {
        Console.Clear();
        foreach (Produto item in produtos)
        {
            System.Console.WriteLine($"Produto: {item.produto} | Cod: {item.codigo} | Preço: R$ {item.preco} | Descrição: {item.descricao}");
        }
    }

    public void inserirPedido()
    {
        System.Console.WriteLine("\nDigite o código do produto: ");
        int codigoProduto = Int32.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite a quantidade: ");
        int quantidade = Int32.Parse(Console.ReadLine());

        System.Console.WriteLine("Deseja pedir desconto (Sim/Não): ");
        string desconto = Console.ReadLine().ToLower().Trim();

        Pedido pedido = null;
        foreach (Produto item in produtos)
        {
            float precoDoProduto = item.preco;

            if (item.codigo == codigoProduto)
            {
                if (desconto == "sim")
                {
                    precoDoProduto = calcularDesconto(item);
                }
                pedido = new Pedido(item.produto, precoDoProduto, item.descricao, quantidade);
            }
        }

        if (pedido != null)
        {
            listaPedidos.Add(pedido);
            System.Console.WriteLine($"Pedido realizado com sucesso. O Id do seu pedido é {pedido.pedidoId}");
        }
        else
        {
            System.Console.WriteLine("Produto não encontrado");
        }

    }

    public void buscarPedido()
    {
        System.Console.WriteLine("\nPara buscar, digite o Id do seu pedido: ");
        int id = Int32.Parse(Console.ReadLine());

        Pedido pedido = null;
        foreach (Pedido item in listaPedidos)
        {
            if (item.pedidoId == id) pedido = item;
        }

        Console.Clear();
        if (pedido != null)
        {
            Console.WriteLine($"Produto: {pedido.nomeDoProduto} | Preço: R$ {pedido.valorDoProduto} | Descrição: {pedido.descricaoDoProduto} | Quantidade: {pedido.quantidadeDoProduto} | Valor total: R$ {pedido.calcularPrecoTotal()} | Feito em: {pedido.dataEmissao}");
        }
        else
        {
            System.Console.WriteLine("Pedido não foi encontrado");
        }
    }

    public void removerPedido()
    {
        System.Console.WriteLine("\nPara remover, digite o Id do seu pedido: ");
        int id = Int32.Parse(Console.ReadLine());

        Pedido pedido = null;
        foreach (Pedido item in listaPedidos)
        {
            if (item.pedidoId == id) pedido = item;
        }

        Console.Clear();
        if (pedido != null)
        {
            listaPedidos.Remove(pedido);
            System.Console.WriteLine("Pedido removido com sucesso");
        }
        else
        {
            System.Console.WriteLine("Pedido não foi encontrado");
        }
    }

    private float calcularDesconto(Produto produto)
    {
        float precoComDesconto = produto.preco;
        while (true)
        {
            System.Console.WriteLine("Deseja pedir desconto pro estagiário (1) ou pro gerente (2): ");
            int funcionario = Int32.Parse(Console.ReadLine().ToLower().Trim());

            Console.Clear();
            if (funcionario == 1)
            {
                precoComDesconto = estagiario.calcularDescontoMenor(produto.preco);
                break;
            }

            if (funcionario == 2)
            {
                precoComDesconto = gerente.calcularDescontoMaior(produto.preco);
                break;
            }

            System.Console.WriteLine("Entrada inválida. Digite 1 para pedir novamente ou 0 para sair");
            int op = Int32.Parse(Console.ReadLine().ToLower().Trim());
            if (op == 0) break;
        }
        return precoComDesconto;
    }
}