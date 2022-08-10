using POOWar.personagens;
using System;

class Jogo
{
    public Personagem personagemJogador;
    public Personagem personagemIA;

    public void main()
    {
        selecionarPersonagemJogador();
        criarPersonagemIA();
        Console.Clear();
        Console.WriteLine($"Inicia o combate: {personagemJogador.nome} VS {personagemIA.nome}");
        while(true) {
            string acaoJogador = escolherAcao("jogador");
            string acaoIA = escolherAcao("ia");

            executarAcoes(acaoJogador, acaoIA);

            if(personagemJogador.hitPoints <= 0 && personagemIA.hitPoints <= 0) {
                System.Console.WriteLine("\nEmpate! Não sobrou ninguém de pé\n");
                break;
            } 

            if(personagemJogador.hitPoints <= 0) {
                System.Console.WriteLine("\nVocê perdeu :/\n");
                break;
            } 

            if(personagemIA.hitPoints <= 0) {
                System.Console.WriteLine("\nVocê ganhou!!! Tu é brabo\n");
                break;
            }
        }
    }

    private void selecionarPersonagemJogador() {
        while (true)
        {
            int e;
            Console.WriteLine("Selecione o seu personagem" +
            "\n 1 - Dragão Alado \n 2 - General \n 3 - Lutador de Sumô \n 4 - Mago \n 5 - Soldado" +
            "\nSua escolha:");
            Int32.TryParse(Console.ReadLine(), out e);

            switch (e)
            {
                case 1:
                    personagemJogador = new DragaoAlado();
                    break;
                case 2:
                    personagemJogador = new General();
                    break;
                case 3:
                    personagemJogador = new LutadorSumo();
                    break;
                case 4:
                    personagemJogador = new Mago();
                    break;
                case 5:
                    personagemJogador = new Soldado();
                    break;
            }

            if (e > 0 && e < 6)
            {
                break;
            }
            else
            {
                Console.WriteLine("\nOpção Invalida, tente novamente\n");
            }
        }
    }

    private void criarPersonagemIA() {
        Random rnd = new Random();
        int numero = rnd.Next(1,6);
        switch (numero)
            {
                case 1:
                    personagemIA = new DragaoAlado();
                    break;
                case 2:
                    personagemIA = new General();
                    break;
                case 3:
                    personagemIA = new LutadorSumo();
                    break;
                case 4:
                    personagemIA = new Mago();
                    break;
                case 5:
                    personagemIA = new Soldado();
                    break;
            }
    }
    private string escolherAcao(string caller) {
        string[] acoes = new string[2] { "Atacar", "Fugir"};
        if(caller == "ia") {
            Random rnd = new Random();
            int numero = rnd.Next(2);
            return acoes[numero];
        }

        System.Console.WriteLine("\nDigite o número da ação que deseja escolher: Atacar(0), Fugir(1)");
        int op = Int32.Parse(Console.ReadLine());
        return acoes[op];
    }
    private void executarAcoes(string acaoJogador, string acaoIA) {
        if(acaoJogador == "Atacar") {
            if(acaoIA == "Atacar") {
                personagemJogador.hitPoints -= personagemIA.atacar();
                personagemIA.hitPoints -= personagemJogador.atacar();
                System.Console.WriteLine($"A IA também escolheu atacar!! Você recebeu {personagemIA.atacar():0.##} e a IA recebeu {personagemJogador.atacar():0.##}");
            }
            if(acaoIA == "Fugir") {
                System.Console.WriteLine("A IA escolheu fugir...");
                executarFugir("IA");
            }
        } else if(acaoJogador == "Fugir") {
            if(acaoIA == "Atacar") {
                System.Console.WriteLine("A IA escolheu atacar...");
                executarFugir("Jogador");
            } 
            if(acaoIA == "Fugir") {
                System.Console.WriteLine("Ambos fugiram! Nada aconteceu");
            }
        } else {
            System.Console.WriteLine("Erro...");
            return;
        }
        mostrarHpAtual();
    }
    private void mostrarHpAtual() {
        System.Console.WriteLine($"HP atual --> Você: {personagemJogador.hitPoints:0.##} | IA: {personagemIA.hitPoints:0.##}");
    }

    private void executarFugir(string caller) {
        Personagem personagemFugindo = caller == "Jogador" ? personagemJogador : personagemIA;  
        Personagem personagemAtacando = caller == "Jogador" ? personagemIA : personagemJogador;  
        string resultadoFuga = personagemFugindo.fugir();

        float porcentagemDano;
        if(resultadoFuga == "Perfeita") {
            porcentagemDano = 0f;
        } else if (resultadoFuga == "Parcial") {
            porcentagemDano = 0.5f;
        } else if(resultadoFuga == "Desastrosa") {
            porcentagemDano = 0.9f; 
        } else {
            System.Console.WriteLine("Erro...");
            return;
        }

        float danoRecebido = personagemAtacando.atacar() * porcentagemDano;
        personagemFugindo.hitPoints -= danoRecebido;
        System.Console.WriteLine($"A fuga foi {resultadoFuga}!! {caller} recebeu {danoRecebido:0.##} de dano");
    }
}