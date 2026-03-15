using System;

namespace JuegoPOO
{
    public class Arquero : Personaje
    {
        public Arquero() : base("Arquero", 100, 18)
        {
        }

        // Ataque del arquero con variación aleatoria proporcional al ataque base
        public override int Atacar()
        {
            int variacionMax = Math.Max(1, Ataque / 2);
            int variacion = Random.Shared.Next(0, variacionMax + 1);
            return Ataque + variacion;
        }
    }
}