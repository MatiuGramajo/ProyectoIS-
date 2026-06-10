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
            this.BTNhabilitar = new System.Windows.Forms.Button();
            this.BTNdeshabilitar = new System.Windows.Forms.Button();
            this.BTNvolveralmenu = new System.Windows.Forms.Button();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.LBLsufijo = new System.Windows.Forms.Label();
            this.TXTsufijo = new System.Windows.Forms.TextBox();
            this.LBLnombre = new System.Windows.Forms.Label();
            this.LBLidiomas2 = new System.Windows.Forms.Label();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(326, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // BTNhabilitar
            // 
            this.BTNhabilitar.Location = new System.Drawing.Point(109, 334);
            this.BTNhabilitar.Name = "BTNhabilitar";
            this.BTNhabilitar.Size = new System.Drawing.Size(155, 33);
            this.BTNhabilitar.TabIndex = 2;
            this.BTNhabilitar.Text = "Habilitar";
            this.BTNhabilitar.UseVisualStyleBackColor = true;
            this.BTNhabilitar.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTNdeshabilitar
            // 
            this.BTNdeshabilitar.Location = new System.Drawing.Point(109, 388);
            this.BTNdeshabilitar.Name = "BTNdeshabilitar";
            this.BTNdeshabilitar.Size = new System.Drawing.Size(155, 33);
            this.BTNdeshabilitar.TabIndex = 4;
            this.BTNdeshabilitar.Text = "Deshabilitar";
            this.BTNdeshabilitar.UseVisualStyleBackColor = true;
            // 
            // BTNvolveralmenu
            // 
            this.BTNvolveralmenu.Location = new System.Drawing.Point(423, 388);
            this.BTNvolveralmenu.Name = "BTNvolveralmenu";
            this.BTNvolveralmenu.Size = new System.Drawing.Size(155, 33);
            this.BTNvolveralmenu.TabIndex = 5;
            this.BTNvolveralmenu.Text = "Volver al menu principal";
            this.BTNvolveralmenu.UseVisualStyleBackColor = true;
            this.BTNvolveralmenu.Click += new System.EventHandler(this.BTNvolveralmenu_Click);
            // 
            // TXTnombre
            // 
            this.TXTnombre.Location = new System.Drawing.Point(54, 214);
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
            // LBLsufijo
            // 
            this.LBLsufijo.AutoSize = true;
            this.LBLsufijo.Location = new System.Drawing.Point(54, 257);
            this.LBLsufijo.Name = "LBLsufijo";
            this.LBLsufijo.Size = new System.Drawing.Size(33, 13);
            this.LBLsufijo.TabIndex = 9;
            this.LBLsufijo.Text = "Sufijo";
            // 
            // TXTsufijo
            // 
            this.TXTsufijo.Location = new System.Drawing.Point(54, 273);
            this.TXTsufijo.Name = "TXTsufijo";
            this.TXTsufijo.Size = new System.Drawing.Size(195, 20);
            this.TXTsufijo.TabIndex = 10;
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Location = new System.Drawing.Point(54, 198);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(44, 13);
            this.LBLnombre.TabIndex = 11;
            this.LBLnombre.Text = "Nombre";
            // 
            // LBLidiomas2
            // 
            this.LBLidiomas2.AutoSize = true;
            this.LBLidiomas2.Location = new System.Drawing.Point(408, 25);
            this.LBLidiomas2.Name = "LBLidiomas2";
            this.LBLidiomas2.Size = new System.Drawing.Size(43, 13);
            this.LBLidiomas2.TabIndex = 12;
            this.LBLidiomas2.Text = "Idiomas";
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(478, 17);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(121, 21);
            this.CBXidiomas.TabIndex = 13;
            this.CBXidiomas.SelectedIndexChanged += new System.EventHandler(this.CBXidiomas_SelectedIndexChanged);
            // 
            // FrmIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(611, 450);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.LBLidiomas2);
            this.Controls.Add(this.LBLnombre);
            this.Controls.Add(this.TXTsufijo);
            this.Controls.Add(this.LBLsufijo);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.TXTnombre);
            this.Controls.Add(this.BTNvolveralmenu);
            this.Controls.Add(this.BTNdeshabilitar);
            this.Controls.Add(this.BTNhabilitar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmIdioma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmIdioma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIdioma_FormClosing);
            this.Load += new System.EventHandler(this.FrmIdioma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTNhabilitar;
        private System.Windows.Forms.Button BTNdeshabilitar;
        private System.Windows.Forms.Button BTNvolveralmenu;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.Label LBLidiomas;
        private System.Windows.Forms.Label LBLsufijo;
        private System.Windows.Forms.TextBox TXTsufijo;
        private System.Windows.Forms.Label LBLnombre;
        private System.Windows.Forms.Label LBLidiomas2;
        private System.Windows.Forms.ComboBox CBXidiomas;
    }
}