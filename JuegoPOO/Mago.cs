using System;

namespace JuegoPOO
{
    public class Mago : Personaje
    {
        public Mago() : base("Mago", 80, 25)
        {
        }

        // Ataque del mago con variación aleatoria (más rango por su alto ataque)
        public override int Atacar()
        {
            int variacionMax = Math.Max(1, Ataque / 2);
            int variacion = Random.Shared.Next(0, variacionMax + 1);
            return Ataque + variacion;
        }
    }
}