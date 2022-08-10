using System;

namespace POOWar.armas
{
    public abstract class Arma_IF
    {
        public float dano;
        public virtual float usarArma()
        {
            return dano;
        }
    }
}