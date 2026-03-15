using System;
using System.Drawing;
using System.Windows.Forms;

namespace JuegoPOO
{
    public class BossForm : Form
    {
        private readonly Personaje jugador;
        private readonly Boss enemigo;
        private readonly Random rnd = Random.Shared;

        // Controles
        private Label lblJugador;
        private Label lblVidaJugador;
        private ProgressBar pbVidaJugador;
        private PictureBox pbImagenJugador;

        private Label lblEnemigo;
        private Label lblVidaEnemigo;
        private ProgressBar pbVidaEnemigo;
        private PictureBox pbImagenEnemigo;

        private Button btnAtacar;
        private Button btnEspecial;
        private Button btnCurar;
        private Button btnRendirse;

        private TextBox txtLog;

        // Vida máxima mostrada en las ProgressBar (se utilizan VidaMax del Personaje)
        private int vidaMaxJugador;
        private int vidaMaxEnemigo;

        public BossForm(Personaje jugador)
        {
            this.jugador = jugador ?? throw new ArgumentNullException(nameof(jugador));
            this.enemigo = new Boss();

            InitializeComponent();
            InicializarCombate();
        }

        private void InitializeComponent()
        {
            pbImagenJugador = new PictureBox();
            lblJugador = new Label();
            lblVidaJugador = new Label();
            pbVidaJugador = new ProgressBar();
            pbImagenEnemigo = new PictureBox();
            lblEnemigo = new Label();
            lblVidaEnemigo = new Label();
            pbVidaEnemigo = new ProgressBar();
            btnAtacar = new Button();
            btnEspecial = new Button();
            btnCurar = new Button();
            btnRendirse = new Button();
            txtLog = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbImagenJugador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImagenEnemigo).BeginInit();
            SuspendLayout();
            // 
            // pbImagenJugador
            // 
            pbImagenJugador.BorderStyle = BorderStyle.FixedSingle;
            pbImagenJugador.Location = new Point(12, 12);
            pbImagenJugador.Name = "pbImagenJugador";
            pbImagenJugador.Size = new Size(128, 128);
            pbImagenJugador.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagenJugador.TabIndex = 0;
            pbImagenJugador.TabStop = false;
            // 
            // lblJugador
            // 
            lblJugador.Location = new Point(150, 12);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(420, 22);
            lblJugador.TabIndex = 1;
            lblJugador.Text = "Jugador: -";
            // 
            // lblVidaJugador
            // 
            lblVidaJugador.Location = new Point(150, 36);
            lblVidaJugador.Name = "lblVidaJugador";
            lblVidaJugador.Size = new Size(200, 20);
            lblVidaJugador.TabIndex = 2;
            lblVidaJugador.Text = "Vida: 0/0";
            // 
            // pbVidaJugador
            // 
            pbVidaJugador.Location = new Point(146, 59);
            pbVidaJugador.Name = "pbVidaJugador";
            pbVidaJugador.Size = new Size(540, 20);
            pbVidaJugador.TabIndex = 3;
            // 
            // pbImagenEnemigo
            // 
            pbImagenEnemigo.BorderStyle = BorderStyle.FixedSingle;
            pbImagenEnemigo.Location = new Point(591, 111);
            pbImagenEnemigo.Name = "pbImagenEnemigo";
            pbImagenEnemigo.Size = new Size(128, 128);
            pbImagenEnemigo.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagenEnemigo.TabIndex = 4;
            pbImagenEnemigo.TabStop = false;
            // 
            // lblEnemigo
            // 
            lblEnemigo.Location = new Point(150, 200);
            lblEnemigo.Name = "lblEnemigo";
            lblEnemigo.Size = new Size(420, 22);
            lblEnemigo.TabIndex = 5;
            lblEnemigo.Text = "Enemigo: -";
            // 
            // lblVidaEnemigo
            // 
            lblVidaEnemigo.Location = new Point(150, 222);
            lblVidaEnemigo.Name = "lblVidaEnemigo";
            lblVidaEnemigo.Size = new Size(200, 20);
            lblVidaEnemigo.TabIndex = 6;
            lblVidaEnemigo.Text = "Vida: 0/0";
            // 
            // pbVidaEnemigo
            // 
            pbVidaEnemigo.Location = new Point(150, 245);
            pbVidaEnemigo.Name = "pbVidaEnemigo";
            pbVidaEnemigo.Size = new Size(540, 20);
            pbVidaEnemigo.TabIndex = 7;
            // 
            // btnAtacar
            // 
            btnAtacar.Location = new Point(150, 310);
            btnAtacar.Name = "btnAtacar";
            btnAtacar.Size = new Size(100, 36);
            btnAtacar.TabIndex = 8;
            btnAtacar.Text = "Atacar";
            btnAtacar.UseVisualStyleBackColor = true;
            btnAtacar.Click += BtnAtacar_Click;
            // 
            // btnEspecial
            // 
            btnEspecial.Location = new Point(283, 310);
            btnEspecial.Name = "btnEspecial";
            btnEspecial.Size = new Size(100, 36);
            btnEspecial.TabIndex = 9;
            btnEspecial.Text = "Especial";
            btnEspecial.UseVisualStyleBackColor = true;
            btnEspecial.Click += BtnEspecial_Click;
            // 
            // btnCurar
            // 
            btnCurar.Location = new Point(428, 310);
            btnCurar.Name = "btnCurar";
            btnCurar.Size = new Size(100, 36);
            btnCurar.TabIndex = 10;
            btnCurar.Text = "Curar";
            btnCurar.UseVisualStyleBackColor = true;
            btnCurar.Click += BtnCurar_Click;
            // 
            // btnRendirse
            // 
            btnRendirse.Location = new Point(563, 310);
            btnRendirse.Name = "btnRendirse";
            btnRendirse.Size = new Size(100, 36);
            btnRendirse.TabIndex = 11;
            btnRendirse.Text = "Rendirse";
            btnRendirse.UseVisualStyleBackColor = true;
            btnRendirse.Click += BtnRendirse_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(49, 373);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(700, 128);
            txtLog.TabIndex = 12;
            // 
            // BossForm
            // 
            ClientSize = new Size(863, 552);
            Controls.Add(pbImagenJugador);
            Controls.Add(lblJugador);
            Controls.Add(lblVidaJugador);
            Controls.Add(pbVidaJugador);
            Controls.Add(pbImagenEnemigo);
            Controls.Add(lblEnemigo);
            Controls.Add(lblVidaEnemigo);
            Controls.Add(pbVidaEnemigo);
            Controls.Add(btnAtacar);
            Controls.Add(btnEspecial);
            Controls.Add(btnCurar);
            Controls.Add(btnRendirse);
            Controls.Add(txtLog);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "BossForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Combate: Boss";
            Load += BossForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbImagenJugador).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImagenEnemigo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void InicializarCombate()
        {
            // Usar VidaMax de los objetos para establece máximos correctos
            vidaMaxJugador = Math.Max(1, jugador.VidaMax);
            vidaMaxEnemigo = Math.Max(1, enemigo.VidaMax);

            lblJugador.Text = $"Jugador: {jugador.Nombre}";
            lblVidaJugador.Text = $"Vida: {jugador.Vida}/{vidaMaxJugador}";

            lblEnemigo.Text = $"Enemigo: {enemigo.Nombre}";
            lblVidaEnemigo.Text = $"Vida: {enemigo.Vida}/{vidaMaxEnemigo}";

            pbVidaJugador.Maximum = vidaMaxJugador;
            pbVidaJugador.Value = Math.Max(pbVidaJugador.Minimum, Math.Min(pbVidaJugador.Maximum, jugador.Vida));

            pbVidaEnemigo.Maximum = vidaMaxEnemigo;
            pbVidaEnemigo.Value = Math.Max(pbVidaEnemigo.Minimum, Math.Min(pbVidaEnemigo.Maximum, enemigo.Vida));

            pbImagenJugador.Image = jugador.Imagen ?? GetImageForPersonaje(jugador);
            pbImagenEnemigo.Image = enemigo.Imagen ?? GetImageForPersonaje(enemigo);

            txtLog.Clear();
            txtLog.AppendText($"Comienza el combate contra {enemigo.Nombre}.\r\n");
            txtLog.AppendText($"Boss Vida: {enemigo.Vida}, Ataque: {enemigo.Ataque}\r\n");
        }

        private void BtnAtacar_Click(object? sender, EventArgs e)
        {
            if (CombateFinalizado()) return;

            int daño = jugador.Atacar();
            AplicarDañoEnemigo(daño, $"Jugador hizo {daño} de daño.");
            if (enemigo.Vida <= 0) { Ganar(); return; }

            TurnoEnemigo();
        }

        private void BtnEspecial_Click(object? sender, EventArgs e)
        {
            if (CombateFinalizado()) return;

            int daño = jugador.Atacar() * 2;
            AplicarDañoEnemigo(daño, $"Jugador usó especial y hizo {daño} de daño.");
            if (enemigo.Vida <= 0) { Ganar(); return; }

            TurnoEnemigo();
        }

        private void BtnCurar_Click(object? sender, EventArgs e)
        {
            if (CombateFinalizado()) return;

            int curacion = Math.Min(30, vidaMaxJugador - jugador.Vida);
            if (curacion <= 0)
            {
                txtLog.AppendText("No puedes curarte más.\r\n");
                return;
            }

            jugador.Curar(curacion);
            txtLog.AppendText($"{jugador.Nombre} se curó {curacion} puntos.\r\n");
            ActualizarBarras();
            TurnoEnemigo();
        }

        private void BtnRendirse_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("¿Rendirse y volver al menú?", "Rendirse", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void TurnoEnemigo()
        {
            if (CombateFinalizado()) return;

            int roll = rnd.Next(0, 100);

            if (roll < 15)
            {
                int dañoEspecial = enemigo.AtacarEspecial();
                AplicarDañoJugador(dañoEspecial, $"¡Boss usó Ataque Especial y causó {dañoEspecial} de daño!");
            }
            else if (roll < 30)
            {
                int redu = enemigo.RugirDebilitante(jugador);
                txtLog.AppendText($"Boss usó Rugido Debilitante: redujo el ataque del jugador en {redu} puntos.\r\n");
            }
            else
            {
                int daño = enemigo.Atacar();
                AplicarDañoJugador(daño, $"Boss atacó y causó {daño} de daño.");
            }
        }

        private void AplicarDañoJugador(int daño, string log)
        {
            jugador.RecibirDaño(daño);
            txtLog.AppendText(log + "\r\n");
            ActualizarBarras();

            if (jugador.Vida <= 0)
            {
                MessageBox.Show("Has sido derrotado por el Boss.");
                Close();
            }
        }

        private void AplicarDañoEnemigo(int daño, string log)
        {
            enemigo.RecibirDaño(daño);
            txtLog.AppendText(log + "\r\n");
            ActualizarBarras();
        }

        private void ActualizarBarras()
        {
            pbVidaJugador.Value = Math.Max(pbVidaJugador.Minimum, Math.Min(pbVidaJugador.Maximum, jugador.Vida));
            lblVidaJugador.Text = $"Vida: {jugador.Vida}/{vidaMaxJugador}";

            pbVidaEnemigo.Value = Math.Max(pbVidaEnemigo.Minimum, Math.Min(pbVidaEnemigo.Maximum, enemigo.Vida));
            lblVidaEnemigo.Text = $"Vida: {enemigo.Vida}/{vidaMaxEnemigo}";
        }

        private bool CombateFinalizado()
        {
            if (jugador.Vida <= 0 || enemigo.Vida <= 0)
            {
                MessageBox.Show("El combate ha terminado.");
                return true;
            }
            return false;
        }

        private void Ganar()
        {
            txtLog.AppendText("¡Has derrotado al Boss!\r\n");
            MessageBox.Show("¡Ganaste al Boss!");
            Close();
        }

        private Image GetImageForPersonaje(Personaje p)
        {
            if (p == null) return SystemIcons.Application.ToBitmap();

            try
            {
                var obj = JuegoPOO.Properties.Resources.ResourceManager.GetObject(p.Nombre ?? string.Empty, JuegoPOO.Properties.Resources.Culture);
                if (obj is Image img) return img;
            }
            catch { }

            try
            {
                var defObj = JuegoPOO.Properties.Resources.ResourceManager.GetObject("Default", JuegoPOO.Properties.Resources.Culture);
                if (defObj is Image defImg) return defImg;
            }
            catch { }

            return SystemIcons.Application.ToBitmap();
        }

        private void BossForm_Load(object sender, EventArgs e)
        {

        }

        private void lblEnemigo_Click(object sender, EventArgs e)
        {

        }
    }
}