﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ElPrograma
{
    public partial class UC_Menu : UserControl
    {

        int PnlProductosX = 8;
        int PnlProductosY = 27;

        public UC_Menu()
        {
            InitializeComponent();

         

            MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=proyecto; Uid=root; Pwd=contrasena;");
            conexion.Open();
            MySqlCommand comandos = new MySqlCommand("SELECT ID,Nombre, Imagen, Disponible FROM categoria where Disponible=1;", conexion);
            comandos.Connection = conexion;
            MySqlDataAdapter consulta_categoria = new MySqlDataAdapter();
            consulta_categoria.SelectCommand = comandos;
            DataTable dt = new DataTable();
            consulta_categoria.Fill(dt);
        

            int PanelPosicionY = 0;
            int PanelPosicionX = 0;
            
            

            foreach (DataRow dr in dt.Rows)
            {

                Panel panel_categoria = new Panel();
                panel_categoria.Width = 372;
                panel_categoria.Location = new Point(PanelPosicionX, PanelPosicionY);
                panel_categoria.Height = 90;
                panel_categoria.BackColor = System.Drawing.Color.White;
                panel_categoria.AutoScroll= true;

                Label Nombre_Categoria = new Label();
                Nombre_Categoria.Text = dr["Nombre"].ToString();
                Nombre_Categoria.Font = new Font("Roboto Bk", 15);
                panel_categoria.Controls.Add(Nombre_Categoria);


                PictureBox Picture = new PictureBox();
                int ancho = 40;
                int alto = 60;
                MemoryStream transferencia = new MemoryStream((byte[])dr["Imagen"]);
                Bitmap foto = new Bitmap(transferencia);
                ancho = Convert.ToInt32(foto.Width * alto/foto.Height);
                Picture.Width = ancho;
                Picture.Height = alto;
                Picture.Image = foto;
                Picture.SizeMode = PictureBoxSizeMode.StretchImage;
                Picture.Location = new Point(0, 20);
                panel_categoria.Controls.Add(Picture);

                panel_menu.Controls.Add(panel_categoria);

                PanelPosicionY += 120;


                MySqlCommand query = new MySqlCommand("SELECT  ID, Nombre, Precio, Disponible FROM  Platos where Disponible=1 and ID_Categoria =" + dr["ID"] + " ORDER BY ID ASC;", conexion);
                query.Connection = conexion;
                MySqlDataAdapter consulta_platos = new MySqlDataAdapter();
                consulta_platos.SelectCommand = query;
                DataTable dt2 = new DataTable();
                consulta_platos.Fill(dt2);

                int btn_PosicionX = 10;
                int btn_PosicionY = 100;
                

                foreach (DataRow dataRow in dt2.Rows)
                {
                    //Guardar en variables auxiliares el ID y precio de cada producto
                    Button btn_platos = new Button();
                    btn_platos.Width = 80;
                    btn_platos.Height = 50;
                    btn_platos.Location = new Point(btn_PosicionX, btn_PosicionY);

                    int id = Convert.ToInt32(dataRow["ID"]);
                    string nombre = dataRow["Nombre"].ToString();
                    int precio = Convert.ToInt32(dataRow["Precio"]);

                    btn_platos.Text = nombre;

                    btn_platos.Tag = new { ID = id, Nombre = nombre, Precio = precio };

                    btn_platos.Click += Button_Click;

                    panel_categoria.Controls.Add(btn_platos);
                 
                    btn_PosicionX +=70;
                    btn_PosicionX +=20;

                }

            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviar_Click_1(object sender, EventArgs e)
        {

        }

        private void panel_menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            dynamic producto = btn.Tag;
            int PnlProductosX = 8;
            int PnlProductosY = 27;

            Panel pnlPlatos = new Panel();
            pnlPlatos.Width = 380;
            pnlPlatos.Height = 70;
            pnlPlatos.Location = new Point(PnlProductosX, PnlProductosY);
            pnlPlatos.BackColor = Color.White;
            pnlPlatos.BringToFront();

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre: " + producto.Nombre;
            lblNombre.Location = new Point(25, 30);
            

            Label lblPrecio = new Label();
            lblPrecio.Text = "Precio: $" + producto.Precio.ToString();
            lblPrecio.Location = new Point(185,30);
            

            pnlPlatos.Controls.Add(lblNombre);
            pnlPlatos.Controls.Add(lblPrecio);

            pnlProductos.Controls.Add(pnlPlatos);

            //int nuevaPosY = pnlPlatos.Controls.Cast<Control>().Sum(ctrl => ctrl.Height) + 10;
            //pnlPlatos.Location = new Point(0, nuevaPosY);

            MessageBox.Show(lblNombre.Text + lblPrecio.Text);

            

        }






    }
}
