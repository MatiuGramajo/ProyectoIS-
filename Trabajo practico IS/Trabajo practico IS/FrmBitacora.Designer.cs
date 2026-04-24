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
            this.GB_Bitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BITACORA)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_CargarBitacora
            // 
            this.BTN_CargarBitacora.Location = new System.Drawing.Point(33, 321);
            this.BTN_CargarBitacora.Name = "BTN_CargarBitacora";
            this.BTN_CargarBitacora.Size = new System.Drawing.Size(111, 35);
            this.BTN_CargarBitacora.TabIndex = 5;
            this.BTN_CargarBitacora.Text = "Cargar Bitacora";
            this.BTN_CargarBitacora.UseVisualStyleBackColor = true;
            this.BTN_CargarBitacora.Click += new System.EventHandler(this.BTN_CargarBitacora_Click);
            // 
            // GB_Bitacora
            // 
            this.GB_Bitacora.Controls.Add(this.DGV_BITACORA);
            this.GB_Bitacora.Location = new System.Drawing.Point(12, 21);
            this.GB_Bitacora.Name = "GB_Bitacora";
            this.GB_Bitacora.Size = new System.Drawing.Size(699, 282);
            this.GB_Bitacora.TabIndex = 4;
            this.GB_Bitacora.TabStop = false;
            this.GB_Bitacora.Text = "Bitacora";
            // 
            // DGV_BITACORA
            // 
            this.DGV_BITACORA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_BITACORA.Location = new System.Drawing.Point(21, 33);
            this.DGV_BITACORA.Name = "DGV_BITACORA";
            this.DGV_BITACORA.Size = new System.Drawing.Size(658, 223);
            this.DGV_BITACORA.TabIndex = 1;
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.BTN_CargarBitacora);
            this.Controls.Add(this.GB_Bitacora);
            this.Name = "FrmBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBitacora";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            this.GB_Bitacora.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_BITACORA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_CargarBitacora;
        private System.Windows.Forms.GroupBox GB_Bitacora;
        private System.Windows.Forms.DataGridView DGV_BITACORA;
    }
}