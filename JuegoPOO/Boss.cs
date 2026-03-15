using System;
using System.Drawing;

namespace JuegoPOO
{
    public class Boss : Personaje
    {
        // Usar Random.Shared (seguro y recomendado en .NET 6+)
        private static readonly Random rnd = Random.Shared;

        public Boss() : base("Jefe Final", 200, 20, CargarImagen())
        {
        }

        // Sobrescribe Atacar: 20% probabilidad de crítico (x2), en caso contrario daño base + 5
        public override int Atacar()
        {
            return rnd.NextDouble() < 0.20 ? Ataque * 2 : Ataque + 5;
        }

        // Ataque especial del Boss (más potente, con pequeña probabilidad de crítico x2)
        public int AtacarEspecial()
        {
            bool crit = rnd.NextDouble() < 0.15;
            int daño = Ataque * 2;
            if (crit) daño *= 2;
            return daño;
        }

        // Habilidad de control: reduce temporalmente el ataque del objetivo (debuff simple)
        // Devuelve la cantidad de reducción aplicada.
        public int RugirDebilitante(Personaje objetivo, int reduccion = 3)
        {
            if (objetivo == null) return 0;
            int aplicado = Math.Min(reduccion, Math.Max(0, objetivo.Ataque - 1)); // no dejar ataque < 1
            objetivo.Ataque = Math.Max(1, objetivo.Ataque - aplicado);
            return aplicado;
        }

        public override string ToString()
        {
            return $"{Nombre} (Vida: {Vida}, Ataque: {Ataque})";
        }

        // Intentar cargar una imagen desde los recursos (fallback a null si no existe)
        private static Image? CargarImagen()
        {
            try
            {
                var obj = JuegoPOO.Properties.Resources.ResourceManager.GetObject("JefeFinal", JuegoPOO.Properties.Resources.Culture);
                if (obj is Image img) return img;
            }
            catch
            {
                // ignorar fallos y devolver null -> Form1 usa fallback
            }
            return null;
        }
    }
}