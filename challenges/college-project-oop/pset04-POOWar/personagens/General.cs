using POOWar.armas;
using System;

namespace POOWar.personagens
{
    public class General : Personagem, ICorrer
    {
        public General()
        {
            hitPoints = 90;
            nome = "General";
            setArma(new Fuzil());
        }

        public override void desenhar()
        {
            Console.WriteLine("O general desenhou uma bandeira");
        }

        public override void falar()
        {
            Console.WriteLine("General: Renda-se antes que seja tarde");
        }

        public override string fugir()
        {
            correr();
            return base.fugir();
        }

        public void correr() {
            System.Console.WriteLine("O general tentou fugir correndo");
        }
    }
}