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
            this.nomprueba = new System.Windows.Forms.TextBox();
            this.precprueba = new System.Windows.Forms.TextBox();
            this.pruebad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcomidas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModifcarMenu
            // 
            this.btnModifcarMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifcarMenu.Location = new System.Drawing.Point(394, 278);
            this.btnModifcarMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModifcarMenu.Name = "btnModifcarMenu";
            this.btnModifcarMenu.Size = new System.Drawing.Size(148, 51);
            this.btnModifcarMenu.TabIndex = 1;
            this.btnModifcarMenu.Text = "Modificar Menu";
            this.btnModifcarMenu.UseVisualStyleBackColor = true;
            this.btnModifcarMenu.Click += new System.EventHandler(this.btnModifcarMenu_Click);
            // 
            // btnIngresos
            // 
            this.btnIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresos.Location = new System.Drawing.Point(247, 295);
            this.btnIngresos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIngresos.Name = "btnIngresos";
            this.btnIngresos.Size = new System.Drawing.Size(118, 34);
            this.btnIngresos.TabIndex = 2;
            this.btnIngresos.Text = "Ingresos";
            this.btnIngresos.UseVisualStyleBackColor = true;
            // 
            // btnEnviar2
            // 
            this.btnEnviar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar2.Location = new System.Drawing.Point(127, 295);
            this.btnEnviar2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnviar2.Name = "btnEnviar2";
            this.btnEnviar2.Size = new System.Drawing.Size(102, 34);
            this.btnEnviar2.TabIndex = 3;
            this.btnEnviar2.Text = "Enviar";
            this.btnEnviar2.UseVisualStyleBackColor = true;
            this.btnEnviar2.Click += new System.EventHandler(this.btnEnviar2_Click);
            // 
            // dtgvcomidas
            // 
            this.dtgvcomidas.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dtgvcomidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvcomidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Precio});
            this.dtgvcomidas.Location = new System.Drawing.Point(0, 0);
            this.dtgvcomidas.MultiSelect = false;
            this.dtgvcomidas.Name = "dtgvcomidas";
            this.dtgvcomidas.ReadOnly = true;
            this.dtgvcomidas.RowHeadersWidth = 51;
            this.dtgvcomidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvcomidas.Size = new System.Drawing.Size(396, 273);
            this.dtgvcomidas.TabIndex = 4;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 177;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 177;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.btnEliminar.Location = new System.Drawing.Point(4, 295);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(103, 34);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // nomprueba
            // 
            this.nomprueba.Location = new System.Drawing.Point(432, 84);
            this.nomprueba.Name = "nomprueba";
            this.nomprueba.Size = new System.Drawing.Size(100, 20);
            this.nomprueba.TabIndex = 6;
            // 
            // precprueba
            // 
            this.precprueba.Location = new System.Drawing.Point(432, 111);
            this.precprueba.Name = "precprueba";
            this.precprueba.Size = new System.Drawing.Size(100, 20);
            this.precprueba.TabIndex = 7;
            // 
            // pruebad
            // 
            this.pruebad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pruebad.Location = new System.Drawing.Point(430, 152);
            this.pruebad.Margin = new System.Windows.Forms.Padding(2);
            this.pruebad.Name = "pruebad";
            this.pruebad.Size = new System.Drawing.Size(102, 34);
            this.pruebad.TabIndex = 8;
            this.pruebad.Text = "Enviar";
            this.pruebad.UseVisualStyleBackColor = true;
            this.pruebad.Click += new System.EventHandler(this.pruebad_Click);
            // 
            // UC_Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.Controls.Add(this.pruebad);
            this.Controls.Add(this.precprueba);
            this.Controls.Add(this.nomprueba);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dtgvcomidas);
            this.Controls.Add(this.btnEnviar2);
            this.Controls.Add(this.btnIngresos);
            this.Controls.Add(this.btnModifcarMenu);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UC_Gestion";
            this.Size = new System.Drawing.Size(553, 344);
            this.Load += new System.EventHandler(this.UC_Gestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcomidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnModifcarMenu;
        private System.Windows.Forms.Button btnIngresos;
        private System.Windows.Forms.Button btnEnviar2;
        private System.Windows.Forms.DataGridView dtgvcomidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox nomprueba;
        private System.Windows.Forms.TextBox precprueba;
        private System.Windows.Forms.Button pruebad;
    }
}
