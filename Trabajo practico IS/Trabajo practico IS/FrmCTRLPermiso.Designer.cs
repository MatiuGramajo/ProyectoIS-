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
            this.TV_RolesPermisos = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BTNCtrlPermisoCrearRol = new System.Windows.Forms.Button();
            this.TXTCtrlPermisoNombre = new System.Windows.Forms.TextBox();
            this.LBLnombre = new System.Windows.Forms.Label();
            this.BTNCtrlPermisoAsignar = new System.Windows.Forms.Button();
            this.BTNCtrlPermisoDesasignar = new System.Windows.Forms.Button();
            this.BG_ListRolesPermisos = new System.Windows.Forms.GroupBox();
            this.GB_TreeViewRoles = new System.Windows.Forms.GroupBox();
            this.GB_NuevoRol = new System.Windows.Forms.GroupBox();
            this.BTNCtrlPermisoModifRol = new System.Windows.Forms.Button();
            this.BTNCtrlPermisoBorrarRol = new System.Windows.Forms.Button();
            this.CBXidiomas = new System.Windows.Forms.ComboBox();
            this.LBLidiomas = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.BG_ListRolesPermisos.SuspendLayout();
            this.GB_TreeViewRoles.SuspendLayout();
            this.GB_NuevoRol.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TV_RolesPermisos
            // 
            this.TV_RolesPermisos.HideSelection = false;
            this.TV_RolesPermisos.Location = new System.Drawing.Point(21, 22);
            this.TV_RolesPermisos.Name = "TV_RolesPermisos";
            this.TV_RolesPermisos.Size = new System.Drawing.Size(183, 251);
            this.TV_RolesPermisos.TabIndex = 0;
            this.TV_RolesPermisos.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_RolesPermisos_NodeMouseClick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 251);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // BTNCtrlPermisoCrearRol
            // 
            this.BTNCtrlPermisoCrearRol.Location = new System.Drawing.Point(9, 65);
            this.BTNCtrlPermisoCrearRol.Name = "BTNCtrlPermisoCrearRol";
            this.BTNCtrlPermisoCrearRol.Size = new System.Drawing.Size(87, 23);
            this.BTNCtrlPermisoCrearRol.TabIndex = 2;
            this.BTNCtrlPermisoCrearRol.Text = "Crear";
            this.BTNCtrlPermisoCrearRol.UseVisualStyleBackColor = true;
            this.BTNCtrlPermisoCrearRol.Click += new System.EventHandler(this.BTNCtrlPermisoCrearRol_Click);
            // 
            // TXTCtrlPermisoNombre
            // 
            this.TXTCtrlPermisoNombre.Location = new System.Drawing.Point(9, 39);
            this.TXTCtrlPermisoNombre.Name = "TXTCtrlPermisoNombre";
            this.TXTCtrlPermisoNombre.Size = new System.Drawing.Size(169, 20);
            this.TXTCtrlPermisoNombre.TabIndex = 4;
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Location = new System.Drawing.Point(9, 19);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(44, 13);
            this.LBLnombre.TabIndex = 5;
            this.LBLnombre.Text = "Nombre";
            // 
            // BTNCtrlPermisoAsignar
            // 
            this.BTNCtrlPermisoAsignar.Location = new System.Drawing.Point(499, 128);
            this.BTNCtrlPermisoAsignar.Name = "BTNCtrlPermisoAsignar";
            this.BTNCtrlPermisoAsignar.Size = new System.Drawing.Size(75, 23);
            this.BTNCtrlPermisoAsignar.TabIndex = 6;
            this.BTNCtrlPermisoAsignar.Text = "Asignar";
            this.BTNCtrlPermisoAsignar.UseVisualStyleBackColor = true;
            this.BTNCtrlPermisoAsignar.Click += new System.EventHandler(this.BTNCtrlPermisoAsignar_Click);
            // 
            // BTNCtrlPermisoDesasignar
            // 
            this.BTNCtrlPermisoDesasignar.Location = new System.Drawing.Point(499, 157);
            this.BTNCtrlPermisoDesasignar.Name = "BTNCtrlPermisoDesasignar";
            this.BTNCtrlPermisoDesasignar.Size = new System.Drawing.Size(75, 23);
            this.BTNCtrlPermisoDesasignar.TabIndex = 7;
            this.BTNCtrlPermisoDesasignar.Text = "Desasignar";
            this.BTNCtrlPermisoDesasignar.UseVisualStyleBackColor = true;
            this.BTNCtrlPermisoDesasignar.Click += new System.EventHandler(this.BTNCtrlPermisoDesasignar_Click);
            // 
            // BG_ListRolesPermisos
            // 
            this.BG_ListRolesPermisos.Controls.Add(this.listBox1);
            this.BG_ListRolesPermisos.Location = new System.Drawing.Point(12, 12);
            this.BG_ListRolesPermisos.Name = "BG_ListRolesPermisos";
            this.BG_ListRolesPermisos.Size = new System.Drawing.Size(225, 288);
            this.BG_ListRolesPermisos.TabIndex = 8;
            this.BG_ListRolesPermisos.TabStop = false;
            this.BG_ListRolesPermisos.Text = "Todos los roles";
            // 
            // GB_TreeViewRoles
            // 
            this.GB_TreeViewRoles.Controls.Add(this.TV_RolesPermisos);
            this.GB_TreeViewRoles.Location = new System.Drawing.Point(584, 12);
            this.GB_TreeViewRoles.Name = "GB_TreeViewRoles";
            this.GB_TreeViewRoles.Size = new System.Drawing.Size(219, 288);
            this.GB_TreeViewRoles.TabIndex = 9;
            this.GB_TreeViewRoles.TabStop = false;
            this.GB_TreeViewRoles.Text = "Arbol de roles";
            // 
            // GB_NuevoRol
            // 
            this.GB_NuevoRol.Controls.Add(this.BTNCtrlPermisoModifRol);
            this.GB_NuevoRol.Controls.Add(this.TXTCtrlPermisoNombre);
            this.GB_NuevoRol.Controls.Add(this.BTNCtrlPermisoBorrarRol);
            this.GB_NuevoRol.Controls.Add(this.BTNCtrlPermisoCrearRol);
            this.GB_NuevoRol.Controls.Add(this.LBLnombre);
            this.GB_NuevoRol.Location = new System.Drawing.Point(832, 145);
            this.GB_NuevoRol.Name = "GB_NuevoRol";
            this.GB_NuevoRol.Size = new System.Drawing.Size(194, 155);
            this.GB_NuevoRol.TabIndex = 10;
            this.GB_NuevoRol.TabStop = false;
            this.GB_NuevoRol.Text = "Rol";
            // 
            // BTNCtrlPermisoModifRol
            // 
            this.BTNCtrlPermisoModifRol.Location = new System.Drawing.Point(9, 94);
            this.BTNCtrlPermisoModifRol.Name = "BTNCtrlPermisoModifRol";
            this.BTNCtrlPermisoModifRol.Size = new System.Drawing.Size(87, 23);
            this.BTNCtrlPermisoModifRol.TabIndex = 12;
            this.BTNCtrlPermisoModifRol.Text = "Modificar";
            this.BTNCtrlPermisoModifRol.UseVisualStyleBackColor = true;
            this.BTNCtrlPermisoModifRol.Click += new System.EventHandler(this.BTNCtrlPermisoModifRol_Click);
            // 
            // BTNCtrlPermisoBorrarRol
            // 
            this.BTNCtrlPermisoBorrarRol.Location = new System.Drawing.Point(9, 123);
            this.BTNCtrlPermisoBorrarRol.Name = "BTNCtrlPermisoBorrarRol";
            this.BTNCtrlPermisoBorrarRol.Size = new System.Drawing.Size(87, 23);
            this.BTNCtrlPermisoBorrarRol.TabIndex = 11;
            this.BTNCtrlPermisoBorrarRol.Text = "Borrar";
            this.BTNCtrlPermisoBorrarRol.UseVisualStyleBackColor = true;
            this.BTNCtrlPermisoBorrarRol.Click += new System.EventHandler(this.BTNCtrlPermisoBorrarRol_Click);
            // 
            // CBXidiomas
            // 
            this.CBXidiomas.FormattingEnabled = true;
            this.CBXidiomas.Location = new System.Drawing.Point(986, 12);
            this.CBXidiomas.Name = "CBXidiomas";
            this.CBXidiomas.Size = new System.Drawing.Size(121, 21);
            this.CBXidiomas.TabIndex = 11;
            this.CBXidiomas.SelectedIndexChanged += new System.EventHandler(this.CBXidiomas_SelectedIndexChanged);
            // 
            // LBLidiomas
            // 
            this.LBLidiomas.AutoSize = true;
            this.LBLidiomas.Location = new System.Drawing.Point(928, 20);
            this.LBLidiomas.Name = "LBLidiomas";
            this.LBLidiomas.Size = new System.Drawing.Size(43, 13);
            this.LBLidiomas.TabIndex = 12;
            this.LBLidiomas.Text = "Idiomas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Location = new System.Drawing.Point(262, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 288);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Todos los permisos";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(12, 22);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(199, 251);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // FrmCTRLPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1119, 315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LBLidiomas);
            this.Controls.Add(this.CBXidiomas);
            this.Controls.Add(this.GB_NuevoRol);
            this.Controls.Add(this.BG_ListRolesPermisos);
            this.Controls.Add(this.BTNCtrlPermisoDesasignar);
            this.Controls.Add(this.BTNCtrlPermisoAsignar);
            this.Controls.Add(this.GB_TreeViewRoles);
            this.Name = "FrmCTRLPermiso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCTRLPermiso";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCTRLPermiso_FormClosed);
            this.Load += new System.EventHandler(this.FrmCTRLPermiso_Load);
            this.BG_ListRolesPermisos.ResumeLayout(false);
            this.GB_TreeViewRoles.ResumeLayout(false);
            this.GB_NuevoRol.ResumeLayout(false);
            this.GB_NuevoRol.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TV_RolesPermisos;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BTNCtrlPermisoCrearRol;
        private System.Windows.Forms.TextBox TXTCtrlPermisoNombre;
        private System.Windows.Forms.Label LBLnombre;
        private System.Windows.Forms.Button BTNCtrlPermisoAsignar;
        private System.Windows.Forms.Button BTNCtrlPermisoDesasignar;
        private System.Windows.Forms.GroupBox BG_ListRolesPermisos;
        private System.Windows.Forms.GroupBox GB_TreeViewRoles;
        private System.Windows.Forms.GroupBox GB_NuevoRol;
        private System.Windows.Forms.Button BTNCtrlPermisoModifRol;
        private System.Windows.Forms.Button BTNCtrlPermisoBorrarRol;
        private System.Windows.Forms.ComboBox CBXidiomas;
        private System.Windows.Forms.Label LBLidiomas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}