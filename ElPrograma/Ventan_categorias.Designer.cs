namespace ElPrograma
{
    partial class Ventan_categorias
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
            this.Modificar_cat = new System.Windows.Forms.Button();
            this.Eliminar_plato = new System.Windows.Forms.Button();
            this.agregar_plato = new System.Windows.Forms.Button();
            this.Modificar_nom = new System.Windows.Forms.TextBox();
            this.Modificar_precio = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Modificar_cat
            // 
            this.Modificar_cat.Location = new System.Drawing.Point(186, 340);
            this.Modificar_cat.Name = "Modificar_cat";
            this.Modificar_cat.Size = new System.Drawing.Size(75, 23);
            this.Modificar_cat.TabIndex = 0;
            this.Modificar_cat.Text = "Modificar";
            this.Modificar_cat.UseVisualStyleBackColor = true;
            // 
            // Eliminar_plato
            // 
            this.Eliminar_plato.Location = new System.Drawing.Point(375, 339);
            this.Eliminar_plato.Name = "Eliminar_plato";
            this.Eliminar_plato.Size = new System.Drawing.Size(75, 23);
            this.Eliminar_plato.TabIndex = 1;
            this.Eliminar_plato.Text = "Eliminar";
            this.Eliminar_plato.UseVisualStyleBackColor = true;
            // 
            // agregar_plato
            // 
            this.agregar_plato.Location = new System.Drawing.Point(596, 239);
            this.agregar_plato.Name = "agregar_plato";
            this.agregar_plato.Size = new System.Drawing.Size(100, 23);
            this.agregar_plato.TabIndex = 2;
            this.agregar_plato.Text = "Agregar Plato";
            this.agregar_plato.UseVisualStyleBackColor = true;
            // 
            // Modificar_nom
            // 
            this.Modificar_nom.Location = new System.Drawing.Point(596, 102);
            this.Modificar_nom.Name = "Modificar_nom";
            this.Modificar_nom.Size = new System.Drawing.Size(100, 20);
            this.Modificar_nom.TabIndex = 3;
            // 
            // Modificar_precio
            // 
            this.Modificar_precio.Location = new System.Drawing.Point(596, 164);
            this.Modificar_precio.Name = "Modificar_precio";
            this.Modificar_precio.Size = new System.Drawing.Size(100, 20);
            this.Modificar_precio.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(83, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(343, 163);
            this.dataGridView1.TabIndex = 5;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Precio";
            this.Column1.Name = "Column1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(596, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(596, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // Ventan_categorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Modificar_precio);
            this.Controls.Add(this.Modificar_nom);
            this.Controls.Add(this.agregar_plato);
            this.Controls.Add(this.Eliminar_plato);
            this.Controls.Add(this.Modificar_cat);
            this.Name = "Ventan_categorias";
            this.Text = "Ventan_categorias";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Modificar_cat;
        private System.Windows.Forms.Button Eliminar_plato;
        private System.Windows.Forms.Button agregar_plato;
        private System.Windows.Forms.TextBox Modificar_nom;
        private System.Windows.Forms.TextBox Modificar_precio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}