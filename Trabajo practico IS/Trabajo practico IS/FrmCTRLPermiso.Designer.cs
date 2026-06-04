namespace Trabajo_practico_IS
{
    partial class FrmCTRLPermiso
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BTNCtrlPermisoCrearRol = new System.Windows.Forms.Button();
            this.BTNCtrlPermisoCrearPermiso = new System.Windows.Forms.Button();
            this.TXTCtrlPermisoNombre = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.BTNCtrlPermisoAsignar = new System.Windows.Forms.Button();
            this.BTNCtrlPermisoDesasignar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(183, 251);
            this.treeView1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(274, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 251);
            this.listBox1.TabIndex = 1;
            // 
            // BTNCtrlPermisoCrearRol
            // 
            this.BTNCtrlPermisoCrearRol.Location = new System.Drawing.Point(17, 335);
            this.BTNCtrlPermisoCrearRol.Name = "BTNCtrlPermisoCrearRol";
            this.BTNCtrlPermisoCrearRol.Size = new System.Drawing.Size(87, 23);
            this.BTNCtrlPermisoCrearRol.TabIndex = 2;
            this.BTNCtrlPermisoCrearRol.Text = "Crear Rol";
            this.BTNCtrlPermisoCrearRol.UseVisualStyleBackColor = true;
            this.BTNCtrlPermisoCrearRol.Click += new System.EventHandler(this.BTNCtrlPermisoCrearRol_Click);
            // 
            // BTNCtrlPermisoCrearPermiso
            // 
            this.BTNCtrlPermisoCrearPermiso.Location = new System.Drawing.Point(17, 365);
            this.BTNCtrlPermisoCrearPermiso.Name = "BTNCtrlPermisoCrearPermiso";
            this.BTNCtrlPermisoCrearPermiso.Size = new System.Drawing.Size(87, 23);
            this.BTNCtrlPermisoCrearPermiso.TabIndex = 3;
            this.BTNCtrlPermisoCrearPermiso.Text = "Crear Permiso";
            this.BTNCtrlPermisoCrearPermiso.UseVisualStyleBackColor = true;
            this.BTNCtrlPermisoCrearPermiso.Click += new System.EventHandler(this.BTNCtrlPermisoCrearPermiso_Click);
            // 
            // TXTCtrlPermisoNombre
            // 
            this.TXTCtrlPermisoNombre.Location = new System.Drawing.Point(17, 297);
            this.TXTCtrlPermisoNombre.Name = "TXTCtrlPermisoNombre";
            this.TXTCtrlPermisoNombre.Size = new System.Drawing.Size(100, 20);
            this.TXTCtrlPermisoNombre.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(17, 278);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(44, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Nombre";
            // 
            // BTNCtrlPermisoAsignar
            // 
            this.BTNCtrlPermisoAsignar.Location = new System.Drawing.Point(274, 270);
            this.BTNCtrlPermisoAsignar.Name = "BTNCtrlPermisoAsignar";
            this.BTNCtrlPermisoAsignar.Size = new System.Drawing.Size(75, 23);
            this.BTNCtrlPermisoAsignar.TabIndex = 6;
            this.BTNCtrlPermisoAsignar.Text = "Asignar";
            this.BTNCtrlPermisoAsignar.UseVisualStyleBackColor = true;
            this.BTNCtrlPermisoAsignar.Click += new System.EventHandler(this.BTNCtrlPermisoAsignar_Click);
            // 
            // BTNCtrlPermisoDesasignar
            // 
            this.BTNCtrlPermisoDesasignar.Location = new System.Drawing.Point(274, 299);
            this.BTNCtrlPermisoDesasignar.Name = "BTNCtrlPermisoDesasignar";
            this.BTNCtrlPermisoDesasignar.Size = new System.Drawing.Size(75, 23);
            this.BTNCtrlPermisoDesasignar.TabIndex = 7;
            this.BTNCtrlPermisoDesasignar.Text = "Desasignar";
            this.BTNCtrlPermisoDesasignar.UseVisualStyleBackColor = true;
            this.BTNCtrlPermisoDesasignar.Click += new System.EventHandler(this.BTNCtrlPermisoDesasignar_Click);
            // 
            // FrmCTRLPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTNCtrlPermisoDesasignar);
            this.Controls.Add(this.BTNCtrlPermisoAsignar);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TXTCtrlPermisoNombre);
            this.Controls.Add(this.BTNCtrlPermisoCrearPermiso);
            this.Controls.Add(this.BTNCtrlPermisoCrearRol);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmCTRLPermiso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCTRLPermiso";
            this.Load += new System.EventHandler(this.FrmCTRLPermiso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BTNCtrlPermisoCrearRol;
        private System.Windows.Forms.Button BTNCtrlPermisoCrearPermiso;
        private System.Windows.Forms.TextBox TXTCtrlPermisoNombre;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button BTNCtrlPermisoAsignar;
        private System.Windows.Forms.Button BTNCtrlPermisoDesasignar;
    }
}