using System;

namespace POOWar.armas
{
    public class Revolver : Arma_IF
    {
        public Revolver()
        {
            dano = 15;
        }

        public override float usarArma()
        {
            return base.usarArma();
        }
    }
}