using System;
using System.Drawing;

namespace JuegoPOO
{
    public class Personaje
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public Image? Imagen { get; set; }

        // Nueva propiedad para vida máxima (se fija al crear el personaje)
        public int VidaMax { get; private set; }

        public Personaje(string nombre, int vida, int ataque, Image? imagen = null)
        {
            Nombre = nombre;
            VidaMax = Math.Max(1, vida);
            Vida = VidaMax;
            Ataque = Math.Max(1, ataque);
            Imagen = imagen;
        }

        public virtual int Atacar()
        {
            return Ataque;
        }

        // Encapsula recibir daño (evita vida negativa)
        public void RecibirDaño(int daño)
        {
            if (daño <= 0) return;
            Vida = Math.Max(0, Vida - daño);
        }

        // Encapsula curación respetando VidaMax
        public void Curar(int cantidad)
        {
            if (cantidad <= 0) return;
            Vida = Math.Min(VidaMax, Vida + cantidad);
        }
    }
}