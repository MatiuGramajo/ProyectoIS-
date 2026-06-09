namespace Trabajo_practico_IS
{
    partial class FrmIdioma
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.BTNhabilitar = new System.Windows.Forms.Button();
            this.BTNdeshabilitar = new System.Windows.Forms.Button();
            this.BTNvolveralmenu = new System.Windows.Forms.Button();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.LBLtraducciones = new System.Windows.Forms.Label();
            this.LBLsufijo = new System.Windows.Forms.Label();
            this.TXTsufijo = new System.Windows.Forms.TextBox();
            this.LBLnombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(278, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(337, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(431, 311);
            this.dataGridView2.TabIndex = 1;
            // 
            // BTNhabilitar
            // 
            this.BTNhabilitar.Location = new System.Drawing.Point(67, 335);
            this.BTNhabilitar.Name = "BTNhabilitar";
            this.BTNhabilitar.Size = new System.Drawing.Size(155, 33);
            this.BTNhabilitar.TabIndex = 2;
            this.BTNhabilitar.Text = "Habilitar";
            this.BTNhabilitar.UseVisualStyleBackColor = true;
            this.BTNhabilitar.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTNdeshabilitar
            // 
            this.BTNdeshabilitar.Location = new System.Drawing.Point(67, 389);
            this.BTNdeshabilitar.Name = "BTNdeshabilitar";
            this.BTNdeshabilitar.Size = new System.Drawing.Size(155, 33);
            this.BTNdeshabilitar.TabIndex = 4;
            this.BTNdeshabilitar.Text = "Deshabilitar";
            this.BTNdeshabilitar.UseVisualStyleBackColor = true;
            // 
            // BTNvolveralmenu
            // 
            this.BTNvolveralmenu.Location = new System.Drawing.Point(613, 389);
            this.BTNvolveralmenu.Name = "BTNvolveralmenu";
            this.BTNvolveralmenu.Size = new System.Drawing.Size(155, 33);
            this.BTNvolveralmenu.TabIndex = 5;
            this.BTNvolveralmenu.Text = "Volver al menu principal";
            this.BTNvolveralmenu.UseVisualStyleBackColor = true;
            // 
            // TXTnombre
            // 
            this.TXTnombre.Location = new System.Drawing.Point(12, 215);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.Size = new System.Drawing.Size(195, 20);
            this.TXTnombre.TabIndex = 6;
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Location = new System.Drawing.Point(9, 9);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(43, 13);
            this.LBLidiomas.TabIndex = 7;
            this.LBLidiomas.Text = "Idiomas";
            // 
            // LBLtraducciones
            // 
            this.LBLtraducciones.AutoSize = true;
            this.LBLtraducciones.Location = new System.Drawing.Point(334, 9);
            this.LBLtraducciones.Name = "LBLtraducciones";
            this.LBLtraducciones.Size = new System.Drawing.Size(72, 13);
            this.LBLtraducciones.TabIndex = 8;
            this.LBLtraducciones.Text = "Traducciones";
            // 
            // LBLsufijo
            // 
            this.LBLsufijo.AutoSize = true;
            this.LBLsufijo.Location = new System.Drawing.Point(12, 258);
            this.LBLsufijo.Name = "LBLsufijo";
            this.LBLsufijo.Size = new System.Drawing.Size(33, 13);
            this.LBLsufijo.TabIndex = 9;
            this.LBLsufijo.Text = "Sufijo";
            // 
            // TXTsufijo
            // 
            this.TXTsufijo.Location = new System.Drawing.Point(12, 274);
            this.TXTsufijo.Name = "TXTsufijo";
            this.TXTsufijo.Size = new System.Drawing.Size(195, 20);
            this.TXTsufijo.TabIndex = 10;
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Location = new System.Drawing.Point(12, 199);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(44, 13);
            this.LBLnombre.TabIndex = 11;
            this.LBLnombre.Text = "Nombre";
            // 
            // FrmIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LBLnombre);
            this.Controls.Add(this.TXTsufijo);
            this.Controls.Add(this.LBLsufijo);
            this.Controls.Add(this.LBLtraducciones);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.TXTnombre);
            this.Controls.Add(this.BTNvolveralmenu);
            this.Controls.Add(this.BTNdeshabilitar);
            this.Controls.Add(this.BTNhabilitar);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmIdioma";
            this.Text = "FrmIdioma";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button BTNhabilitar;
        private System.Windows.Forms.Button BTNdeshabilitar;
        private System.Windows.Forms.Button BTNvolveralmenu;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.Label LBLidiomas;
        private System.Windows.Forms.Label LBLtraducciones;
        private System.Windows.Forms.Label LBLsufijo;
        private System.Windows.Forms.TextBox TXTsufijo;
        private System.Windows.Forms.Label LBLnombre;
    }
}