using System;

class Jogo {
    private int PontuacaoJogador;
    private int PontuacaoIA;

    public Jogo() {
        PontuacaoJogador = 0;
        PontuacaoIA = 0;
    }

    public void iniciar() {
        Console.WriteLine("Bem vindo ao Pedra Papel Tesoura da UVV");
        main();
    }

    private void main() {
        while(true) {
            System.Console.WriteLine("Digite o número da sua escolha: Pedra(1), Papel(2) ou Tesoura(3): ");
            int escolhaJogador = Int32.Parse(Console.ReadLine());
            Coisa coisaJogador = CriarCoisa(escolhaJogador);
            Coisa coisaIA = CriarCoisa(escolherCoisaParaIa());

            string ganhador = coisaJogador.checarQuemGanhou(coisaIA);
            System.Console.WriteLine($"\nVocê escolheu --> {coisaJogador.tipoCoisa()}");
            System.Console.WriteLine($"A IA escolheu --> {coisaIA.tipoCoisa()}");
            System.Console.WriteLine($"O vencedor foi --> {ganhador}");
            
            marcarPonto(ganhador);
            mostrarPlacar();

            System.Console.WriteLine("\nDeseja jogar novamente: Sim(s) ou Nâo(n)");
            string op = Console.ReadLine();
            if(op == "n") break;
            
            Console.Clear();
        }
    }

    private int escolherCoisaParaIa() {
        Random random = new Random();
        return random.Next(1, 4);
    }

    private Coisa CriarCoisa(int coisaNumero) {
        if(coisaNumero == 1) return new Pedra();
        else if(coisaNumero == 2) return new Papel();
        else return new Tesoura();
    }

    private void marcarPonto(string ganhador) {
        if(ganhador == "Jogador")  PontuacaoJogador++;
        if(ganhador == "IA")  PontuacaoIA++;
    }

    private void mostrarPlacar() {
        Console.WriteLine($"Placar: Jogador -> {PontuacaoJogador} ponto(s) | IA -> {PontuacaoIA} ponto(s)");
    }
}