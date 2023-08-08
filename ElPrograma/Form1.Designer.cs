namespace ElPrograma
{
    partial class menuVertical
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menuVertical));
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMinimixar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGestion = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelTitulo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.panelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitulo.Controls.Add(this.label2);
            this.panelTitulo.Controls.Add(this.label1);
            this.panelTitulo.Controls.Add(this.btnMinimixar);
            this.panelTitulo.Controls.Add(this.btnSalir);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(955, 45);
            this.panelTitulo.TabIndex = 0;
            this.panelTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitulo_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(450, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 38);
            this.label2.TabIndex = 5;
            this.label2.Text = "Inicio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(11, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "LA TUERCA";
            // 
            // btnMinimixar
            // 
            this.btnMinimixar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimixar.BackgroundImage")));
            this.btnMinimixar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimixar.Location = new System.Drawing.Point(876, 6);
            this.btnMinimixar.Name = "btnMinimixar";
            this.btnMinimixar.Size = new System.Drawing.Size(35, 33);
            this.btnMinimixar.TabIndex = 3;
            this.btnMinimixar.UseVisualStyleBackColor = true;
            this.btnMinimixar.Click += new System.EventHandler(this.btnMinimixar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalir.Location = new System.Drawing.Point(917, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(35, 33);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnGestion);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.btnIniciar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 423);
            this.panel1.TabIndex = 1;
            // 
            // btnGestion
            // 
            this.btnGestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.btnGestion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnGestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestion.ForeColor = System.Drawing.Color.White;
            this.btnGestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestion.Location = new System.Drawing.Point(31, 293);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(154, 47);
            this.btnGestion.TabIndex = 2;
            this.btnGestion.Text = "Gestionar";
            this.btnGestion.UseVisualStyleBackColor = false;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.Location = new System.Drawing.Point(31, 187);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(154, 47);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Menú";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.btnIniciar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(31, 79);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(154, 47);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Inicio";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.panelContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(218, 45);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(737, 423);
            this.panelContenedor.TabIndex = 2;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // menuVertical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 468);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menuVertical";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LaTuerca";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMinimixar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGestion;
        private System.Windows.Forms.Button btnMenu;
    }
}

