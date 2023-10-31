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
        // Declaración de variables miembro
        private int margin = 10;
        private int panelCounter = 0;
        private int panelHeight = 50;
        private int initialPanelPositionY = 10;
        private int panelPositionY = 10;
        private string rutaImagenSeleccionada = "";

        // Declaraciones para el arrastre de ventanas
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Constantes utilizadas para el arrastre de ventanas
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        // Variables de base de datos
        string basedeDatos = "baseDatosProyecto";
        string contrasenia = "contrasenia";

        public ModificarMenu()
        {
            InitializeComponent();

            // Asociar eventos KeyPress a las cajas de texto
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

            // Cargar categorías existentes en el constructor
            cargarCategorias();
        }

        // Función para el botón de cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Función para el botón de minimizar (no implementada)
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Función para permitir el arrastre de la ventana
        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Función para crear una nueva categoría
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

            nuevoPanel.Controls.Add(lblNombre);
            nuevoPanel.Controls.Add(Imagen);
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

        // Función para cargar y mostrar datos de las categorías
        private void cargarCategorias()
        {
            pnlCategorias.Controls.Clear();
            string connectionString = ($"Server=localhost; Database=proyecto; Uid=root; Pwd=;");

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                connection.Open();

                string query = "SELECT * from categoria;";

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

        private void btnCargar_Click(object sender, EventArgs e) {

             
            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");
            long IDultimacategoria = -1;
           
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    if (!string.IsNullOrWhiteSpace(txtNuevaCategoria.Text) && !string.IsNullOrWhiteSpace(texprod1.Text) && !string.IsNullOrWhiteSpace(texprecio1.Text) && rutaImagenSeleccionada != "")
                    {
                        string valor = txtNuevaCategoria.Text;
                        if (!string.IsNullOrWhiteSpace(valor))
                        {
                            

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
                        MessageBox.Show("El campo 'Nueva Categoría' y los campos 'Nombre' y 'Precio' del primer producto no pueden estar vacíos. Por favor, selecciona una imagen primero.");
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

            
            cargarCategorias();

        }


        // Función para crear una categoría basada en datos desde la base de datos
        private void CrearCategoriaDesdeBD(long categoriaId, string nombreCategoria)
        {
            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Fill;

            // Crear un Label con el nombre de la categoría.
            Label nuevoLabel = new Label();
            nuevoLabel.Text = nombreCategoria;
            nuevoLabel.AutoSize = true;
            nuevoLabel.Font = new Font("Roboto Bk", 10);

            // Crear un PictureBox para mostrar la imagen de la categoría.
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

            // Definir la estructura de columnas y filas del TableLayoutPanel.
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40));

            // Agregar el PictureBox con la imagen en la primera fila y el Label en la segunda fila.
            tableLayout.Controls.Add(imagenPictureBox, 0, 0);
            tableLayout.Name = categoriaId.ToString();
            tableLayout.Controls.Add(nuevoLabel, 0, 1);

            // Asociar un evento MouseDown al TableLayoutPanel para permitir interacción con la categoría.
            tableLayout.MouseDown += new MouseEventHandler(panelRezisable_MouseDown);

            // Establecer la posición y el espaciado del TableLayoutPanel en el formulario.
            tableLayout.Location = new Point(5, panelPositionY);
            panelPositionY += tableLayout.Height + margin;

            panelCounter++;
        }

        // Función para manejar el evento al hacer clic en una categoría desde la base de datos
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
        // Función para obtener una imagen desde la base de datos
        private byte[] ObtenerImagenDesdeBD(long categoriaId)
        {
            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");
            string query = "SELECT Imagen FROM categoria WHERE ID = @CategoriaId;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Establecer el parámetro @CategoriaId en la consulta SQL.
                    command.Parameters.AddWithValue("@CategoriaId", categoriaId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                // Devolver los bytes de la imagen desde la columna "Imagen" de la consulta.
                                return (byte[])reader[0]; // Devuelve los bytes de la imagen
                            }
                        }
                    }
                }
            }

            return null; // Si no se encuentra la imagen, devuelve null
        }

        // Función para mostrar datos de las categorías desde la base de datos
        private void MostrarDatosDesdeBD()
        {
            string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Definir una consulta SQL para seleccionar ID y Nombre de categorías.
                    string query = "SELECT ID, Nombre FROM categoria;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Obtener el ID y el nombre de cada categoría desde el resultado de la consulta.
                                long categoriaId = Convert.ToInt64(reader["ID"]);
                                string nombreCategoria = reader["Nombre"].ToString();

                                // Crear una representación visual de la categoría en la interfaz de usuario.
                                CrearCategoriaDesdeBD(categoriaId, nombreCategoria);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // En caso de error, mostrar un mensaje de error.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Función para guardar un producto en la base de datos
        private void GuardarProducto(long categoriaId, string nombre, string precio)
        {
            // Si el nombre o el precio están vacíos o nulos, se detiene la inserción.
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
                        // Asignar parámetros para la consulta de inserción.
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@ID_Categoria", categoriaId);

                        // Ejecutar la consulta de inserción en la base de datos.
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error que pueda ocurrir durante la inserción.
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void pcbRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Función para manejar el evento al hacer doble clic en el cuadro de imagen
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

        // Función para convertir una imagen en un array de bytes
        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }

        // Función para manejar el evento al hacer clic en el botón de maximizar
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }

        // Función para validar entrada de caracteres en el cuadro de texto (solo letras)
        private void textBoxnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Función para validar entrada de caracteres en el cuadro de texto (solo números y punto decimal)
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
