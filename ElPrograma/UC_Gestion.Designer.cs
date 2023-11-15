namespace ElPrograma
{
    partial class UC_Gestion
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnModifcarMenu = new System.Windows.Forms.Button();
            this.dtgvcomidas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcomidas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModifcarMenu
            // 
            this.btnModifcarMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifcarMenu.Location = new System.Drawing.Point(865, 513);
            this.btnModifcarMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModifcarMenu.Name = "btnModifcarMenu";
            this.btnModifcarMenu.Size = new System.Drawing.Size(197, 63);
            this.btnModifcarMenu.TabIndex = 1;
            this.btnModifcarMenu.Text = "Modificar Menu";
            this.btnModifcarMenu.UseVisualStyleBackColor = true;
            this.btnModifcarMenu.Click += new System.EventHandler(this.btnModifcarMenu_Click);
            // 
            // dtgvcomidas
            // 
            this.dtgvcomidas.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dtgvcomidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvcomidas.Location = new System.Drawing.Point(4, 4);
            this.dtgvcomidas.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvcomidas.MultiSelect = false;
            this.dtgvcomidas.Name = "dtgvcomidas";
            this.dtgvcomidas.RowHeadersWidth = 51;
            this.dtgvcomidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvcomidas.Size = new System.Drawing.Size(819, 507);
            this.dtgvcomidas.TabIndex = 4;
            // 
            // UC_Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.Controls.Add(this.dtgvcomidas);
            this.Controls.Add(this.btnModifcarMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Gestion";
            this.Size = new System.Drawing.Size(1126, 642);
            this.Load += new System.EventHandler(this.UC_Gestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcomidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModifcarMenu;
        private System.Windows.Forms.DataGridView dtgvcomidas;
    }
}
