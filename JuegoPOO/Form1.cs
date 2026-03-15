using System;
using System.Drawing;
using System.Windows.Forms;

namespace JuegoPOO
{
    public partial class Form1 : Form
    {
        Personaje jugador;
        Personaje enemigo;
        Random rnd = Random.Shared;
        // Flag para que el Boss se lance solo una vez tras vencer al primer enemigo
        private bool bossLanzado = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (cmbPersonaje.Items.Count > 0) cmbPersonaje.SelectedIndex = 0;
            txtLog.Clear();
            txtLog.AppendText("Práctica: crea un personaje y combate.\r\n");
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            switch (cmbPersonaje.Text)
            {
                case "Guerrero":
                    jugador = new Guerrero();
                    break;
                case "Mago":
                    jugador = new Mago();
                    break;
                case "Arquero":
                    jugador = new Arquero();
                    break;
                default:
                    MessageBox.Show("Seleccione un personaje válido.");
                    return;
            }

            // Enemigo estándar
            enemigo = new Personaje("Enemigo", 100, 12);

            lblJugador.Text = $"Jugador: {jugador.Nombre}";
            lblEnemigo.Text = $"Enemigo: {enemigo.Nombre}";

            // Usar VidaMax para Maximum de ProgressBar
            pbVidaJugador.Maximum = jugador.VidaMax;
            pbVidaJugador.Value = Math.Max(pbVidaJugador.Minimum, Math.Min(pbVidaJugador.Maximum, jugador.Vida));
            lblVidaJugador.Text = jugador.Vida.ToString();

            pbVidaEnemigo.Maximum = enemigo.VidaMax;
            pbVidaEnemigo.Value = Math.Max(pbVidaEnemigo.Minimum, Math.Min(pbVidaEnemigo.Maximum, enemigo.Vida));
            lblVidaEnemigo.Text = enemigo.Vida.ToString();

            if (pbImagenJugador != null) pbImagenJugador.Image = jugador.Imagen ?? GetImageForPersonaje(jugador);
            if (pbImagenEnemigo != null) pbImagenEnemigo.Image = enemigo.Imagen ?? GetImageForPersonaje(enemigo);

            txtLog.AppendText($"Creado {jugador.Nombre} (Vida {jugador.Vida}/{jugador.VidaMax}, Ataque {jugador.Ataque}).\r\n");
            txtLog.AppendText("Ha aparecido un enemigo estándar.\r\n");
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            if (EsCombateInvalido()) return;

            int daño = jugador.Atacar();
            enemigo.RecibirDaño(daño);
            txtLog.AppendText($"Jugador hizo {daño} de daño.\r\n");
            ActualizarBarras();

            if (enemigo.Vida <= 0)
            {
                if (enemigo is Boss)
                {
                    MessageBox.Show("¡Ganaste!");
                    return;
                }
                else
                {
                    LanzarBoss();
                    return;
                }
            }

            TurnoEnemigo();
        }

        private void btnEspecial_Click(object sender, EventArgs e)
        {
            if (EsCombateInvalido()) return;

            // Especial ahora usa la lógica de Atacar() para incluir bonificaciones de clase
            int daño = jugador.Atacar() * 2;
            enemigo.RecibirDaño(daño);
            txtLog.AppendText($"Jugador usó especial y hizo {daño} de daño.\r\n");
            ActualizarBarras();

            if (enemigo.Vida <= 0)
            {
                if (enemigo is Boss)
                {
                    MessageBox.Show("¡Ganaste!");
                    return;
                }
                else
                {
                    LanzarBoss();
                    return;
                }
            }

            TurnoEnemigo();
        }

        private void btnCurar_Click(object sender, EventArgs e)
        {
            if (EsCombateInvalido()) return;

            int curacion = 25;
            jugador.Curar(curacion);
            txtLog.AppendText($"{jugador.Nombre} se curó {curacion} puntos.\r\n");
            ActualizarBarras();

            TurnoEnemigo();
        }

        private void TurnoEnemigo()
        {
            if (enemigo == null || jugador == null) return;

            if (enemigo is Boss boss)
            {
                int roll = rnd.Next(0, 100);
                if (roll < 15)
                {
                    int dañoEspecial = boss.AtacarEspecial();
                    jugador.RecibirDaño(dañoEspecial);
                    txtLog.AppendText($"¡Jefe usó Ataque Especial y hizo {dañoEspecial} de daño!\r\n");
                }
                else if (roll < 30)
                {
                    int redu = boss.RugirDebilitante(jugador);
                    txtLog.AppendText($"Jefe usó Rugido Debilitante: redujo el ataque del jugador en {redu} puntos.\r\n");
                }
                else
                {
                    int daño = boss.Atacar();
                    jugador.RecibirDaño(daño);
                    txtLog.AppendText($"Jefe atacó y causó {daño} de daño.\r\n");
                }
            }
            else
            {
                int daño = enemigo.Atacar();
                jugador.RecibirDaño(daño);
                txtLog.AppendText($"Enemigo hizo {daño} de daño.\r\n");
            }

            ActualizarBarras();

            if (jugador.Vida <= 0)
            {
                MessageBox.Show("Has sido derrotado.");
            }
        }

        // Nuevo: abre BossForm cuando corresponde y sincroniza el estado
        private void LanzarBoss()
        {
            if (bossLanzado) return;
            bossLanzado = true;

            txtLog.AppendText("Derrotaste al enemigo. Aparecerá un Boss...\r\n");

            using (var f = new BossForm(jugador))
            {
                f.ShowDialog(this);
            }

            // Sincronizar vida y máximos en Form1
            if (jugador != null)
            {
                pbVidaJugador.Maximum = jugador.VidaMax;
                pbVidaJugador.Value = Math.Max(pbVidaJugador.Minimum, Math.Min(pbVidaJugador.Maximum, jugador.Vida));
                lblVidaJugador.Text = jugador.Vida.ToString();
            }

            enemigo = null;
            lblEnemigo.Text = "Enemigo: -";
            pbVidaEnemigo.Value = pbVidaEnemigo.Minimum;
            lblVidaEnemigo.Text = "0";

            txtLog.AppendText("Has vuelto del combate contra el Boss.\r\n");
        }

        private void ActualizarBarras()
        {
            pbVidaJugador.Maximum = jugador.VidaMax;
            pbVidaJugador.Value = Math.Max(pbVidaJugador.Minimum, Math.Min(pbVidaJugador.Maximum, jugador.Vida));
            lblVidaJugador.Text = jugador.Vida.ToString();

            if (enemigo != null)
            {
                pbVidaEnemigo.Maximum = enemigo.VidaMax;
                pbVidaEnemigo.Value = Math.Max(pbVidaEnemigo.Minimum, Math.Min(pbVidaEnemigo.Maximum, enemigo.Vida));
                lblVidaEnemigo.Text = enemigo.Vida.ToString();
            }
            else
            {
                pbVidaEnemigo.Value = pbVidaEnemigo.Minimum;
                lblVidaEnemigo.Text = "0";
            }
        }

        private bool EsCombateInvalido(bool mostrarMensaje = true)
        {
            if (jugador == null || enemigo == null)
            {
                if (mostrarMensaje) MessageBox.Show("Crea un personaje primero.");
                return true;
            }

            if (jugador.Vida <= 0 || enemigo.Vida <= 0)
            {
                if (mostrarMensaje) MessageBox.Show("El combate ha terminado.");
                return true;
            }

            return false;
        }

        private Image GetImageForPersonaje(Personaje p)
        {
            if (p == null) return SystemIcons.Application.ToBitmap();

            try
            {
                var obj = JuegoPOO.Properties.Resources.ResourceManager.GetObject(p.Nombre ?? string.Empty, JuegoPOO.Properties.Resources.Culture);
                if (obj is Image img) return img;
            }
            catch
            {
            }

            try
            {
                var defObj = JuegoPOO.Properties.Resources.ResourceManager.GetObject("Default", JuegoPOO.Properties.Resources.Culture);
                if (defObj is Image defImg) return defImg;
            }
            catch
            {
            }

            return SystemIcons.Application.ToBitmap();
        }

        private void lblJugador_Click(object sender, EventArgs e)
        {

        }

        private void lblEnemigo_Click(object sender, EventArgs e)
        {

        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIrBoss_Click(object sender, EventArgs e)
        {
            if (jugador == null)
            {
                MessageBox.Show("Crea un personaje primero.");
                return;
            }

            using (var f = new BossForm(jugador))
            {
                f.ShowDialog(this);
                if (jugador != null)
                {
                    pbVidaJugador.Maximum = jugador.VidaMax;
                    pbVidaJugador.Value = Math.Max(pbVidaJugador.Minimum, Math.Min(pbVidaJugador.Maximum, jugador.Vida));
                    lblVidaJugador.Text = jugador.Vida.ToString();
                }
            }
        }
    }
}
