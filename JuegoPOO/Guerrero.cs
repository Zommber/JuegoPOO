using System;

namespace JuegoPOO
{
    public class Guerrero : Personaje
    {
        public Guerrero() : base("Guerrero", 120, 15)
        {
        }

        // Ataque con bono fijo + variación aleatoria proporcional al ataque base
        public override int Atacar()
        {
            int bonoBase = 5;
            int variacionMax = Math.Max(1, Ataque / 2);
            int variacion = Random.Shared.Next(0, variacionMax + 1); // 0..variacionMax
            return Ataque + bonoBase + variacion;
        }

        public override string ToString() => $"{Nombre} (Vida: {Vida}, Ataque: {Ataque})";
    }
}