using System;

class Pedido {
    private static int totalPedidos = 0; 
    public int pedidoId { get; set; }
    public DateTime dataEmissao { get; set; }
    public string nomeDoProduto { get; set; }
    public float valorDoProduto { get; set; }
    public string descricaoDoProduto { get; set; }
    public int quantidadeDoProduto { get; set; }

    public Pedido(string nomeDoProduto, float valorDoProduto, string descricaoDoProduto, int quantidadeDoProduto)
    {
        totalPedidos++;
        this.pedidoId = totalPedidos;
        this.dataEmissao = DateTime.Now;
        this.nomeDoProduto = nomeDoProduto;
        this.valorDoProduto = valorDoProduto;
        this.descricaoDoProduto = descricaoDoProduto;
        this.quantidadeDoProduto = quantidadeDoProduto;
    }

    public float calcularPrecoTotal() {
        return valorDoProduto * quantidadeDoProduto;   
    }
}