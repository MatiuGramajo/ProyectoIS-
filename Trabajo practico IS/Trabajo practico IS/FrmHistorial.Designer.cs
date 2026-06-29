namespace Trabajo_practico_IS
{
    partial class FrmHistorial
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
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.CBXIdiomas = new System.Windows.Forms.ComboBox();
            this.BTNvolveralmenu = new System.Windows.Forms.Button();
            this.BTNrestaurar = new System.Windows.Forms.Button();
            this.LBLusuario = new System.Windows.Forms.Label();
            this.CBXUsuarios = new System.Windows.Forms.ComboBox();
            this.LBLhistorial = new System.Windows.Forms.Label();
            this.DGVHistorial = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Location = new System.Drawing.Point(727, 22);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(43, 13);
            this.LBLidiomas.TabIndex = 15;
            this.LBLidiomas.Text = "Idiomas";
            // 
            // CBXIdiomas
            // 
            this.CBXIdiomas.FormattingEnabled = true;
            this.CBXIdiomas.Location = new System.Drawing.Point(788, 14);
            this.CBXIdiomas.Name = "CBXIdiomas";
            this.CBXIdiomas.Size = new System.Drawing.Size(121, 21);
            this.CBXIdiomas.TabIndex = 14;
            this.CBXIdiomas.SelectedIndexChanged += new System.EventHandler(this.CBXIdiomas_SelectedIndexChanged);
            // 
            // BTNvolveralmenu
            // 
            this.BTNvolveralmenu.Location = new System.Drawing.Point(788, 410);
            this.BTNvolveralmenu.Name = "BTNvolveralmenu";
            this.BTNvolveralmenu.Size = new System.Drawing.Size(124, 27);
            this.BTNvolveralmenu.TabIndex = 13;
            this.BTNvolveralmenu.Text = "Volver al menu ";
            this.BTNvolveralmenu.UseVisualStyleBackColor = true;
            this.BTNvolveralmenu.Click += new System.EventHandler(this.BTNvolveralmenu_Click);
            // 
            // BTNrestaurar
            // 
            this.BTNrestaurar.Location = new System.Drawing.Point(36, 342);
            this.BTNrestaurar.Name = "BTNrestaurar";
            this.BTNrestaurar.Size = new System.Drawing.Size(124, 27);
            this.BTNrestaurar.TabIndex = 12;
            this.BTNrestaurar.Text = "Restaurar";
            this.BTNrestaurar.UseVisualStyleBackColor = true;
            this.BTNrestaurar.Click += new System.EventHandler(this.BTNrestaurar_Click);
            // 
            // LBLusuario
            // 
            this.LBLusuario.AutoSize = true;
            this.LBLusuario.Location = new System.Drawing.Point(33, 257);
            this.LBLusuario.Name = "LBLusuario";
            this.LBLusuario.Size = new System.Drawing.Size(43, 13);
            this.LBLusuario.TabIndex = 11;
            this.LBLusuario.Text = "Usuario";
            // 
            // CBXUsuarios
            // 
            this.CBXUsuarios.FormattingEnabled = true;
            this.CBXUsuarios.Location = new System.Drawing.Point(36, 287);
            this.CBXUsuarios.Name = "CBXUsuarios";
            this.CBXUsuarios.Size = new System.Drawing.Size(121, 21);
            this.CBXUsuarios.TabIndex = 10;
            this.CBXUsuarios.SelectedIndexChanged += new System.EventHandler(this.CBXUsuarios_SelectedIndexChanged);
            // 
            // LBLhistorial
            // 
            this.LBLhistorial.AutoSize = true;
            this.LBLhistorial.Location = new System.Drawing.Point(33, 25);
            this.LBLhistorial.Name = "LBLhistorial";
            this.LBLhistorial.Size = new System.Drawing.Size(44, 13);
            this.LBLhistorial.TabIndex = 9;
            this.LBLhistorial.Text = "Historial";
            // 
            // DGVHistorial
            // 
            this.DGVHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHistorial.Location = new System.Drawing.Point(36, 59);
            this.DGVHistorial.Name = "DGVHistorial";
            this.DGVHistorial.Size = new System.Drawing.Size(873, 172);
            this.DGVHistorial.TabIndex = 8;
            // 
            // FrmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(944, 450);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXIdiomas);
            this.Controls.Add(this.BTNvolveralmenu);
            this.Controls.Add(this.BTNrestaurar);
            this.Controls.Add(this.LBLusuario);
            this.Controls.Add(this.CBXUsuarios);
            this.Controls.Add(this.LBLhistorial);
            this.Controls.Add(this.DGVHistorial);
            this.Name = "FrmHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmHistorial";
            this.Load += new System.EventHandler(this.FrmHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBLidiomas;
        private System.Windows.Forms.ComboBox CBXIdiomas;
        private System.Windows.Forms.Button BTNvolveralmenu;
        private System.Windows.Forms.Button BTNrestaurar;
        private System.Windows.Forms.Label LBLusuario;
        private System.Windows.Forms.ComboBox CBXUsuarios;
        private System.Windows.Forms.Label LBLhistorial;
        private System.Windows.Forms.DataGridView DGVHistorial;
    }
}