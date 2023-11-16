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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnModifcarMenu = new System.Windows.Forms.Button();
            this.btnIngresos = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModifcarMenu
            // 
            this.btnModifcarMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifcarMenu.Location = new System.Drawing.Point(394, 278);
            this.btnModifcarMenu.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnIngresos.Margin = new System.Windows.Forms.Padding(2);
            this.btnIngresos.Name = "btnIngresos";
            this.btnIngresos.Size = new System.Drawing.Size(118, 34);
            this.btnIngresos.TabIndex = 2;
            this.btnIngresos.Text = "Ingresos";
            this.btnIngresos.UseVisualStyleBackColor = true;
            this.btnIngresos.Click += new System.EventHandler(this.btnIngresos_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(65, 0);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(300, 290);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            // 
            // UC_Gestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(39)))));
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnIngresos);
            this.Controls.Add(this.btnModifcarMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UC_Gestion";
            this.Size = new System.Drawing.Size(553, 344);
            this.Load += new System.EventHandler(this.UC_Gestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnModifcarMenu;
        private System.Windows.Forms.Button btnIngresos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
    }
}
