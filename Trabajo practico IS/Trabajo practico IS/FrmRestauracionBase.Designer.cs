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
            this.LBMensajeError = new System.Windows.Forms.Label();
            this.OFDBackUp = new System.Windows.Forms.OpenFileDialog();
            this.SFDBackUp = new System.Windows.Forms.SaveFileDialog();
            this.BTNHacerBackUp = new System.Windows.Forms.Button();
            this.TXTRutaBackUp = new System.Windows.Forms.TextBox();
            this.BTNRestaurarBase = new System.Windows.Forms.Button();
            this.BTNRecalcularDigito = new System.Windows.Forms.Button();
            this.BTNRestauracionVolverMenu = new System.Windows.Forms.Button();
            this.BTNExaminarBackUp = new System.Windows.Forms.Button();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LBMensajeError
            // 
            this.LBMensajeError.AutoSize = true;
            this.LBMensajeError.Location = new System.Drawing.Point(12, 25);
            this.LBMensajeError.Name = "LBMensajeError";
            this.LBMensajeError.Size = new System.Drawing.Size(35, 13);
            this.LBMensajeError.TabIndex = 1;
            this.LBMensajeError.Text = "label1";
            // 
            // BTNHacerBackUp
            // 
            this.BTNHacerBackUp.Location = new System.Drawing.Point(12, 156);
            this.BTNHacerBackUp.Name = "BTNHacerBackUp";
            this.BTNHacerBackUp.Size = new System.Drawing.Size(124, 27);
            this.BTNHacerBackUp.TabIndex = 2;
            this.BTNHacerBackUp.Text = "Crear BackUp";
            this.BTNHacerBackUp.UseVisualStyleBackColor = true;
            this.BTNHacerBackUp.Click += new System.EventHandler(this.BTNHacerBackUp_Click);
            // 
            // TXTRutaBackUp
            // 
            this.TXTRutaBackUp.Location = new System.Drawing.Point(12, 192);
            this.TXTRutaBackUp.Name = "TXTRutaBackUp";
            this.TXTRutaBackUp.ReadOnly = true;
            this.TXTRutaBackUp.Size = new System.Drawing.Size(340, 20);
            this.TXTRutaBackUp.TabIndex = 3;
            // 
            // BTNRestaurarBase
            // 
            this.BTNRestaurarBase.Location = new System.Drawing.Point(488, 189);
            this.BTNRestaurarBase.Name = "BTNRestaurarBase";
            this.BTNRestaurarBase.Size = new System.Drawing.Size(124, 27);
            this.BTNRestaurarBase.TabIndex = 4;
            this.BTNRestaurarBase.Text = "Restaurar Base";
            this.BTNRestaurarBase.UseVisualStyleBackColor = true;
            this.BTNRestaurarBase.Click += new System.EventHandler(this.BTNRestaurarBase_Click);
            // 
            // BTNRecalcularDigito
            // 
            this.BTNRecalcularDigito.Location = new System.Drawing.Point(12, 221);
            this.BTNRecalcularDigito.Name = "BTNRecalcularDigito";
            this.BTNRecalcularDigito.Size = new System.Drawing.Size(147, 27);
            this.BTNRecalcularDigito.TabIndex = 5;
            this.BTNRecalcularDigito.Text = "Recalcular digito verificador";
            this.BTNRecalcularDigito.UseVisualStyleBackColor = true;
            this.BTNRecalcularDigito.Click += new System.EventHandler(this.BTNRecalcularDigito_Click);
            // 
            // BTNRestauracionVolverMenu
            // 
            this.BTNRestauracionVolverMenu.Location = new System.Drawing.Point(639, 283);
            this.BTNRestauracionVolverMenu.Name = "BTNRestauracionVolverMenu";
            this.BTNRestauracionVolverMenu.Size = new System.Drawing.Size(124, 27);
            this.BTNRestauracionVolverMenu.TabIndex = 6;
            this.BTNRestauracionVolverMenu.Text = "Volver al menu";
            this.BTNRestauracionVolverMenu.UseVisualStyleBackColor = true;
            this.BTNRestauracionVolverMenu.Click += new System.EventHandler(this.BTNRestauracionVolverMenu_Click);
            // 
            // BTNExaminarBackUp
            // 
            this.BTNExaminarBackUp.Location = new System.Drawing.Point(358, 189);
            this.BTNExaminarBackUp.Name = "BTNExaminarBackUp";
            this.BTNExaminarBackUp.Size = new System.Drawing.Size(124, 27);
            this.BTNExaminarBackUp.TabIndex = 7;
            this.BTNExaminarBackUp.Text = "Examinar";
            this.BTNExaminarBackUp.UseVisualStyleBackColor = true;
            this.BTNExaminarBackUp.Click += new System.EventHandler(this.BTNExaminarBackUp_Click);
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(642, 38);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(121, 21);
            this.CBXidiomas.TabIndex = 8;
            this.CBXidiomas.SelectedIndexChanged += new System.EventHandler(this.CBXidiomas_SelectedIndexChanged);
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Location = new System.Drawing.Point(642, 22);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(43, 13);
            this.LBLidiomas.TabIndex = 9;
            this.LBLidiomas.Text = "Idiomas";
            // 
            // FrmRestauracionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(772, 321);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.BTNExaminarBackUp);
            this.Controls.Add(this.BTNRestauracionVolverMenu);
            this.Controls.Add(this.BTNRecalcularDigito);
            this.Controls.Add(this.BTNRestaurarBase);
            this.Controls.Add(this.TXTRutaBackUp);
            this.Controls.Add(this.BTNHacerBackUp);
            this.Controls.Add(this.LBMensajeError);
            this.Name = "FrmRestauracionBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRestauracionBase";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRestauracionBase_FormClosed);
            this.Load += new System.EventHandler(this.FrmRestauracionBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LBMensajeError;
        private System.Windows.Forms.OpenFileDialog OFDBackUp;
        private System.Windows.Forms.SaveFileDialog SFDBackUp;
        private System.Windows.Forms.Button BTNHacerBackUp;
        private System.Windows.Forms.TextBox TXTRutaBackUp;
        private System.Windows.Forms.Button BTNRestaurarBase;
        private System.Windows.Forms.Button BTNRecalcularDigito;
        private System.Windows.Forms.Button BTNRestauracionVolverMenu;
        private System.Windows.Forms.Button BTNExaminarBackUp;
        private System.Windows.Forms.ComboBox CBXidiomas;
        private System.Windows.Forms.Label LBLidiomas;
    }
}