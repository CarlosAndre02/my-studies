using System;

class Program
{
    static void Main(string[] args)
    {
        JogoDaForca game = new JogoDaForca();
        bool isPlaying = true;

        while (isPlaying)
        {
            try
            {
                game.handleGame();
                isPlaying = game.isUserPlaying();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

