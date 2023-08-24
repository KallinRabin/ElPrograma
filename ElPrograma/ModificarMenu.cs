﻿using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElPrograma
{
    public partial class ModificarMenu : Form
    {
        private int margin = 10;

        private int panelCounter = 0;
        private int panelHeight = 50;
        private int initialPanelPositionY = 44;

        private string rutaImagenSeleccionada = "";

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public ModificarMenu()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void CrearCategoria(string contenido, string rutaImagen)
        {

            Panel nuevoPanel = new Panel();
            nuevoPanel.Height = panelHeight;
            nuevoPanel.BorderStyle = BorderStyle.FixedSingle;
            nuevoPanel.BackColor = Color.LightGray;

            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Fill;

            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = Image.FromFile(rutaImagen);
            pictureBox.Size = new Size(30, 30); // Ajustar el tamaño del PictureBox

            Label nuevoLabel = new Label();
            nuevoLabel.Text = contenido;
            nuevoLabel.AutoSize = true;
            nuevoLabel.Font = new Font("Roboto Bk", 10);

            tableLayout.Controls.Add(pictureBox, 0, 0);
            tableLayout.Controls.Add(nuevoLabel, 1, 0);
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Centra verticalmente los controles

            nuevoPanel.Controls.Add(tableLayout);
            panel1.Controls.Add(nuevoPanel);

            int panelPosicionY = initialPanelPositionY + (panelCounter * (panelHeight + margin));
            nuevoPanel.Location = new Point(10, panelPosicionY);

            panelCounter++;

        }
        private void MostrarDatos()
        {


            string connectionString = "server=localhost;database=baseDato;user=root;password=contrasenia;";
            string query = "SELECT nombre FROM categoria ORDER BY ID DESC LIMIT 1;";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string valor = reader["nombre"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros en la base de datos.");
                    }

                    reader.Close();

                }
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=baseDato;user=root;password=contrasenia;";
            long IDultimacategoria = -1;

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    //MessageBox.Show(string.IsNullOrWhiteSpace(txtNuevaCategoria.Text).ToString());
                    //MessageBox.Show(string.IsNullOrWhiteSpace(rutaImagenSeleccionada).ToString());

                     if (!string.IsNullOrWhiteSpace(txtNuevaCategoria.Text) && !string.IsNullOrWhiteSpace(texprod1.Text) && !string.IsNullOrWhiteSpace(texprecio1.Text) && rutaImagenSeleccionada!="")
                    {


                        string valor = txtNuevaCategoria.Text;
                        if (!string.IsNullOrWhiteSpace(valor))
                        {
                            CrearCategoria(valor, rutaImagenSeleccionada);
                            pcbAgregarImagen.Image = null;

                            string insertQuery = "INSERT INTO `categoria` (`Nombre`) VALUES (@Nombre);";

                            using (MySqlCommand cmd = new MySqlCommand(insertQuery, conexion))
                            {
                                cmd.Parameters.AddWithValue("@Nombre", txtNuevaCategoria.Text);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                IDultimacategoria = cmd.LastInsertedId;
                                MessageBox.Show("Nueva categoria agregada");
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("El campo 'Nueva Categoría' y los campos 'Nombre' y 'Precio' del primer producto no pueden estar vacíos.", "Por favor, selecciona una imagen primero.");
                    }

                   
                    
                

                    
                }

                if (IDultimacategoria != -1)
                {
                    GuardarProducto(IDultimacategoria, texprod1.Text, texprecio1.Text);
                    GuardarProducto(IDultimacategoria, texprod2.Text, texprecio2.Text);
                    GuardarProducto(IDultimacategoria, texprod3.Text, texprecio3.Text);
                    GuardarProducto(IDultimacategoria, texprod4.Text, texprecio4.Text);
                    GuardarProducto(IDultimacategoria, texprod5.Text, texprecio5.Text);
                    GuardarProducto(IDultimacategoria, texprod6.Text, texprecio6.Text);
                    MessageBox.Show("Nuevos platos agregados");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

           /* if (!string.IsNullOrWhiteSpace(rutaImagenSeleccionada))
            {
                string valor = txtNuevaCategoria.Text;

                if (!string.IsNullOrWhiteSpace(valor))
                {
                    CrearCategoria(valor, rutaImagenSeleccionada);
                    pcbAgregarImagen.Image = null;
                }

            }
            else
            {
                MessageBox.Show("Por favor, selecciona una imagen primero.");
            }*/

            MostrarDatos();

        }

        private void GuardarProducto(long categoriaId, string nombre, string precio)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(precio) ) 
            {
                return;            
            
            }
            string connectionString = "server=localhost;database=baseDato;user=root;password=contrasenia;";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string insertQuery = "INSERT INTO `platos`(`Nombre`,`Descripcion`, `Precio`, `ID_Categoria`) VALUES (@Nombre, 'hola', @Precio, @ID_Categoria);";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@ID_Categoria", categoriaId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void pcbRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbAgregarImagen_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagenSeleccionada = openFileDialog.FileName;

                pcbAgregarImagen.Image = Image.FromFile(rutaImagenSeleccionada);
                pcbAgregarImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
    }