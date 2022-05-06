
namespace Ahorcado
{
    partial class Ahorcado
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ahorcado));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbPalabra = new System.Windows.Forms.Label();
            this.btComenzar = new System.Windows.Forms.Button();
            this.btCrearBD = new System.Windows.Forms.Button();
            this.pbBarra1 = new System.Windows.Forms.ProgressBar();
            this.lbCaracteresRestantes = new System.Windows.Forms.Label();
            this.btComprobarLetra = new System.Windows.Forms.Button();
            this.lbInformacion = new System.Windows.Forms.Label();
            this.panelJuegoActivo = new System.Windows.Forms.Panel();
            this.lbLetrasUtilizadas = new System.Windows.Forms.Label();
            this.tbLetraJugador = new System.Windows.Forms.MaskedTextBox();
            this.panelJuegoActivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lbTitulo.Cursor = System.Windows.Forms.Cursors.No;
            this.lbTitulo.Font = new System.Drawing.Font("Bernard MT Condensed", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbTitulo.Location = new System.Drawing.Point(33, 27);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(379, 55);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "Juego del Ahorcado";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPalabra
            // 
            this.lbPalabra.AutoSize = true;
            this.lbPalabra.BackColor = System.Drawing.Color.Transparent;
            this.lbPalabra.Font = new System.Drawing.Font("Bernard MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbPalabra.ForeColor = System.Drawing.Color.Yellow;
            this.lbPalabra.Location = new System.Drawing.Point(100, 138);
            this.lbPalabra.Name = "lbPalabra";
            this.lbPalabra.Size = new System.Drawing.Size(0, 36);
            this.lbPalabra.TabIndex = 1;
            this.lbPalabra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbPalabra.UseWaitCursor = true;
            this.lbPalabra.Click += new System.EventHandler(this.lbPalabra_Click);
            // 
            // btComenzar
            // 
            this.btComenzar.Font = new System.Drawing.Font("Bernard MT Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btComenzar.Location = new System.Drawing.Point(33, 377);
            this.btComenzar.Name = "btComenzar";
            this.btComenzar.Size = new System.Drawing.Size(182, 41);
            this.btComenzar.TabIndex = 2;
            this.btComenzar.Text = "Nueva palabra";
            this.btComenzar.UseVisualStyleBackColor = true;
            this.btComenzar.Click += new System.EventHandler(this.btComenzar_Click);
            // 
            // btCrearBD
            // 
            this.btCrearBD.Location = new System.Drawing.Point(642, 377);
            this.btCrearBD.Name = "btCrearBD";
            this.btCrearBD.Size = new System.Drawing.Size(131, 41);
            this.btCrearBD.TabIndex = 3;
            this.btCrearBD.Text = "Crear BD";
            this.btCrearBD.UseVisualStyleBackColor = true;
            this.btCrearBD.Click += new System.EventHandler(this.btCrearBD_Click);
            // 
            // pbBarra1
            // 
            this.pbBarra1.Location = new System.Drawing.Point(33, 424);
            this.pbBarra1.Name = "pbBarra1";
            this.pbBarra1.Size = new System.Drawing.Size(740, 10);
            this.pbBarra1.TabIndex = 4;
            this.pbBarra1.Visible = false;
            // 
            // lbCaracteresRestantes
            // 
            this.lbCaracteresRestantes.AutoSize = true;
            this.lbCaracteresRestantes.BackColor = System.Drawing.Color.Transparent;
            this.lbCaracteresRestantes.Cursor = System.Windows.Forms.Cursors.No;
            this.lbCaracteresRestantes.Font = new System.Drawing.Font("Bernard MT Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbCaracteresRestantes.ForeColor = System.Drawing.Color.White;
            this.lbCaracteresRestantes.Location = new System.Drawing.Point(100, 183);
            this.lbCaracteresRestantes.Name = "lbCaracteresRestantes";
            this.lbCaracteresRestantes.Size = new System.Drawing.Size(0, 20);
            this.lbCaracteresRestantes.TabIndex = 5;
            this.lbCaracteresRestantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btComprobarLetra
            // 
            this.btComprobarLetra.Font = new System.Drawing.Font("Bernard MT Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btComprobarLetra.Location = new System.Drawing.Point(68, 27);
            this.btComprobarLetra.Name = "btComprobarLetra";
            this.btComprobarLetra.Size = new System.Drawing.Size(128, 35);
            this.btComprobarLetra.TabIndex = 7;
            this.btComprobarLetra.Text = "Comprobar";
            this.btComprobarLetra.UseVisualStyleBackColor = true;
            this.btComprobarLetra.Click += new System.EventHandler(this.btComprobarLetra_Click);
            // 
            // lbInformacion
            // 
            this.lbInformacion.AutoSize = true;
            this.lbInformacion.BackColor = System.Drawing.Color.Transparent;
            this.lbInformacion.Cursor = System.Windows.Forms.Cursors.No;
            this.lbInformacion.Font = new System.Drawing.Font("Bernard MT Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbInformacion.ForeColor = System.Drawing.Color.White;
            this.lbInformacion.Location = new System.Drawing.Point(3, 75);
            this.lbInformacion.Name = "lbInformacion";
            this.lbInformacion.Size = new System.Drawing.Size(152, 20);
            this.lbInformacion.TabIndex = 8;
            this.lbInformacion.Text = "Número de caracteres";
            this.lbInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelJuegoActivo
            // 
            this.panelJuegoActivo.BackColor = System.Drawing.Color.Transparent;
            this.panelJuegoActivo.Controls.Add(this.lbLetrasUtilizadas);
            this.panelJuegoActivo.Controls.Add(this.tbLetraJugador);
            this.panelJuegoActivo.Controls.Add(this.lbInformacion);
            this.panelJuegoActivo.Controls.Add(this.btComprobarLetra);
            this.panelJuegoActivo.Location = new System.Drawing.Point(100, 244);
            this.panelJuegoActivo.Name = "panelJuegoActivo";
            this.panelJuegoActivo.Size = new System.Drawing.Size(673, 127);
            this.panelJuegoActivo.TabIndex = 9;
            this.panelJuegoActivo.Visible = false;
            // 
            // lbLetrasUtilizadas
            // 
            this.lbLetrasUtilizadas.AutoSize = true;
            this.lbLetrasUtilizadas.BackColor = System.Drawing.Color.Transparent;
            this.lbLetrasUtilizadas.Font = new System.Drawing.Font("Bernard MT Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLetrasUtilizadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbLetrasUtilizadas.Location = new System.Drawing.Point(3, 111);
            this.lbLetrasUtilizadas.Name = "lbLetrasUtilizadas";
            this.lbLetrasUtilizadas.Size = new System.Drawing.Size(47, 20);
            this.lbLetrasUtilizadas.TabIndex = 10;
            this.lbLetrasUtilizadas.Text = "label1";
            // 
            // tbLetraJugador
            // 
            this.tbLetraJugador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tbLetraJugador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLetraJugador.Font = new System.Drawing.Font("Bernard MT Condensed", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbLetraJugador.Location = new System.Drawing.Point(3, 3);
            this.tbLetraJugador.Mask = ">L";
            this.tbLetraJugador.Name = "tbLetraJugador";
            this.tbLetraJugador.Size = new System.Drawing.Size(60, 59);
            this.tbLetraJugador.TabIndex = 9;
            this.tbLetraJugador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ahorcado
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(805, 441);
            this.Controls.Add(this.panelJuegoActivo);
            this.Controls.Add(this.lbCaracteresRestantes);
            this.Controls.Add(this.pbBarra1);
            this.Controls.Add(this.btCrearBD);
            this.Controls.Add(this.btComenzar);
            this.Controls.Add(this.lbPalabra);
            this.Controls.Add(this.lbTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Ahorcado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Juego del Ahorcado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ahorcado_FormClosing);
            this.Load += new System.EventHandler(this.Ahorcado_Load);
            this.panelJuegoActivo.ResumeLayout(false);
            this.panelJuegoActivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbPalabra;
        private System.Windows.Forms.Button btComenzar;
        private System.Windows.Forms.Button btCrearBD;
        private System.Windows.Forms.ProgressBar pbBarra1;
        private System.Windows.Forms.Label lbCaracteresRestantes;
        private System.Windows.Forms.Button btComprobarLetra;
        private System.Windows.Forms.Label lbInformacion;
        private System.Windows.Forms.Panel panelJuegoActivo;
        private System.Windows.Forms.MaskedTextBox tbLetraJugador;
        private System.Windows.Forms.Label lbLetrasUtilizadas;
    }
}

