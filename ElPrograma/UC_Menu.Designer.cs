namespace ElPrograma
{
    partial class UC_Menu
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
            this.panel_menu = new System.Windows.Forms.Panel();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCarrito = new System.Windows.Forms.Panel();
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.btncancelar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.pnlCarrito.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_menu
            // 
            this.panel_menu.AutoScroll = true;
            this.panel_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_menu.Location = new System.Drawing.Point(0, 0);
            this.panel_menu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(799, 642);
            this.panel_menu.TabIndex = 4;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(62, 601);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(180, 33);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 62);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(92, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Carrito";
            // 
            // pnlCarrito
            // 
            this.pnlCarrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCarrito.Controls.Add(this.pnlProductos);
            this.pnlCarrito.Controls.Add(this.btncancelar);
            this.pnlCarrito.Controls.Add(this.panel2);
            this.pnlCarrito.Controls.Add(this.btnEnviar);
            this.pnlCarrito.Location = new System.Drawing.Point(805, 2);
            this.pnlCarrito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCarrito.Name = "pnlCarrito";
            this.pnlCarrito.Size = new System.Drawing.Size(318, 638);
            this.pnlCarrito.TabIndex = 0;
            // 
            // pnlProductos
            // 
            this.pnlProductos.AutoScroll = true;
            this.pnlProductos.AutoScrollMargin = new System.Drawing.Size(10, 20);
            this.pnlProductos.Location = new System.Drawing.Point(12, 69);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(290, 487);
            this.pnlProductos.TabIndex = 5;
            // 
            // btncancelar
            // 
            this.btncancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancelar.Location = new System.Drawing.Point(75, 561);
            this.btncancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(151, 36);
            this.btncancelar.TabIndex = 2;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // UC_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.Controls.Add(this.pnlCarrito);
            this.Controls.Add(this.panel_menu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Menu";
            this.Size = new System.Drawing.Size(1126, 642);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlCarrito.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlCarrito;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Panel pnlProductos;
    }
}
