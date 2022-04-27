
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
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lbPalabra = new System.Windows.Forms.Label();
            this.btComenzar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Location = new System.Drawing.Point(399, 31);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(90, 20);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "El Ahorcado";
            // 
            // lbPalabra
            // 
            this.lbPalabra.AutoSize = true;
            this.lbPalabra.Location = new System.Drawing.Point(399, 122);
            this.lbPalabra.Name = "lbPalabra";
            this.lbPalabra.Size = new System.Drawing.Size(50, 20);
            this.lbPalabra.TabIndex = 1;
            this.lbPalabra.Text = "label1";
            // 
            // btComenzar
            // 
            this.btComenzar.Location = new System.Drawing.Point(504, 341);
            this.btComenzar.Name = "btComenzar";
            this.btComenzar.Size = new System.Drawing.Size(94, 29);
            this.btComenzar.TabIndex = 2;
            this.btComenzar.Text = "Comenzar";
            this.btComenzar.UseVisualStyleBackColor = true;
            this.btComenzar.Click += new System.EventHandler(this.btComenzar_Click);
            // 
            // Ahorcado
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

