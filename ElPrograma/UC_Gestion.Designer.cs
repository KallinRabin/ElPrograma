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
            this.btnGrafica = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnMensual = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // btnGrafica
            // 
            this.btnGrafica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrafica.Location = new System.Drawing.Point(865, 370);
            this.btnGrafica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGrafica.Name = "btnGrafica";
            this.btnGrafica.Size = new System.Drawing.Size(197, 63);
            this.btnGrafica.TabIndex = 5;
            this.btnGrafica.Text = "Grafica";
            this.btnGrafica.UseVisualStyleBackColor = true;
            this.btnGrafica.Click += new System.EventHandler(this.btnGrafica_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(801, 570);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnMensual
            // 
            this.btnMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMensual.Location = new System.Drawing.Point(865, 437);
            this.btnMensual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMensual.Name = "btnMensual";
            this.btnMensual.Size = new System.Drawing.Size(197, 63);
            this.btnMensual.TabIndex = 7;
            this.btnMensual.Text = "Mensual";
            this.btnMensual.UseVisualStyleBackColor = true;
            this.btnMensual.Click += new System.EventHandler(this.btnMensual_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(862, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // UC_Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnMensual);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGrafica);
            this.Controls.Add(this.btnModifcarMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Gestion";
            this.Size = new System.Drawing.Size(1126, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModifcarMenu;
        private System.Windows.Forms.Button btnGrafica;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnMensual;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
