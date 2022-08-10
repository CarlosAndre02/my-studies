using System;

class MainClass
{
    public static void Main(string[] args)
    {
        bool isPlayerLoser = true;
        JogoDoAdivinha game = new JogoDoAdivinha(10, 16);

        Console.WriteLine("Jogo do adivinha! tente adivinhar qual é o número, você tem 16 chances!");
        while (game.GameAttempts > 0)
        {
            Console.WriteLine("\nChute um número: ");
            string playerAttempt = Console.ReadLine();

            if (game.isUserWinner(playerAttempt))
            {
                Console.WriteLine("\nVocê acertou!!! Vidente demais pai");
                isPlayerLoser = false;
                break;
            } 
            else
            {
                Console.WriteLine("Você errou!");
            }

            Console.WriteLine(game.giveHint(game.GameAttempts));
            
            game.GameAttempts--;
            if(game.GameAttempts != 0) Console.WriteLine($"Restam {game.GameAttempts} tentativa(s)");
        }

        if (isPlayerLoser)
        {
            Console.WriteLine("Que azar man, tu perdeu! tenta de novo ai");
        }
    }
}