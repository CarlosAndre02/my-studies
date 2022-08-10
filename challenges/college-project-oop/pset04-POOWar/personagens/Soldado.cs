using POOWar.armas;
using System;

namespace POOWar.personagens
{
    public class Soldado : Personagem, ICorrer
    {
        public Soldado()
        {
            hitPoints = 82;
            nome = "Soldado";
            setArma(new Metralhadora());
        }

        public override void desenhar()
        {
            Console.WriteLine("O soldado desenhou um pasto");
        }

        public override void falar()
        {
            Console.WriteLine("Soldado: Pronto para o combate!");
        }

        public override string fugir()
        {
            correr();
            return base.fugir();
        }

        public void correr()
        {
            System.Console.WriteLine("O soldado tentou fugir correndo");
        }
    }
}