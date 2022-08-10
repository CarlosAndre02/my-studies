using System;

class Gerente : Funcionario
{
    private string Senha { get; set; }

    public Gerente(string senha, string nome, int matricula)
    {
        Senha = senha;
        Nome = nome;
        Matricula = matricula;
    }
    public float calcularDescontoMaior(float valorProduto)
    {
        float valorComDesconto = valorProduto;
        while (true)
        {
            System.Console.WriteLine("Digite a senha: ");
            string senha = Console.ReadLine();

            if (Senha == senha)
            {
                valorComDesconto *= 0.9f;
                System.Console.WriteLine($"\nDesconto realizado. O preço do produto agora é R$ {valorComDesconto}");
                break;
            }

            System.Console.WriteLine("Senha Errada! Deseja sair (digite 0) ou continuar (digite qualquer número): ");
            int op = Int32.Parse(Console.ReadLine());
            if (op == 0) break;
        }
        return valorComDesconto;
    }
}