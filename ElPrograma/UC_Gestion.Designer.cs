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
            this.SuspendLayout();
            // 
            // btnModifcarMenu
            // 
            this.btnModifcarMenu.Font = new System.Drawing.Font("Roboto Bk", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifcarMenu.Location = new System.Drawing.Point(526, 342);
            this.btnModifcarMenu.Name = "btnModifcarMenu";
            this.btnModifcarMenu.Size = new System.Drawing.Size(198, 63);
            this.btnModifcarMenu.TabIndex = 1;
            this.btnModifcarMenu.Text = "Modificar Menu";
            this.btnModifcarMenu.UseVisualStyleBackColor = true;
            this.btnModifcarMenu.Click += new System.EventHandler(this.btnModifcarMenu_Click);
            // 
            // btnIngresos
            // 
            this.btnIngresos.Font = new System.Drawing.Font("Roboto Bk", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresos.Location = new System.Drawing.Point(318, 363);
            this.btnIngresos.Name = "btnIngresos";
            this.btnIngresos.Size = new System.Drawing.Size(136, 42);
            this.btnIngresos.TabIndex = 2;
            this.btnIngresos.Text = "Ingresos";
            this.btnIngresos.UseVisualStyleBackColor = true;
            // 
            // btnEnviar2
            // 
            this.btnEnviar2.Font = new System.Drawing.Font("Roboto Bk", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar2.Location = new System.Drawing.Point(67, 363);
            this.btnEnviar2.Name = "btnEnviar2";
            this.btnEnviar2.Size = new System.Drawing.Size(136, 42);
            this.btnEnviar2.TabIndex = 3;
            this.btnEnviar2.Text = "Enviar";
            this.btnEnviar2.UseVisualStyleBackColor = true;
            // 
            // UC_Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.Controls.Add(this.btnEnviar2);
            this.Controls.Add(this.btnIngresos);
            this.Controls.Add(this.btnModifcarMenu);
            this.Name = "UC_Gestion";
            this.Size = new System.Drawing.Size(737, 423);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModifcarMenu;
        private System.Windows.Forms.Button btnIngresos;
        private System.Windows.Forms.Button btnEnviar2;
    }
}
