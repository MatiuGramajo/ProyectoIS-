namespace Trabajo_practico_IS
{
    partial class FrmRestauracionBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TXTRutaNuevoBackUp = new System.Windows.Forms.TextBox();
            this.LBMensajeError = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BTNHacerBackUp = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BTNRecalcularDigito = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TXTRutaNuevoBackUp
            // 
            this.TXTRutaNuevoBackUp.Location = new System.Drawing.Point(45, 63);
            this.TXTRutaNuevoBackUp.Name = "TXTRutaNuevoBackUp";
            this.TXTRutaNuevoBackUp.Size = new System.Drawing.Size(259, 20);
            this.TXTRutaNuevoBackUp.TabIndex = 0;
            // 
            // LBMensajeError
            // 
            this.LBMensajeError.AutoSize = true;
            this.LBMensajeError.Location = new System.Drawing.Point(42, 36);
            this.LBMensajeError.Name = "LBMensajeError";
            this.LBMensajeError.Size = new System.Drawing.Size(35, 13);
            this.LBMensajeError.TabIndex = 1;
            this.LBMensajeError.Text = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BTNHacerBackUp
            // 
            this.BTNHacerBackUp.Location = new System.Drawing.Point(327, 59);
            this.BTNHacerBackUp.Name = "BTNHacerBackUp";
            this.BTNHacerBackUp.Size = new System.Drawing.Size(94, 23);
            this.BTNHacerBackUp.TabIndex = 2;
            this.BTNHacerBackUp.Text = "Hacer BackUp";
            this.BTNHacerBackUp.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 196);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Restaurar Base";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BTNRecalcularDigito
            // 
            this.BTNRecalcularDigito.Location = new System.Drawing.Point(45, 315);
            this.BTNRecalcularDigito.Name = "BTNRecalcularDigito";
            this.BTNRecalcularDigito.Size = new System.Drawing.Size(147, 23);
            this.BTNRecalcularDigito.TabIndex = 5;
            this.BTNRecalcularDigito.Text = "Recalcular digito verificador";
            this.BTNRecalcularDigito.UseVisualStyleBackColor = true;
            this.BTNRecalcularDigito.Click += new System.EventHandler(this.BTNRecalcularDigito_Click);
            // 
            // FrmRestauracionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTNRecalcularDigito);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BTNHacerBackUp);
            this.Controls.Add(this.LBMensajeError);
            this.Controls.Add(this.TXTRutaNuevoBackUp);
            this.Name = "FrmRestauracionBase";
            this.Text = "FrmRestauracionBase";
            this.Load += new System.EventHandler(this.FrmRestauracionBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTRutaNuevoBackUp;
        private System.Windows.Forms.Label LBMensajeError;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button BTNHacerBackUp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BTNRecalcularDigito;
    }
}