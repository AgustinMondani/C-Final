namespace _20220621_SP_ALUMNO.DIV
{
    partial class FrmView
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
            this.lblPalabraSecreta = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblPalabraIngresada = new System.Windows.Forms.Label();
            this.lblIngreso = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblAciertos = new System.Windows.Forms.Label();
            this.lblIntentos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPalabraSecreta
            // 
            this.lblPalabraSecreta.AutoSize = true;
            this.lblPalabraSecreta.Font = new System.Drawing.Font("Segoe UI", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPalabraSecreta.Location = new System.Drawing.Point(24, 12);
            this.lblPalabraSecreta.Name = "lblPalabraSecreta";
            this.lblPalabraSecreta.Size = new System.Drawing.Size(365, 62);
            this.lblPalabraSecreta.TabIndex = 0;
            this.lblPalabraSecreta.Text = "Palabra Secreta";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(901, 12);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(122, 54);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTiempo.Location = new System.Drawing.Point(901, 89);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(129, 21);
            this.lblTiempo.TabIndex = 2;
            this.lblTiempo.Text = "Tiempo Restante:";
            // 
            // lblPalabraIngresada
            // 
            this.lblPalabraIngresada.AutoSize = true;
            this.lblPalabraIngresada.Font = new System.Drawing.Font("Segoe UI", 23.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblPalabraIngresada.Location = new System.Drawing.Point(138, 102);
            this.lblPalabraIngresada.Name = "lblPalabraIngresada";
            this.lblPalabraIngresada.Size = new System.Drawing.Size(263, 42);
            this.lblPalabraIngresada.TabIndex = 3;
            this.lblPalabraIngresada.Text = "Palabra Ingresada";
            // 
            // lblIngreso
            // 
            this.lblIngreso.AutoSize = true;
            this.lblIngreso.Font = new System.Drawing.Font("Segoe UI", 23.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblIngreso.Location = new System.Drawing.Point(24, 102);
            this.lblIngreso.Name = "lblIngreso";
            this.lblIngreso.Size = new System.Drawing.Size(122, 42);
            this.lblIngreso.TabIndex = 4;
            this.lblIngreso.Text = "Ingreso:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(908, 298);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(122, 54);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblAciertos
            // 
            this.lblAciertos.AutoSize = true;
            this.lblAciertos.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAciertos.Location = new System.Drawing.Point(24, 327);
            this.lblAciertos.Name = "lblAciertos";
            this.lblAciertos.Size = new System.Drawing.Size(103, 28);
            this.lblAciertos.TabIndex = 6;
            this.lblAciertos.Text = "Aciertos: 0";
            // 
            // lblIntentos
            // 
            this.lblIntentos.AutoSize = true;
            this.lblIntentos.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIntentos.Location = new System.Drawing.Point(162, 327);
            this.lblIntentos.Name = "lblIntentos";
            this.lblIntentos.Size = new System.Drawing.Size(103, 28);
            this.lblIntentos.TabIndex = 7;
            this.lblIntentos.Text = "Intentos: 0";
            // 
            // FrmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.BackgroundImage = global::_20220621_SP_ALUMNO.DIV.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1079, 364);
            this.Controls.Add(this.lblIntentos);
            this.Controls.Add(this.lblAciertos);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblIngreso);
            this.Controls.Add(this.lblPalabraIngresada);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.lblPalabraSecreta);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "20220621 Alumno DIV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmView_FormClosing);
            this.Load += new System.EventHandler(this.FrmView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPalabraSecreta;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblPalabraIngresada;
        private System.Windows.Forms.Label lblIngreso;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblAciertos;
        private System.Windows.Forms.Label lblIntentos;
    }
}
