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
            this.btnIngresos = new System.Windows.Forms.Button();
            this.btnEnviar2 = new System.Windows.Forms.Button();
            this.dtgvcomidas = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcomidas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModifcarMenu
            // 
            this.btnModifcarMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifcarMenu.Location = new System.Drawing.Point(525, 342);
            this.btnModifcarMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModifcarMenu.Name = "btnModifcarMenu";
            this.btnModifcarMenu.Size = new System.Drawing.Size(197, 63);
            this.btnModifcarMenu.TabIndex = 1;
            this.btnModifcarMenu.Text = "Modificar Menu";
            this.btnModifcarMenu.UseVisualStyleBackColor = true;
            this.btnModifcarMenu.Click += new System.EventHandler(this.btnModifcarMenu_Click);
            // 
            // btnIngresos
            // 
            this.btnIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresos.Location = new System.Drawing.Point(329, 363);
            this.btnIngresos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIngresos.Name = "btnIngresos";
            this.btnIngresos.Size = new System.Drawing.Size(157, 42);
            this.btnIngresos.TabIndex = 2;
            this.btnIngresos.Text = "Ingresos";
            this.btnIngresos.UseVisualStyleBackColor = true;
            // 
            // btnEnviar2
            // 
            this.btnEnviar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar2.Location = new System.Drawing.Point(169, 363);
            this.btnEnviar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnviar2.Name = "btnEnviar2";
            this.btnEnviar2.Size = new System.Drawing.Size(136, 42);
            this.btnEnviar2.TabIndex = 3;
            this.btnEnviar2.Text = "Enviar";
            this.btnEnviar2.UseVisualStyleBackColor = true;
            // 
            // dtgvcomidas
            // 
            this.dtgvcomidas.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dtgvcomidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvcomidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Precio});
            this.dtgvcomidas.Location = new System.Drawing.Point(0, 0);
            this.dtgvcomidas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgvcomidas.Name = "dtgvcomidas";
            this.dtgvcomidas.RowHeadersWidth = 51;
            this.dtgvcomidas.Size = new System.Drawing.Size(528, 336);
            this.dtgvcomidas.TabIndex = 4;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 177;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.Width = 177;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.btnEliminar.Location = new System.Drawing.Point(5, 363);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(137, 42);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // UC_Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dtgvcomidas);
            this.Controls.Add(this.btnEnviar2);
            this.Controls.Add(this.btnIngresos);
            this.Controls.Add(this.btnModifcarMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Gestion";
            this.Size = new System.Drawing.Size(737, 423);
            this.Load += new System.EventHandler(this.UC_Gestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcomidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModifcarMenu;
        private System.Windows.Forms.Button btnIngresos;
        private System.Windows.Forms.Button btnEnviar2;
        private System.Windows.Forms.DataGridView dtgvcomidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Button btnEliminar;
    }
}
