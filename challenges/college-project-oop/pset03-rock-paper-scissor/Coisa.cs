abstract class Coisa {
    public string checarQuemGanhou(Coisa coisaIA) {
        if(tipoCoisa() == coisaIA.QuemEssaCoisaPerde()) return "Jogador";
        if(tipoCoisa() == coisaIA.QuemEssaCoisaGanha()) return "IA";
        return "Empate";
    }
    public abstract string tipoCoisa();
    public abstract string QuemEssaCoisaGanha();
    public abstract string QuemEssaCoisaPerde();
}