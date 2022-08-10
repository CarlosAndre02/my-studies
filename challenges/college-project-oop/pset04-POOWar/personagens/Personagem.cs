using POOWar.armas;
using System;

namespace POOWar.personagens
{
    public abstract class Personagem
    {
        public string nome { get; protected set; }
        public Arma_IF armaAtual;
        private float _hitPoints;
        public float hitPoints { get => _hitPoints; set => _hitPoints = value > 0 ? value : 0; }
        public abstract void desenhar();
        public abstract void falar();

        public virtual string fugir()
        {
            string[] efetividadesFuga = new string[3] { "Perfeita", "Parcial", "Desastrosa" };
            Random rnd = new Random();
            int numeroAleatorio = rnd.Next(3);
            return efetividadesFuga[numeroAleatorio];
        }

        public float atacar()
        {
            return armaAtual.usarArma();
        }

        public void setArma(Arma_IF arma)
        {
            armaAtual = arma;
        }
    }
}