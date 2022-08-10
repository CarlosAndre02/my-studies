class Produto {
    public string produto { get; set; }
    public int codigo { get; set; }
    public float preco { get; set; }
    public string descricao { get; set; }

    public Produto(string produto, int codigo, float preco, string descricao) {
        this.produto = produto;
        this.codigo = codigo;
        this.preco = preco;
        this.descricao = descricao;
    }
}