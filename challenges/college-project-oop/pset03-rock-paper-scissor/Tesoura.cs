class Tesoura : Coisa {
    public override string tipoCoisa() {
        return "Tesoura";
    }

    public override string QuemEssaCoisaGanha() {
        return "Papel";
    }

    public override string QuemEssaCoisaPerde() {
        return "Pedra";
    }
}