using POOWar.armas;
using System;

namespace POOWar.personagens
{
    public class Mago : Personagem, ICorrer
    {
        public Mago()
        {
            hitPoints = 85;
            nome = "Mago";
            setArma(new Raio());
        }

        public override void desenhar()
        {
            Console.WriteLine("O mago desenhou runas magicas");
        }

        public override void falar()
        {
            Console.WriteLine("Mago: Você será um otimo alvo!");
        }

        public override string fugir()
        {
            correr();
            return base.fugir();
        }

        public void correr()
        {
            System.Console.WriteLine("O mago tentou fugir correndo");
        }
    }
}