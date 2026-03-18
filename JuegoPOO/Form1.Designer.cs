using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace JuegoPOO
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbPersonaje;
        private Button btnCrear;
        private Button btnAtacar;
        private Button btnEspecial;
        private Button btnCurar;
        private ProgressBar pbVidaJugador;
        private ProgressBar pbVidaEnemigo;
        private Label lblJugador;
        private Label lblVidaJugador;
        private Label lblEnemigo;
        private Label lblVidaEnemigo;
        private TextBox txtLog;
        private PictureBox pbImagenJugador;
        private PictureBox pbImagenEnemigo;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbPersonaje = new ComboBox();
            btnCrear = new Button();
            btnAtacar = new Button();
            btnEspecial = new Button();
            btnCurar = new Button();
            pbVidaJugador = new ProgressBar();
            pbVidaEnemigo = new ProgressBar();
            lblJugador = new Label();
            lblVidaJugador = new Label();
            lblEnemigo = new Label();
            lblVidaEnemigo = new Label();
            txtLog = new TextBox();
            pbImagenJugador = new PictureBox();
            pbImagenEnemigo = new PictureBox();
            pictureBox1 = new PictureBox();
            ((ISupportInitialize)pbImagenJugador).BeginInit();
            ((ISupportInitialize)pbImagenEnemigo).BeginInit();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cmbPersonaje
            // 
            cmbPersonaje.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPersonaje.Items.AddRange(new object[] { "Guerrero", "Mago", "Arquero" });
            cmbPersonaje.Location = new Point(43, 38);
            cmbPersonaje.Name = "cmbPersonaje";
            cmbPersonaje.Size = new Size(140, 23);
            cmbPersonaje.TabIndex = 0;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(205, 35);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(90, 26);
            btnCrear.TabIndex = 1;
            btnCrear.Text = "Crear";
            btnCrear.Click += btnCrear_Click;
            // 
            // btnAtacar
            // 
            btnAtacar.BackColor = SystemColors.GradientActiveCaption;
            btnAtacar.Location = new Point(32, 113);
            btnAtacar.Name = "btnAtacar";
            btnAtacar.Size = new Size(100, 28);
            btnAtacar.TabIndex = 9;
            btnAtacar.Text = "Atacar";
            btnAtacar.UseVisualStyleBackColor = false;
            btnAtacar.Click += btnAtacar_Click;
            // 
            // btnEspecial
            // 
            btnEspecial.BackColor = SystemColors.GradientActiveCaption;
            btnEspecial.Location = new Point(150, 113);
            btnEspecial.Name = "btnEspecial";
            btnEspecial.Size = new Size(100, 28);
            btnEspecial.TabIndex = 10;
            btnEspecial.Text = "Especial";
            btnEspecial.UseVisualStyleBackColor = false;
            btnEspecial.Click += btnEspecial_Click;
            // 
            // btnCurar
            // 
            btnCurar.BackColor = SystemColors.GradientActiveCaption;
            btnCurar.Location = new Point(272, 113);
            btnCurar.Name = "btnCurar";
            btnCurar.Size = new Size(100, 28);
            btnCurar.TabIndex = 11;
            btnCurar.Text = "Curar";
            btnCurar.UseVisualStyleBackColor = false;
            btnCurar.Click += btnCurar_Click;
            // 
            // pbVidaJugador
            // 
            pbVidaJugador.Location = new Point(20, 409);
            pbVidaJugador.Name = "pbVidaJugador";
            pbVidaJugador.Size = new Size(250, 22);
            pbVidaJugador.TabIndex = 5;
            // 
            // pbVidaEnemigo
            // 
            pbVidaEnemigo.Location = new Point(529, 410);
            pbVidaEnemigo.Name = "pbVidaEnemigo";
            pbVidaEnemigo.Size = new Size(250, 22);
            pbVidaEnemigo.TabIndex = 8;
            // 
            // lblJugador
            // 
            lblJugador.Location = new Point(43, 446);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(117, 20);
            lblJugador.TabIndex = 3;
            lblJugador.Text = "Jugador: -";
            lblJugador.Click += lblJugador_Click;
            // 
            // lblVidaJugador
            // 
            lblVidaJugador.Location = new Point(189, 384);
            lblVidaJugador.Name = "lblVidaJugador";
            lblVidaJugador.Size = new Size(81, 17);
            lblVidaJugador.TabIndex = 4;
            lblVidaJugador.Text = "Vida: 0";
            // 
            // lblEnemigo
            // 
            lblEnemigo.Location = new Point(639, 444);
            lblEnemigo.Name = "lblEnemigo";
            lblEnemigo.Size = new Size(116, 22);
            lblEnemigo.TabIndex = 6;
            lblEnemigo.Text = "Enemigo: -";
            lblEnemigo.Click += lblEnemigo_Click;
            // 
            // lblVidaEnemigo
            // 
            lblVidaEnemigo.Location = new Point(529, 384);
            lblVidaEnemigo.Name = "lblVidaEnemigo";
            lblVidaEnemigo.Size = new Size(68, 20);
            lblVidaEnemigo.TabIndex = 7;
            lblVidaEnemigo.Text = "Vida: 0";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(421, 18);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(364, 123);
            txtLog.TabIndex = 12;
            txtLog.TextChanged += txtLog_TextChanged;
            // 
            // pbImagenJugador
            // 
            pbImagenJugador.BorderStyle = BorderStyle.FixedSingle;
            pbImagenJugador.Location = new Point(32, 276);
            pbImagenJugador.Name = "pbImagenJugador";
            pbImagenJugador.Size = new Size(128, 128);
            pbImagenJugador.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagenJugador.TabIndex = 2;
            pbImagenJugador.TabStop = false;
            // 
            // pbImagenEnemigo
            // 
            pbImagenEnemigo.BorderStyle = BorderStyle.FixedSingle;
            pbImagenEnemigo.Location = new Point(639, 248);
            pbImagenEnemigo.Name = "pbImagenEnemigo";
            pbImagenEnemigo.Size = new Size(126, 156);
            pbImagenEnemigo.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagenEnemigo.TabIndex = 13;
            pbImagenEnemigo.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Bosque;
            pictureBox1.Location = new Point(12, 152);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(773, 289);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(791, 473);
            Controls.Add(cmbPersonaje);
            Controls.Add(btnCrear);
            Controls.Add(pbImagenJugador);
            Controls.Add(pbImagenEnemigo);
            Controls.Add(lblJugador);
            Controls.Add(lblVidaJugador);
            Controls.Add(pbVidaJugador);
            Controls.Add(lblEnemigo);
            Controls.Add(lblVidaEnemigo);
            Controls.Add(pbVidaEnemigo);
            Controls.Add(btnAtacar);
            Controls.Add(btnEspecial);
            Controls.Add(btnCurar);
            Controls.Add(txtLog);
            Controls.Add(pictureBox1);
            ForeColor = Color.Blue;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JuegoPOO - Laboratorio";
            Load += Form1_Load;
            ((ISupportInitialize)pbImagenJugador).EndInit();
            ((ISupportInitialize)pbImagenEnemigo).EndInit();
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private PictureBox pictureBox1;
    }
}
