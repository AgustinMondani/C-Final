namespace FormTemporizador
{
    partial class Form1
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
            btnStop = new Button();
            btnReset = new Button();
            btnStart = new Button();
            lblTime = new Label();
            SuspendLayout();
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Lucida Sans Typewriter", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnStop.Location = new Point(562, 178);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(191, 73);
            btnStop.TabIndex = 0;
            btnStop.Text = "DETENER";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click_1;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Lucida Sans Typewriter", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.Location = new Point(36, 178);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(191, 73);
            btnReset.TabIndex = 1;
            btnReset.Text = "REINICIAR";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click_1;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.ActiveCaption;
            btnStart.Font = new Font("Lucida Sans Typewriter", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.Location = new Point(307, 178);
            btnStart.Margin = new Padding(0);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(191, 73);
            btnStart.TabIndex = 2;
            btnStart.Text = "INICIAR";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click_1;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.BackColor = SystemColors.ControlLight;
            lblTime.Font = new Font("Lucida Sans Typewriter", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblTime.ForeColor = Color.Gold;
            lblTime.Location = new Point(348, 51);
            lblTime.MaximumSize = new Size(500, 200);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(112, 37);
            lblTime.TabIndex = 5;
            lblTime.Text = "Timer";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 263);
            Controls.Add(lblTime);
            Controls.Add(btnStart);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStop;
        private Button btnReset;
        private Button btnStart;
        private Label lblTime;
    }
}