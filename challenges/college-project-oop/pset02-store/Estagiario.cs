class Estagiario : Funcionario {
    public Estagiario(string nome, int matricula) {
        Nome = nome;
        Matricula = matricula;
    }

    public float calcularDescontoMenor(float valorProduto) {
        float valorComDesconto = valorProduto * 0.95f;
        System.Console.WriteLine($"\nDesconto realizado. O preço agora é R$ {valorComDesconto}");
        return valorComDesconto;
    }
}