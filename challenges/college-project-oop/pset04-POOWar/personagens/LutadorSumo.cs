using POOWar.armas;
using System;

namespace POOWar.personagens
{
    public class LutadorSumo : Personagem, ICorrer
    {
        public LutadorSumo()
        {
            hitPoints = 110;
            nome = "Lutador de Sumô";
            setArma(new Desarmado());
        }
        public override void desenhar()
        {
            Console.WriteLine("O lutador de sumô desenhou orquídeas");
        }

        public override void falar()
        {
            Console.WriteLine("Lutador de sumô: Boa luta!");
        }

        public override string fugir()
        {
            correr();
            return base.fugir();
        }

        public void correr() {
            System.Console.WriteLine("O lutador de sumô tentou fugir correndo");
        }
    }
}