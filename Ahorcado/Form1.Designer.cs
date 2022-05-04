
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
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lbTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTitulo.Font = new System.Drawing.Font("Bernard MT Condensed", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTitulo.ForeColor = System.Drawing.Color.Blue;
            this.lbTitulo.Location = new System.Drawing.Point(57, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(242, 57);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "El Ahorcado";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPalabra
            // 
            this.lbPalabra.AutoSize = true;
            this.lbPalabra.Location = new System.Drawing.Point(399, 122);
            this.lbPalabra.Name = "lbPalabra";
            this.lbPalabra.Size = new System.Drawing.Size(120, 20);
            this.lbPalabra.TabIndex = 1;
            this.lbPalabra.Text = "Palabra a acertar";
            this.lbPalabra.Click += new System.EventHandler(this.lbPalabra_Click);
            // 
            // btComenzar
            // 
            this.btComenzar.Location = new System.Drawing.Point(170, 370);
            this.btComenzar.Name = "btComenzar";
            this.btComenzar.Size = new System.Drawing.Size(129, 41);
            this.btComenzar.TabIndex = 2;
            this.btComenzar.Text = "Comenzar";
            this.btComenzar.UseVisualStyleBackColor = true;
            this.btComenzar.Click += new System.EventHandler(this.btComenzar_Click);
            // 
            // btCrearBD
            // 
            this.btCrearBD.Location = new System.Drawing.Point(33, 370);
            this.btCrearBD.Name = "btCrearBD";
            this.btCrearBD.Size = new System.Drawing.Size(131, 41);
            this.btCrearBD.TabIndex = 3;
            this.btCrearBD.Text = "Crear BD";
            this.btCrearBD.UseVisualStyleBackColor = true;
            this.btCrearBD.Click += new System.EventHandler(this.btCrearBD_Click);
            // 
            // pbBarra1
            // 
            this.pbBarra1.Location = new System.Drawing.Point(33, 417);
            this.pbBarra1.Name = "pbBarra1";
            this.pbBarra1.Size = new System.Drawing.Size(740, 29);
            this.pbBarra1.TabIndex = 4;
            this.pbBarra1.Visible = false;
            // 
            // Ahorcado
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbBarra1);
            this.Controls.Add(this.btCrearBD);
            this.Controls.Add(this.btComenzar);
            this.Controls.Add(this.lbPalabra);
            this.Controls.Add(this.lbTitulo);
            this.MaximizeBox = false;
            this.Name = "Ahorcado";
            this.Text = "Ahorcado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbPalabra;
        private System.Windows.Forms.Button btComenzar;
        private System.Windows.Forms.Button btCrearBD;
        private System.Windows.Forms.ProgressBar pbBarra1;
    }
}

