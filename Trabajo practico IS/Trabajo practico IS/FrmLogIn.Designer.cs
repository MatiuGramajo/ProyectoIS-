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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtBoxUsuario
            // 
            this.TxtBoxUsuario.Location = new System.Drawing.Point(110, 73);
            this.TxtBoxUsuario.Name = "TxtBoxUsuario";
            this.TxtBoxUsuario.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxUsuario.TabIndex = 0;
            // 
            // TxtBoxPassword
            // 
            this.TxtBoxPassword.Location = new System.Drawing.Point(110, 143);
            this.TxtBoxPassword.Name = "TxtBoxPassword";
            this.TxtBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxPassword.TabIndex = 1;
            // 
            // BTN_IniciarSesion
            // 
            this.BTN_IniciarSesion.Location = new System.Drawing.Point(115, 199);
            this.BTN_IniciarSesion.Name = "BTN_IniciarSesion";
            this.BTN_IniciarSesion.Size = new System.Drawing.Size(90, 23);
            this.BTN_IniciarSesion.TabIndex = 2;
            this.BTN_IniciarSesion.Text = "Iniciar Sesion";
            this.BTN_IniciarSesion.UseVisualStyleBackColor = true;
            this.BTN_IniciarSesion.Click += new System.EventHandler(this.BTN_IniciarSesion_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // FrmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(321, 274);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_IniciarSesion);
            this.Controls.Add(this.TxtBoxPassword);
            this.Controls.Add(this.TxtBoxUsuario);
            this.Name = "FrmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBoxUsuario;
        private System.Windows.Forms.TextBox TxtBoxPassword;
        private System.Windows.Forms.Button BTN_IniciarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}