using System;

namespace POOWar.armas
{
    public class Desarmado : Arma_IF
    {
        public Desarmado()
        {
            dano = 5;
        }

        public override float usarArma()
        {
            return base.usarArma();
        }

    }
}