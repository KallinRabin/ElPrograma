using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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

        string basedeDatos = "Proyecto1";
        string contrasenia = "contrasena";
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

            this.WindowState = FormWindowState.Maximized;
            cargarCategorias();
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

        private void CrearCategoria(string contenido, System.Drawing.Image imagen, string ID)
        {
            Panel nuevoPanel = new Panel() {
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Top,
                Height = 35,
                Name = ID 
            };
            Label lblNombre = new Label()
            {
                Dock = DockStyle.Fill,
                Text = contenido,
                AutoSize = false,
                Font = new Font("Roboto Bk", 10),
                Name = ID
            };
            PictureBox Imagen = new PictureBox() {
                Dock = DockStyle.Left,
                Width = 35,
                Image = imagen,
                SizeMode = PictureBoxSizeMode.Zoom,
                Name = ID
            };
            Button btnDarDeBaja = new Button()
            {
                Text = "Dar de Baja",
                Dock = DockStyle.Right,
                Width = 80,
                Name = ID
            };

            nuevoPanel.Controls.Add(lblNombre);
            nuevoPanel.Controls.Add(Imagen);
            nuevoPanel.Controls.Add(btnDarDeBaja);
            pnlCategorias.Controls.Add(nuevoPanel);

            lblNombre.Click += (sender, e) =>
            {
                Ventan_categorias ven = new Ventan_categorias(Imagen.Name);
                ven.ShowDialog();
            };
            Imagen.Click += (sender, e) =>
            {
                Ventan_categorias ven = new Ventan_categorias(lblNombre.Name);
                ven.ShowDialog();
            };
            btnDarDeBaja.Click += (sender, e) =>
            {
                string categoriaId = ((Button)sender).Name;
                // Lógica para dar de baja la categoría en la base de datos y el programa
                DarDeBajaCategoria(categoriaId);
            };


            panelCounter++;
        }

        private void MostrarDatos()
        {
            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");
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
        private void DarDeBajaCategoria(string categoriaId)
        {
            // Establecer disponible en 0 en la base de datos
            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");
            string updateQuery = "UPDATE categoria SET disponible = 0 WHERE ID = @CategoriaId;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("No se pudo dar de baja la categoría.");
                    }
                }
            }
            cargarCategorias();
        }
        private void cargarCategorias()
        {
            pnlCategorias.Controls.Clear();
            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                connection.Open();

                string query = "SELECT * from categoria WHERE disponible = 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] imagenBytes = (byte[])reader["Imagen"];
                            string nombreCategoria = reader["Nombre"].ToString();
                            string idCategoria = reader["ID"].ToString();
                            using (MemoryStream ms = new MemoryStream(imagenBytes))
                            {
                                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                                CrearCategoria(nombreCategoria, imagen, idCategoria);
                            }
                        }
                    }
                }


            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");
            long IDultimacategoria = -1;

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    if (!string.IsNullOrWhiteSpace(txtNuevaCategoria.Text) && !string.IsNullOrWhiteSpace(texprod1.Text) && !string.IsNullOrWhiteSpace(texprecio1.Text) && rutaImagenSeleccionada != "")
                    {
                        byte[] imagenBytes = ImageToByteArray(pcbAgregarImagen.Image);
                        pcbAgregarImagen.Image = null;

                        string insertCategoriaQuery = "INSERT INTO categoria (Nombre, Imagen, disponible) VALUES (@Nombre, @Imagen, 1);";

                        using (MySqlCommand cmdCategoria = new MySqlCommand(insertCategoriaQuery, conexion))
                        {
                            cmdCategoria.Parameters.AddWithValue("@Nombre", txtNuevaCategoria.Text);
                            cmdCategoria.Parameters.AddWithValue("@Imagen", imagenBytes);
                            int rowsAffectedCategoria = cmdCategoria.ExecuteNonQuery();

                            // Obtener el ID de la última categoría insertada
                            IDultimacategoria = cmdCategoria.LastInsertedId;
                            MessageBox.Show("Nueva categoría agregada");

                            if (rowsAffectedCategoria > 0)
                            {
                                // Establecer los productos de la nueva categoría como disponibles
                                GuardarProducto(IDultimacategoria, texprod1.Text, texprecio1.Text);
                                GuardarProducto(IDultimacategoria, texprod2.Text, texprecio2.Text);
                                GuardarProducto(IDultimacategoria, texprod3.Text, texprecio3.Text);
                                GuardarProducto(IDultimacategoria, texprod4.Text, texprecio4.Text);
                                GuardarProducto(IDultimacategoria, texprod5.Text, texprecio5.Text);
                                GuardarProducto(IDultimacategoria, texprod6.Text, texprecio6.Text);

                                MessageBox.Show("Nuevos platos agregados");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo 'Nueva Categoría' y los campos 'Nombre' y 'Precio' del primer producto no pueden estar vacíos. Por favor, selecciona una imagen primero.");
                    }
                }

                cargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CrearCategoriaDesdeBD(long categoriaId, string nombreCategoria)
        {
            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Fill;

            Label nuevoLabel = new Label();
            nuevoLabel.Text = nombreCategoria;
            nuevoLabel.AutoSize = true;
            nuevoLabel.Font = new Font("Roboto Bk", 10);

            PictureBox imagenPictureBox = new PictureBox();
            imagenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // Recuperar los bytes de la imagen desde la base de datos
            byte[] imagenBytes = ObtenerImagenDesdeBD(categoriaId);
            if (imagenBytes != null && imagenBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    imagenPictureBox.Image = System.Drawing.Image.FromStream(ms);
                }
            }

            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40));

            tableLayout.Controls.Add(imagenPictureBox, 0, 0);
            tableLayout.Name = categoriaId.ToString();
            tableLayout.Controls.Add(nuevoLabel, 0, 1);
            
           
                  

            tableLayout.MouseDown += new MouseEventHandler(panelRezisable_MouseDown);

            

            tableLayout.Location = new Point(5, panelPositionY);
            panelPositionY += tableLayout.Height + margin;

            panelCounter++;
        }

        private void panelRezisable_MouseDown(object sender, MouseEventArgs e)
        {
            TableLayoutPanel panel = sender as TableLayoutPanel;

            if (panel != null)
            {
                string categoriaId = panel.Name;
                //ventanaCategorias ven = new ventanaCategorias(categoriaId, 23);
                //ven.ShowDialog();
            }
        }
        private byte[] ObtenerImagenDesdeBD(long categoriaId)
        {
            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");
            string query = "SELECT Imagen FROM categoria WHERE ID = @CategoriaId;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                return (byte[])reader[0]; // Devuelve los bytes de la imagen
                            }
                        }
                    }
                }
            }

            return null; // Si no se encuentra la imagen, devuelve null
        }


        private void MostrarDatosDesdeBD()
        {
            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT ID, Nombre FROM categoria;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long categoriaId = Convert.ToInt64(reader["ID"]);
                                string nombreCategoria = reader["Nombre"].ToString();

                                CrearCategoriaDesdeBD(categoriaId, nombreCategoria);
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
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(precio))
            {
                return;
            }

            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");

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

                pcbAgregarImagen.Image = System.Drawing.Image.FromFile(rutaImagenSeleccionada);
                pcbAgregarImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        

        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }

        private void textBoxnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        
        
    }
}
