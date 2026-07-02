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
            this.GBfiltros = new System.Windows.Forms.GroupBox();
            this.CKXincluirfechas = new System.Windows.Forms.CheckBox();
            this.LBLfechafinal = new System.Windows.Forms.Label();
            this.LBLfechainicial = new System.Windows.Forms.Label();
            this.LBLcriticidad = new System.Windows.Forms.Label();
            this.LBLmodulo = new System.Windows.Forms.Label();
            this.LBLusuario = new System.Windows.Forms.Label();
            this.CBXBitacoraModulo = new System.Windows.Forms.ComboBox();
            this.CBXBitacoraCriticidad = new System.Windows.Forms.ComboBox();
            this.BTN_BitacoraVolverAlMenu = new System.Windows.Forms.Button();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.GB_Bitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BITACORA)).BeginInit();
            this.GBfiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_CargarBitacora
            // 
            this.BTN_CargarBitacora.Location = new System.Drawing.Point(306, 147);
            this.BTN_CargarBitacora.Name = "BTN_CargarBitacora";
            this.BTN_CargarBitacora.Size = new System.Drawing.Size(124, 27);
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
            this.GB_Bitacora.Size = new System.Drawing.Size(796, 260);
            this.GB_Bitacora.TabIndex = 4;
            this.GB_Bitacora.TabStop = false;
            this.GB_Bitacora.Text = "Bitacora";
            // 
            // DGV_BITACORA
            // 
            this.DGV_BITACORA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_BITACORA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_BITACORA.Location = new System.Drawing.Point(10, 24);
            this.DGV_BITACORA.Name = "DGV_BITACORA";
            this.DGV_BITACORA.Size = new System.Drawing.Size(775, 223);
            this.DGV_BITACORA.TabIndex = 1;
            // 
            // DTPBitacoraDesde
            // 
            this.DTPBitacoraDesde.Location = new System.Drawing.Point(232, 65);
            this.DTPBitacoraDesde.Name = "DTPBitacoraDesde";
            this.DTPBitacoraDesde.Size = new System.Drawing.Size(215, 20);
            this.DTPBitacoraDesde.TabIndex = 6;
            // 
            // DTPBitacoraHasta
            // 
            this.DTPBitacoraHasta.Location = new System.Drawing.Point(464, 65);
            this.DTPBitacoraHasta.Name = "DTPBitacoraHasta";
            this.DTPBitacoraHasta.Size = new System.Drawing.Size(215, 20);
            this.DTPBitacoraHasta.TabIndex = 7;
            // 
            // CBXBitacoraUsuario
            // 
            this.CBXBitacoraUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXBitacoraUsuario.FormattingEnabled = true;
            this.CBXBitacoraUsuario.Location = new System.Drawing.Point(87, 24);
            this.CBXBitacoraUsuario.Name = "CBXBitacoraUsuario";
            this.CBXBitacoraUsuario.Size = new System.Drawing.Size(121, 21);
            this.CBXBitacoraUsuario.TabIndex = 8;
            // 
            // GBfiltros
            // 
            this.GBfiltros.Controls.Add(this.CKXincluirfechas);
            this.GBfiltros.Controls.Add(this.LBLfechafinal);
            this.GBfiltros.Controls.Add(this.LBLfechainicial);
            this.GBfiltros.Controls.Add(this.LBLcriticidad);
            this.GBfiltros.Controls.Add(this.BTN_CargarBitacora);
            this.GBfiltros.Controls.Add(this.DTPBitacoraDesde);
            this.GBfiltros.Controls.Add(this.DTPBitacoraHasta);
            this.GBfiltros.Controls.Add(this.LBLmodulo);
            this.GBfiltros.Controls.Add(this.LBLusuario);
            this.GBfiltros.Controls.Add(this.CBXBitacoraModulo);
            this.GBfiltros.Controls.Add(this.CBXBitacoraCriticidad);
            this.GBfiltros.Controls.Add(this.CBXBitacoraUsuario);
            this.GBfiltros.Location = new System.Drawing.Point(12, 282);
            this.GBfiltros.Name = "GBfiltros";
            this.GBfiltros.Size = new System.Drawing.Size(699, 194);
            this.GBfiltros.TabIndex = 9;
            this.GBfiltros.TabStop = false;
            this.GBfiltros.Text = "Filtros";
            // 
            // CKXincluirfechas
            // 
            this.CKXincluirfechas.AutoSize = true;
            this.CKXincluirfechas.Location = new System.Drawing.Point(367, 23);
            this.CKXincluirfechas.Name = "CKXincluirfechas";
            this.CKXincluirfechas.Size = new System.Drawing.Size(92, 17);
            this.CKXincluirfechas.TabIndex = 16;
            this.CKXincluirfechas.Text = "Incluir Fechas";
            this.CKXincluirfechas.UseVisualStyleBackColor = true;
            this.CKXincluirfechas.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LBLfechafinal
            // 
            this.LBLfechafinal.AutoSize = true;
            this.LBLfechafinal.Location = new System.Drawing.Point(464, 49);
            this.LBLfechafinal.Name = "LBLfechafinal";
            this.LBLfechafinal.Size = new System.Drawing.Size(62, 13);
            this.LBLfechafinal.TabIndex = 15;
            this.LBLfechafinal.Text = "Fecha Final";
            // 
            // LBLfechainicial
            // 
            this.LBLfechainicial.AutoSize = true;
            this.LBLfechainicial.Location = new System.Drawing.Point(232, 49);
            this.LBLfechainicial.Name = "LBLfechainicial";
            this.LBLfechainicial.Size = new System.Drawing.Size(67, 13);
            this.LBLfechainicial.TabIndex = 14;
            this.LBLfechainicial.Text = "Fecha Inicial";
            // 
            // LBLcriticidad
            // 
            this.LBLcriticidad.AutoSize = true;
            this.LBLcriticidad.Location = new System.Drawing.Point(33, 112);
            this.LBLcriticidad.Name = "LBLcriticidad";
            this.LBLcriticidad.Size = new System.Drawing.Size(50, 13);
            this.LBLcriticidad.TabIndex = 13;
            this.LBLcriticidad.Text = "Criticidad";
            // 
            // LBLmodulo
            // 
            this.LBLmodulo.AutoSize = true;
            this.LBLmodulo.Location = new System.Drawing.Point(41, 70);
            this.LBLmodulo.Name = "LBLmodulo";
            this.LBLmodulo.Size = new System.Drawing.Size(42, 13);
            this.LBLmodulo.TabIndex = 12;
            this.LBLmodulo.Text = "Modulo";
            // 
            // LBLusuario
            // 
            this.LBLusuario.AutoSize = true;
            this.LBLusuario.Location = new System.Drawing.Point(40, 28);
            this.LBLusuario.Name = "LBLusuario";
            this.LBLusuario.Size = new System.Drawing.Size(43, 13);
            this.LBLusuario.TabIndex = 11;
            this.LBLusuario.Text = "Usuario";
            // 
            // CBXBitacoraModulo
            // 
            this.CBXBitacoraModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXBitacoraModulo.FormattingEnabled = true;
            this.CBXBitacoraModulo.Location = new System.Drawing.Point(87, 66);
            this.CBXBitacoraModulo.Name = "CBXBitacoraModulo";
            this.CBXBitacoraModulo.Size = new System.Drawing.Size(121, 21);
            this.CBXBitacoraModulo.TabIndex = 10;
            // 
            // CBXBitacoraCriticidad
            // 
            this.CBXBitacoraCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXBitacoraCriticidad.FormattingEnabled = true;
            this.CBXBitacoraCriticidad.Location = new System.Drawing.Point(87, 108);
            this.CBXBitacoraCriticidad.Name = "CBXBitacoraCriticidad";
            this.CBXBitacoraCriticidad.Size = new System.Drawing.Size(121, 21);
            this.CBXBitacoraCriticidad.TabIndex = 9;
            // 
            // BTN_BitacoraVolverAlMenu
            // 
            this.BTN_BitacoraVolverAlMenu.Location = new System.Drawing.Point(885, 449);
            this.BTN_BitacoraVolverAlMenu.Name = "BTN_BitacoraVolverAlMenu";
            this.BTN_BitacoraVolverAlMenu.Size = new System.Drawing.Size(124, 27);
            this.BTN_BitacoraVolverAlMenu.TabIndex = 10;
            this.BTN_BitacoraVolverAlMenu.Text = "Volver al menu ";
            this.BTN_BitacoraVolverAlMenu.UseVisualStyleBackColor = true;
            this.BTN_BitacoraVolverAlMenu.Click += new System.EventHandler(this.BTN_BitacoraVolverAlMenu_Click);
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(888, 28);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(121, 21);
            this.CBXidiomas.TabIndex = 11;
            this.CBXidiomas.SelectedIndexChanged += new System.EventHandler(this.CBXidiomas_SelectedIndexChanged);
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Location = new System.Drawing.Point(888, 12);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(55, 13);
            this.LBLidiomas.TabIndex = 12;
            this.LBLidiomas.Text = "Language";
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1018, 490);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.BTN_BitacoraVolverAlMenu);
            this.Controls.Add(this.GBfiltros);
            this.Controls.Add(this.GB_Bitacora);
            this.Name = "FrmBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBitacora";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBitacora_FormClosed);
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            this.GB_Bitacora.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BITACORA)).EndInit();
            this.GBfiltros.ResumeLayout(false);
            this.GBfiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_CargarBitacora;
        private System.Windows.Forms.GroupBox GB_Bitacora;
        private System.Windows.Forms.DataGridView DGV_BITACORA;
        private System.Windows.Forms.DateTimePicker DTPBitacoraDesde;
        private System.Windows.Forms.DateTimePicker DTPBitacoraHasta;
        private System.Windows.Forms.ComboBox CBXBitacoraUsuario;
        private System.Windows.Forms.GroupBox GBfiltros;
        private System.Windows.Forms.Label LBLcriticidad;
        private System.Windows.Forms.Label LBLmodulo;
        private System.Windows.Forms.Label LBLusuario;
        private System.Windows.Forms.ComboBox CBXBitacoraModulo;
        private System.Windows.Forms.ComboBox CBXBitacoraCriticidad;
        private System.Windows.Forms.Label LBLfechafinal;
        private System.Windows.Forms.Label LBLfechainicial;
        private System.Windows.Forms.CheckBox CKXincluirfechas;
        private System.Windows.Forms.Button BTN_BitacoraVolverAlMenu;
        private System.Windows.Forms.ComboBox CBXidiomas;
        private System.Windows.Forms.Label LBLidiomas;
    }
}