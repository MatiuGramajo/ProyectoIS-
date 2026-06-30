namespace Trabajo_practico_IS
{
    partial class FrmProducto
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
            this.DGV_Productos = new System.Windows.Forms.DataGridView();
            this.BTN_ProductoAlta = new System.Windows.Forms.Button();
            this.BTN_ProductoBaja = new System.Windows.Forms.Button();
            this.BTN_ProductoModificar = new System.Windows.Forms.Button();
            this.TXT_ProductoNombre = new System.Windows.Forms.TextBox();
            this.NUD_PrecioProd = new System.Windows.Forms.NumericUpDown();
            this.NUD_StockProd = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Productos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PrecioProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StockProd)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Productos
            // 
            this.DGV_Productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Productos.Location = new System.Drawing.Point(12, 23);
            this.DGV_Productos.Name = "DGV_Productos";
            this.DGV_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Productos.Size = new System.Drawing.Size(582, 218);
            this.DGV_Productos.TabIndex = 0;
            this.DGV_Productos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Productos_CellClick);
            // 
            // BTN_ProductoAlta
            // 
            this.BTN_ProductoAlta.Location = new System.Drawing.Point(34, 279);
            this.BTN_ProductoAlta.Name = "BTN_ProductoAlta";
            this.BTN_ProductoAlta.Size = new System.Drawing.Size(75, 23);
            this.BTN_ProductoAlta.TabIndex = 1;
            this.BTN_ProductoAlta.Text = "Alta";
            this.BTN_ProductoAlta.UseVisualStyleBackColor = true;
            this.BTN_ProductoAlta.Click += new System.EventHandler(this.BTN_ProductoAlta_Click);
            // 
            // BTN_ProductoBaja
            // 
            this.BTN_ProductoBaja.Location = new System.Drawing.Point(130, 279);
            this.BTN_ProductoBaja.Name = "BTN_ProductoBaja";
            this.BTN_ProductoBaja.Size = new System.Drawing.Size(75, 23);
            this.BTN_ProductoBaja.TabIndex = 2;
            this.BTN_ProductoBaja.Text = "Baja";
            this.BTN_ProductoBaja.UseVisualStyleBackColor = true;
            this.BTN_ProductoBaja.Click += new System.EventHandler(this.BTN_ProductoBaja_Click);
            // 
            // BTN_ProductoModificar
            // 
            this.BTN_ProductoModificar.Location = new System.Drawing.Point(222, 279);
            this.BTN_ProductoModificar.Name = "BTN_ProductoModificar";
            this.BTN_ProductoModificar.Size = new System.Drawing.Size(75, 23);
            this.BTN_ProductoModificar.TabIndex = 3;
            this.BTN_ProductoModificar.Text = "Modificar";
            this.BTN_ProductoModificar.UseVisualStyleBackColor = true;
            this.BTN_ProductoModificar.Click += new System.EventHandler(this.BTN_ProductoModificar_Click);
            // 
            // TXT_ProductoNombre
            // 
            this.TXT_ProductoNombre.Location = new System.Drawing.Point(364, 279);
            this.TXT_ProductoNombre.Name = "TXT_ProductoNombre";
            this.TXT_ProductoNombre.Size = new System.Drawing.Size(100, 20);
            this.TXT_ProductoNombre.TabIndex = 4;
            // 
            // NUD_PrecioProd
            // 
            this.NUD_PrecioProd.DecimalPlaces = 2;
            this.NUD_PrecioProd.Location = new System.Drawing.Point(364, 322);
            this.NUD_PrecioProd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUD_PrecioProd.Name = "NUD_PrecioProd";
            this.NUD_PrecioProd.Size = new System.Drawing.Size(100, 20);
            this.NUD_PrecioProd.TabIndex = 5;
            // 
            // NUD_StockProd
            // 
            this.NUD_StockProd.Location = new System.Drawing.Point(364, 364);
            this.NUD_StockProd.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUD_StockProd.Name = "NUD_StockProd";
            this.NUD_StockProd.Size = new System.Drawing.Size(100, 20);
            this.NUD_StockProd.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(787, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(720, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // FrmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(920, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.NUD_StockProd);
            this.Controls.Add(this.NUD_PrecioProd);
            this.Controls.Add(this.TXT_ProductoNombre);
            this.Controls.Add(this.BTN_ProductoModificar);
            this.Controls.Add(this.BTN_ProductoBaja);
            this.Controls.Add(this.BTN_ProductoAlta);
            this.Controls.Add(this.DGV_Productos);
            this.Name = "FrmProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "FrmProducto";
            this.Load += new System.EventHandler(this.FrmProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Productos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PrecioProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StockProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Productos;
        private System.Windows.Forms.Button BTN_ProductoAlta;
        private System.Windows.Forms.Button BTN_ProductoBaja;
        private System.Windows.Forms.Button BTN_ProductoModificar;
        private System.Windows.Forms.TextBox TXT_ProductoNombre;
        private System.Windows.Forms.NumericUpDown NUD_PrecioProd;
        private System.Windows.Forms.NumericUpDown NUD_StockProd;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}