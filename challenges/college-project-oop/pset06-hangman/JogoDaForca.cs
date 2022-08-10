using System;
using System.Collections.Generic;

class JogoDaForca
{
    private string SecretWord { get; set; }
    private int attempts { get; set; }
    private List<string> playerHints;
    private bool isGameFinished;
    public JogoDaForca()
    {
        this.SecretWord = this.getRandomWord();
        this.playerHints = new List<string>();
        this.attempts = 6;
        this.showInitialInstructions();
    }

    public string getRandomWord()
    {
        string[] words = new string[5] { "javascript", "estapafurdio", "concomitante", "paralelepipedo", "botafogo" };
        Random rnd = new Random();
        return words[rnd.Next(4)];
    }

    public void showInitialInstructions()
    {
        Console.WriteLine("Bem vindo ao Jogo Da Forca CLI!!!");
        Console.WriteLine("As regras são o seguinte:");
        Console.WriteLine($"- Você tem {this.attempts} tentativas para acertar qual é a palavra");
        Console.WriteLine("- Chute apenas LETRAS! Chutes com mais de um caracter ou vazio não são válidos");
        Console.WriteLine("As palavras secretas não têm acento ou letra maiúscula");
        Console.WriteLine("Dito isso, vamos jogar!");
        this.showSecretWord();
    }

    public void handleGame()
    {
        string playerHint = getPlayerHint().ToLower().Trim();
        if (playerHint.Length != 1 || playerHint.Equals(" "))
            throw new Exception("Hum... Entrada inválida. Reveja as regras.");
        if (this.isHintRepetitive(playerHint)) throw new Exception("Chute repetido. Tente denovo");

        this.playerHints.Add(playerHint);
        if (isLetterHintCorrect(playerHint))
        {
            if (isPlayerWinner())
            {
                Console.WriteLine("\nQue cara bom vei, você ganhou!!!");
                this.isGameFinished = true;
            }
            else
            {
                Console.WriteLine("\nBoa man, tu acertou!");
            }
        }
        else
        {
            Console.WriteLine("\nChute errado amigão");
            this.attempts--;
        }
        if (!isPlayerWinner()) this.showGameStats();
        this.showSecretWord();
    }

    public string getPlayerHint()
    {
        Console.WriteLine("\n\n\nDê o seu chute: ");
        string userHint = Console.ReadLine();
        return userHint;
    }

    public bool isHintRepetitive(string actualPlayerHint)
    {
        foreach (string hint in this.playerHints)
        {
            if (actualPlayerHint == hint) return true;
        }
        return false;
    }

    public bool isLetterHintCorrect(string playerHint)
    {
        foreach (char letter in this.SecretWord)
        {
            if (letter == Char.Parse(playerHint)) return true;
        }
        return false;
    }

    public bool isPlayerWinner()
    {
        int points = 0;
        foreach (char letter in this.SecretWord)
        {
            foreach (string playerHint in this.playerHints)
            {
                if (letter == Char.Parse(playerHint)) points++;
            }
        }
        if (points == SecretWord.Length) return true;
        return false;
    }

    public void showSecretWord()
    {
        Console.Write("\nPalavra -> ");
        foreach (char letter in this.SecretWord)
        {
            bool isCharRight = false;
            foreach (string playerHint in this.playerHints)
            {
                if (letter == Char.Parse(playerHint)) isCharRight = true;
            }
            if (isCharRight) Console.Write(letter);
            else Console.Write("_");
        }
    }

    public void showGameStats()
    {
        if (this.attempts == 0) return;
        Console.WriteLine($"\nVocê ainda tem {this.attempts} tentativa(s)");

        Console.Write("Seus chutes foram -> ");
        foreach (string playerHint in this.playerHints)
        {
            Console.Write(playerHint);

            if (playerHint == this.playerHints[playerHints.Count - 1])
                Console.Write(".");
            else
                Console.Write(", ");
        }
    }

    public bool isUserPlaying()
    {
        if (this.attempts == 0)
        {
            Console.WriteLine("\nTu perdeu :( tenta denovo ai");
            return false;
        }
        if (this.isGameFinished) return false;
        return true;
    }
}