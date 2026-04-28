namespace Trabajo_practico_IS
{
    partial class FrmBitacora
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
            this.BTN_CargarBitacora = new System.Windows.Forms.Button();
            this.GB_Bitacora = new System.Windows.Forms.GroupBox();
            this.DGV_BITACORA = new System.Windows.Forms.DataGridView();
            this.DTPBitacoraDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPBitacoraHasta = new System.Windows.Forms.DateTimePicker();
            this.CBXBitacoraUsuario = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBXBitacoraModulo = new System.Windows.Forms.ComboBox();
            this.CBXBitacoraCriticidad = new System.Windows.Forms.ComboBox();
            this.BTN_BitacoraVolverAlMenu = new System.Windows.Forms.Button();
            this.GB_Bitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BITACORA)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_CargarBitacora
            // 
            this.BTN_CargarBitacora.Location = new System.Drawing.Point(315, 181);
            this.BTN_CargarBitacora.Name = "BTN_CargarBitacora";
            this.BTN_CargarBitacora.Size = new System.Drawing.Size(111, 35);
            this.BTN_CargarBitacora.TabIndex = 5;
            this.BTN_CargarBitacora.Text = "Filtrar";
            this.BTN_CargarBitacora.UseVisualStyleBackColor = true;
            this.BTN_CargarBitacora.Click += new System.EventHandler(this.BTN_CargarBitacora_Click);
            // 
            // GB_Bitacora
            // 
            this.GB_Bitacora.Controls.Add(this.DGV_BITACORA);
            this.GB_Bitacora.Location = new System.Drawing.Point(12, 12);
            this.GB_Bitacora.Name = "GB_Bitacora";
            this.GB_Bitacora.Size = new System.Drawing.Size(832, 282);
            this.GB_Bitacora.TabIndex = 4;
            this.GB_Bitacora.TabStop = false;
            this.GB_Bitacora.Text = "Bitacora";
            // 
            // DGV_BITACORA
            // 
            this.DGV_BITACORA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_BITACORA.Location = new System.Drawing.Point(21, 33);
            this.DGV_BITACORA.Name = "DGV_BITACORA";
            this.DGV_BITACORA.Size = new System.Drawing.Size(775, 223);
            this.DGV_BITACORA.TabIndex = 1;
            // 
            // DTPBitacoraDesde
            // 
            this.DTPBitacoraDesde.Location = new System.Drawing.Point(232, 82);
            this.DTPBitacoraDesde.Name = "DTPBitacoraDesde";
            this.DTPBitacoraDesde.Size = new System.Drawing.Size(215, 20);
            this.DTPBitacoraDesde.TabIndex = 6;
            // 
            // DTPBitacoraHasta
            // 
            this.DTPBitacoraHasta.Location = new System.Drawing.Point(464, 82);
            this.DTPBitacoraHasta.Name = "DTPBitacoraHasta";
            this.DTPBitacoraHasta.Size = new System.Drawing.Size(215, 20);
            this.DTPBitacoraHasta.TabIndex = 7;
            // 
            // CBXBitacoraUsuario
            // 
            this.CBXBitacoraUsuario.FormattingEnabled = true;
            this.CBXBitacoraUsuario.Location = new System.Drawing.Point(87, 41);
            this.CBXBitacoraUsuario.Name = "CBXBitacoraUsuario";
            this.CBXBitacoraUsuario.Size = new System.Drawing.Size(121, 21);
            this.CBXBitacoraUsuario.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BTN_CargarBitacora);
            this.groupBox1.Controls.Add(this.DTPBitacoraDesde);
            this.groupBox1.Controls.Add(this.DTPBitacoraHasta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CBXBitacoraModulo);
            this.groupBox1.Controls.Add(this.CBXBitacoraCriticidad);
            this.groupBox1.Controls.Add(this.CBXBitacoraUsuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 247);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(367, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Incluir Fechas";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(461, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Fecha Final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Fecha Inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Criticidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Modulo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Usuario";
            // 
            // CBXBitacoraModulo
            // 
            this.CBXBitacoraModulo.FormattingEnabled = true;
            this.CBXBitacoraModulo.Location = new System.Drawing.Point(87, 86);
            this.CBXBitacoraModulo.Name = "CBXBitacoraModulo";
            this.CBXBitacoraModulo.Size = new System.Drawing.Size(121, 21);
            this.CBXBitacoraModulo.TabIndex = 10;
            // 
            // CBXBitacoraCriticidad
            // 
            this.CBXBitacoraCriticidad.FormattingEnabled = true;
            this.CBXBitacoraCriticidad.Location = new System.Drawing.Point(87, 126);
            this.CBXBitacoraCriticidad.Name = "CBXBitacoraCriticidad";
            this.CBXBitacoraCriticidad.Size = new System.Drawing.Size(121, 21);
            this.CBXBitacoraCriticidad.TabIndex = 9;
            // 
            // BTN_BitacoraVolverAlMenu
            // 
            this.BTN_BitacoraVolverAlMenu.Location = new System.Drawing.Point(806, 506);
            this.BTN_BitacoraVolverAlMenu.Name = "BTN_BitacoraVolverAlMenu";
            this.BTN_BitacoraVolverAlMenu.Size = new System.Drawing.Size(129, 41);
            this.BTN_BitacoraVolverAlMenu.TabIndex = 10;
            this.BTN_BitacoraVolverAlMenu.Text = "Volver al Menu Principal";
            this.BTN_BitacoraVolverAlMenu.UseVisualStyleBackColor = true;
            this.BTN_BitacoraVolverAlMenu.Click += new System.EventHandler(this.BTN_BitacoraVolverAlMenu_Click);
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(947, 568);
            this.Controls.Add(this.BTN_BitacoraVolverAlMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GB_Bitacora);
            this.Name = "FrmBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBitacora";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            this.GB_Bitacora.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BITACORA)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_CargarBitacora;
        private System.Windows.Forms.GroupBox GB_Bitacora;
        private System.Windows.Forms.DataGridView DGV_BITACORA;
        private System.Windows.Forms.DateTimePicker DTPBitacoraDesde;
        private System.Windows.Forms.DateTimePicker DTPBitacoraHasta;
        private System.Windows.Forms.ComboBox CBXBitacoraUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBXBitacoraModulo;
        private System.Windows.Forms.ComboBox CBXBitacoraCriticidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button BTN_BitacoraVolverAlMenu;
    }
}