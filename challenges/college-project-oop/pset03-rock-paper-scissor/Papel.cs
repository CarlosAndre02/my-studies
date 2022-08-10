class Papel : Coisa {
    public override string tipoCoisa() {
        return "Papel";
    }

    public override string QuemEssaCoisaGanha() {
        return "Pedra";
    }

    public override string QuemEssaCoisaPerde() {
        return "Tesoura";
    }
}