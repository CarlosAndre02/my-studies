class Pedra : Coisa {
    public override string tipoCoisa() {
        return "Pedra";
    }

    public override string QuemEssaCoisaGanha() {
        return "Tesoura";
    }  

    public override string QuemEssaCoisaPerde() {
        return "Papel";
    }
}