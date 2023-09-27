using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ElPrograma
{
    public partial class ModificarMenu : Form
    {
        private int margin = 10;

        private int panelCounter = 0;
        private int panelHeight = 50;
        private int initialPanelPositionY = 10;

        private int panelPositionY = 10;

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

            texprecio1.KeyPress += textBoxprecio_KeyPress;
            texprecio2.KeyPress += textBoxprecio_KeyPress;
            texprecio3.KeyPress += textBoxprecio_KeyPress;
            texprecio4.KeyPress += textBoxprecio_KeyPress;
            texprecio5.KeyPress += textBoxprecio_KeyPress;
            texprecio6.KeyPress += textBoxprecio_KeyPress;

            texprod1.KeyPress += textBoxnombre_KeyPress;
            texprod2.KeyPress += textBoxnombre_KeyPress;
            texprod3.KeyPress += textBoxnombre_KeyPress;
            texprod4.KeyPress += textBoxnombre_KeyPress;
            texprod5.KeyPress += textBoxnombre_KeyPress;
            texprod6.KeyPress += textBoxnombre_KeyPress;
            txtNuevaCategoria.KeyPress += textBoxnombre_KeyPress;

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


        private void MostrarDatos()
        {


            string connectionString = "server=localhost;database=baseDatosMomentaria;user=root;password=contrasenia;";
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
            string connectionString = "server=localhost;database=baseDatosMomentaria;user=root;password=contrasenia;";
            long IDultimacategoria = -1;

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    

                     if (!string.IsNullOrWhiteSpace(txtNuevaCategoria.Text) && !string.IsNullOrWhiteSpace(texprod1.Text) && !string.IsNullOrWhiteSpace(texprecio1.Text ) && rutaImagenSeleccionada!="")
                    {
                         

                        string valor = txtNuevaCategoria.Text;
                        if (!string.IsNullOrWhiteSpace(valor))
                        {
                            MessageBox.Show(rutaImagenSeleccionada);

                            byte[] imagenBytes = ImageToByteArray(pcbAgregarImagen.Image);
                            pcbAgregarImagen.Image = null;

                            string insertQuery = "INSERT INTO categoria (Nombre,Imagen) VALUES (@Nombre,@Imagen);";
                            

                            using (MySqlCommand cmd = new MySqlCommand(insertQuery, conexion))
                            {
                                cmd.Parameters.AddWithValue("@Nombre", txtNuevaCategoria.Text);
                                cmd.Parameters.AddWithValue("@Imagen", imagenBytes);
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

            
            

            MostrarDatos();
            MostrarDatosDesdeBD();

        }

        private void CrearCategoriaDesdeBD(long categoriaId, string nombreCategoria, byte[] imagenBytes)
        {
            Panel nuevoPanel = new Panel();
            nuevoPanel.Height = 50; // Ajusta el tamaño según tus preferencias
            nuevoPanel.Width = 130;
            nuevoPanel.BorderStyle = BorderStyle.FixedSingle;
            nuevoPanel.BackColor = Color.LightGray;

           


            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Fill;

            Label nuevoLabel = new Label();
            nuevoLabel.Text = nombreCategoria;
            nuevoLabel.AutoSize = true;
            nuevoLabel.Font = new Font("Roboto Bk", 10);

           

            PictureBox imagenPictureBox = new PictureBox();
            imagenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if (imagenBytes != null && imagenBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    imagenPictureBox.Image = Image.FromStream(ms);
                }
            }

            // Ajusta el porcentaje de espacio que ocupa cada control en el panel
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70)); // Imagen
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70)); // Nombre de la categoría
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70)); // Espacio para la imagen
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40)); // Espacio para el nombre de la categoría

            tableLayout.Controls.Add(imagenPictureBox, 0, 0);
            tableLayout.Name = categoriaId.ToString();
            tableLayout.Controls.Add(nuevoLabel, 0, 1);

            nuevoPanel.Controls.Add(tableLayout);

            tableLayout.MouseDown += new MouseEventHandler(panelRezisable_MouseDown);


            panel1.Controls.Add(nuevoPanel);

            nuevoPanel.Location = new Point(5, panelPositionY);
            panelPositionY += nuevoPanel.Height + margin;

            panelCounter++;
        }

        private void panelRezisable_MouseDown(object sender, MouseEventArgs e)
        {
            TableLayoutPanel panel = sender as TableLayoutPanel;

            if (panel != null)
            {
                string categoriaId = panel.Name;
                ventanaCategorias ven = new ventanaCategorias(categoriaId, 23);
                ven.ShowDialog();
            }
        }

        private void MostrarDatosDesdeBD()
        {
            string connectionString = "server=localhost;database=baseDatosMomentaria;user=root;password=contrasenia;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT ID, Nombre, Imagen FROM categoria;"; // Agrega la columna Imagen a la consulta

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long categoriaId = Convert.ToInt64(reader["ID"]);
                                string nombreCategoria = reader["Nombre"].ToString();
                                byte[] imagenBytes = reader["Imagen"] as byte[]; // Recupera los bytes de la imagen
                                
                                

                                CrearCategoriaDesdeBD(categoriaId, nombreCategoria, imagenBytes); // Pasa los bytes de la imagen a la función
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }


            }
        }


        private void GuardarProducto(long categoriaId, string nombre, string precio)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(precio) ) 
            {
                return;            
            
            }
            string connectionString = "server=localhost;database=baseDatosMomentaria;user=root;password=contrasenia;";

            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string insertQuery = "INSERT INTO `platos`(`Nombre`, `Precio`, `ID_Categoria`) VALUES (@Nombre, @Precio, @ID_Categoria);";

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

        private void subirBajar_ValueChanged(object sender, EventArgs e)
        {

            int scrollValue = subirBajar.Value;
            int newY = initialPanelPositionY - (scrollValue * (panelHeight + margin));

            foreach (Control control in panel1.Controls)
            {
                if (control is Panel)
                {
                    control.Location = new Point(control.Location.X, newY);
                    newY += panelHeight + margin;
                }
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg); // Puedes ajustar el formato aquí
                return memoryStream.ToArray();
            }
        }
       

        private void textBoxprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}

