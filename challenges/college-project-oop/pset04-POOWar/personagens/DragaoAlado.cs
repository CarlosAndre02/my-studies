using POOWar.armas;
using System;

namespace POOWar.personagens
{
    public class DragaoAlado : Personagem, IVoar
    {
        public DragaoAlado()
        {
            hitPoints = 130;
            nome = "Dragão Alado";
            setArma(new SoproDeFogo());
        }
        public override void desenhar()
        {
            Console.WriteLine("O dragão fez o que pode mas não conseguiu segurar um giz.");
        }

        public override void falar()
        {
            Console.WriteLine("Dragão Alado: ROAAAAAAAARH!");
        }

        public override string fugir()
        {
            voar();
            return base.fugir();
        }

        public void voar()
        {
            System.Console.WriteLine("O dragão alado tentou fugir voando");
        }
    }
}