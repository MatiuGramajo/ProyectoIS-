namespace Trabajo_practico_IS
{
    partial class FrmLogIn
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
            this.TxtBoxUsuario = new System.Windows.Forms.TextBox();
            this.TxtBoxPassword = new System.Windows.Forms.TextBox();
            this.BTN_IniciarSesion = new System.Windows.Forms.Button();
            this.LBLusuario = new System.Windows.Forms.Label();
            this.LBLpassword = new System.Windows.Forms.Label();
            this.CBXIdiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtBoxUsuario
            // 
            this.TxtBoxUsuario.Location = new System.Drawing.Point(59, 73);
            this.TxtBoxUsuario.Name = "TxtBoxUsuario";
            this.TxtBoxUsuario.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxUsuario.TabIndex = 0;
            // 
            // TxtBoxPassword
            // 
            this.TxtBoxPassword.Location = new System.Drawing.Point(59, 143);
            this.TxtBoxPassword.Name = "TxtBoxPassword";
            this.TxtBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxPassword.TabIndex = 1;
            // 
            // BTN_IniciarSesion
            // 
            this.BTN_IniciarSesion.Location = new System.Drawing.Point(64, 199);
            this.BTN_IniciarSesion.Name = "BTN_IniciarSesion";
            this.BTN_IniciarSesion.Size = new System.Drawing.Size(90, 23);
            this.BTN_IniciarSesion.TabIndex = 2;
            this.BTN_IniciarSesion.Text = "Iniciar Sesion";
            this.BTN_IniciarSesion.UseVisualStyleBackColor = true;
            this.BTN_IniciarSesion.Click += new System.EventHandler(this.BTN_IniciarSesion_Click_1);
            // 
            // LBLusuario
            // 
            this.LBLusuario.AutoSize = true;
            this.LBLusuario.Location = new System.Drawing.Point(88, 48);
            this.LBLusuario.Name = "LBLusuario";
            this.LBLusuario.Size = new System.Drawing.Size(43, 13);
            this.LBLusuario.TabIndex = 4;
            this.LBLusuario.Text = "Usuario";
            // 
            // LBLpassword
            // 
            this.LBLpassword.AutoSize = true;
            this.LBLpassword.Location = new System.Drawing.Point(83, 118);
            this.LBLpassword.Name = "LBLpassword";
            this.LBLpassword.Size = new System.Drawing.Size(61, 13);
            this.LBLpassword.TabIndex = 5;
            this.LBLpassword.Text = "Contraseña";
            // 
            // CBXIdiomas
            // 
            this.CBXIdiomas.FormattingEnabled = true;
            this.CBXIdiomas.Location = new System.Drawing.Point(244, 12);
            this.CBXIdiomas.Name = "CBXIdiomas";
            this.CBXIdiomas.Size = new System.Drawing.Size(121, 21);
            this.CBXIdiomas.TabIndex = 6;
            this.CBXIdiomas.SelectedIndexChanged += new System.EventHandler(this.CBXIdiomas_SelectedIndexChanged);
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Location = new System.Drawing.Point(183, 16);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(38, 13);
            this.LBLidiomas.TabIndex = 7;
            this.LBLidiomas.Text = "Idioma";
            // 
            // FrmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(388, 274);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXIdiomas);
            this.Controls.Add(this.LBLpassword);
            this.Controls.Add(this.LBLusuario);
            this.Controls.Add(this.BTN_IniciarSesion);
            this.Controls.Add(this.TxtBoxPassword);
            this.Controls.Add(this.TxtBoxUsuario);
            this.Name = "FrmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogIn_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBoxUsuario;
        private System.Windows.Forms.TextBox TxtBoxPassword;
        private System.Windows.Forms.Button BTN_IniciarSesion;
        private System.Windows.Forms.Label LBLusuario;
        private System.Windows.Forms.Label LBLpassword;
        private System.Windows.Forms.ComboBox CBXIdiomas;
        private System.Windows.Forms.Label LBLidiomas;
    }
}