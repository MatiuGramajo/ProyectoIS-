namespace Trabajo_practico_IS
{
    partial class FrmCTRLUsuario
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
            this.TXT_CtrlUsuUsuario = new System.Windows.Forms.TextBox();
            this.TXT_CtrlUsuContraseña = new System.Windows.Forms.TextBox();
            this.TXT_CtrlUsuDNI = new System.Windows.Forms.TextBox();
            this.TXT_CtrlUsuEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BTNCtrlUsuAlta = new System.Windows.Forms.Button();
            this.BTNCtrlUsuBaja = new System.Windows.Forms.Button();
            this.BTNCtrlUsuModificar = new System.Windows.Forms.Button();
            this.BTNCtrlUsuVolverMenu = new System.Windows.Forms.Button();
            this.DGV_CtrlUsuUsuarios = new System.Windows.Forms.DataGridView();
            this.CBX_CtrlUsuRol = new System.Windows.Forms.ComboBox();
            this.BTNCtrlUsuDesbloquear = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CtrlUsuUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // TXT_CtrlUsuUsuario
            // 
            this.TXT_CtrlUsuUsuario.Location = new System.Drawing.Point(92, 242);
            this.TXT_CtrlUsuUsuario.Name = "TXT_CtrlUsuUsuario";
            this.TXT_CtrlUsuUsuario.Size = new System.Drawing.Size(165, 20);
            this.TXT_CtrlUsuUsuario.TabIndex = 0;
            // 
            // TXT_CtrlUsuContraseña
            // 
            this.TXT_CtrlUsuContraseña.Location = new System.Drawing.Point(92, 284);
            this.TXT_CtrlUsuContraseña.Name = "TXT_CtrlUsuContraseña";
            this.TXT_CtrlUsuContraseña.Size = new System.Drawing.Size(165, 20);
            this.TXT_CtrlUsuContraseña.TabIndex = 1;
            // 
            // TXT_CtrlUsuDNI
            // 
            this.TXT_CtrlUsuDNI.Location = new System.Drawing.Point(92, 326);
            this.TXT_CtrlUsuDNI.Name = "TXT_CtrlUsuDNI";
            this.TXT_CtrlUsuDNI.Size = new System.Drawing.Size(165, 20);
            this.TXT_CtrlUsuDNI.TabIndex = 2;
            // 
            // TXT_CtrlUsuEmail
            // 
            this.TXT_CtrlUsuEmail.Location = new System.Drawing.Point(92, 368);
            this.TXT_CtrlUsuEmail.Name = "TXT_CtrlUsuEmail";
            this.TXT_CtrlUsuEmail.Size = new System.Drawing.Size(165, 20);
            this.TXT_CtrlUsuEmail.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DNI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rol";
            // 
            // BTNCtrlUsuAlta
            // 
            this.BTNCtrlUsuAlta.Location = new System.Drawing.Point(468, 242);
            this.BTNCtrlUsuAlta.Name = "BTNCtrlUsuAlta";
            this.BTNCtrlUsuAlta.Size = new System.Drawing.Size(104, 30);
            this.BTNCtrlUsuAlta.TabIndex = 10;
            this.BTNCtrlUsuAlta.Text = "Alta";
            this.BTNCtrlUsuAlta.UseVisualStyleBackColor = true;
            this.BTNCtrlUsuAlta.Click += new System.EventHandler(this.BTNCtrlUsuAlta_Click);
            // 
            // BTNCtrlUsuBaja
            // 
            this.BTNCtrlUsuBaja.Location = new System.Drawing.Point(594, 242);
            this.BTNCtrlUsuBaja.Name = "BTNCtrlUsuBaja";
            this.BTNCtrlUsuBaja.Size = new System.Drawing.Size(104, 30);
            this.BTNCtrlUsuBaja.TabIndex = 11;
            this.BTNCtrlUsuBaja.Text = "Baja";
            this.BTNCtrlUsuBaja.UseVisualStyleBackColor = true;
            this.BTNCtrlUsuBaja.Click += new System.EventHandler(this.BTNCtrlUsuBaja_Click);
            // 
            // BTNCtrlUsuModificar
            // 
            this.BTNCtrlUsuModificar.Location = new System.Drawing.Point(717, 242);
            this.BTNCtrlUsuModificar.Name = "BTNCtrlUsuModificar";
            this.BTNCtrlUsuModificar.Size = new System.Drawing.Size(104, 30);
            this.BTNCtrlUsuModificar.TabIndex = 12;
            this.BTNCtrlUsuModificar.Text = "Modificar";
            this.BTNCtrlUsuModificar.UseVisualStyleBackColor = true;
            this.BTNCtrlUsuModificar.Click += new System.EventHandler(this.BTNCtrlUsuModificar_Click);
            // 
            // BTNCtrlUsuVolverMenu
            // 
            this.BTNCtrlUsuVolverMenu.Location = new System.Drawing.Point(716, 464);
            this.BTNCtrlUsuVolverMenu.Name = "BTNCtrlUsuVolverMenu";
            this.BTNCtrlUsuVolverMenu.Size = new System.Drawing.Size(105, 31);
            this.BTNCtrlUsuVolverMenu.TabIndex = 13;
            this.BTNCtrlUsuVolverMenu.Text = "Volver al Menu";
            this.BTNCtrlUsuVolverMenu.UseVisualStyleBackColor = true;
            this.BTNCtrlUsuVolverMenu.Click += new System.EventHandler(this.BTNCtrlUsuVolverMenu_Click);
            // 
            // DGV_CtrlUsuUsuarios
            // 
            this.DGV_CtrlUsuUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_CtrlUsuUsuarios.Location = new System.Drawing.Point(34, 21);
            this.DGV_CtrlUsuUsuarios.Name = "DGV_CtrlUsuUsuarios";
            this.DGV_CtrlUsuUsuarios.Size = new System.Drawing.Size(787, 200);
            this.DGV_CtrlUsuUsuarios.TabIndex = 14;
            this.DGV_CtrlUsuUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CtrlUsuUsuarios_CellClick);
            // 
            // CBX_CtrlUsuRol
            // 
            this.CBX_CtrlUsuRol.FormattingEnabled = true;
            this.CBX_CtrlUsuRol.Items.AddRange(new object[] {
            "Administrador",
            "Basico"});
            this.CBX_CtrlUsuRol.Location = new System.Drawing.Point(92, 410);
            this.CBX_CtrlUsuRol.Name = "CBX_CtrlUsuRol";
            this.CBX_CtrlUsuRol.Size = new System.Drawing.Size(165, 21);
            this.CBX_CtrlUsuRol.TabIndex = 15;
            // 
            // BTNCtrlUsuDesbloquear
            // 
            this.BTNCtrlUsuDesbloquear.Location = new System.Drawing.Point(468, 314);
            this.BTNCtrlUsuDesbloquear.Name = "BTNCtrlUsuDesbloquear";
            this.BTNCtrlUsuDesbloquear.Size = new System.Drawing.Size(104, 30);
            this.BTNCtrlUsuDesbloquear.TabIndex = 17;
            this.BTNCtrlUsuDesbloquear.Text = "Desbloquear";
            this.BTNCtrlUsuDesbloquear.UseVisualStyleBackColor = true;
            this.BTNCtrlUsuDesbloquear.Click += new System.EventHandler(this.BTNCtrlUsuDesbloquear_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(305, 245);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Mostrar Bloqueados";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FrmCTRLUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(876, 517);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.BTNCtrlUsuDesbloquear);
            this.Controls.Add(this.CBX_CtrlUsuRol);
            this.Controls.Add(this.DGV_CtrlUsuUsuarios);
            this.Controls.Add(this.BTNCtrlUsuVolverMenu);
            this.Controls.Add(this.BTNCtrlUsuModificar);
            this.Controls.Add(this.BTNCtrlUsuBaja);
            this.Controls.Add(this.BTNCtrlUsuAlta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXT_CtrlUsuEmail);
            this.Controls.Add(this.TXT_CtrlUsuDNI);
            this.Controls.Add(this.TXT_CtrlUsuContraseña);
            this.Controls.Add(this.TXT_CtrlUsuUsuario);
            this.Name = "FrmCTRLUsuario";
            this.Text = "FrmCTRLUsuario";
            this.Load += new System.EventHandler(this.FrmCTRLUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CtrlUsuUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXT_CtrlUsuUsuario;
        private System.Windows.Forms.TextBox TXT_CtrlUsuContraseña;
        private System.Windows.Forms.TextBox TXT_CtrlUsuDNI;
        private System.Windows.Forms.TextBox TXT_CtrlUsuEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BTNCtrlUsuAlta;
        private System.Windows.Forms.Button BTNCtrlUsuBaja;
        private System.Windows.Forms.Button BTNCtrlUsuModificar;
        private System.Windows.Forms.Button BTNCtrlUsuVolverMenu;
        private System.Windows.Forms.DataGridView DGV_CtrlUsuUsuarios;
        private System.Windows.Forms.ComboBox CBX_CtrlUsuRol;
        private System.Windows.Forms.Button BTNCtrlUsuDesbloquear;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}