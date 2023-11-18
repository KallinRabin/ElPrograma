using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private Conexion Conexion;

        public ModificarMenu()
        {
            InitializeComponent();
            this.Conexion = new Conexion("admin");

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

       
        private void DarDeBajaCategoria(string categoriaId)
        {

            try
            {
                // Lógica para dar de baja la categoría en la base de datos y el programa
                Conexion.actualizar($"UPDATE categoria SET disponible = 0 WHERE ID = '{categoriaId}'");
                Conexion.actualizar($"UPDATE platos SET disponible = 0 WHERE ID_Categoria = '{categoriaId}'");

                MessageBox.Show("La categoría y sus platos han sido dadas de baja exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja la categoría: " + ex.Message);
            }

            // Vuelve a cargar las categorías después de dar de baja.
            cargarCategorias();

        }

        // Función para cargar y mostrar datos de las categorías
        private void cargarCategorias()
        {

            pnlCategorias.Controls.Clear();

            try
            {
                // Utilizar la instancia de Conexion para realizar la consulta
                DataTable categoriasTable = Conexion.consultar("SELECT * FROM categoria WHERE disponible = 1;");

                foreach (DataRow row in categoriasTable.Rows)
                {
                    byte[] imagenBytes = (byte[])row["Imagen"];
                    string nombreCategoria = row["Nombre"].ToString();
                    string idCategoria = row["ID"].ToString();

                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                        CrearCategoria(nombreCategoria, imagen, idCategoria);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }

        }

        private void btnCargar_Click(object sender, EventArgs e) 
        {

            long IDultimacategoria = -1;

            try
            {
                // Utilizar la instancia existente de Conexion para realizar la inserción
                using (MySqlConnection conexionBD = Conexion.conexion)
                {
                    conexionBD.Open();

                    if (!string.IsNullOrWhiteSpace(txtNuevaCategoria.Text) && !string.IsNullOrWhiteSpace(texprod1.Text) && !string.IsNullOrWhiteSpace(texprecio1.Text) && rutaImagenSeleccionada != "")
                    {
                        string valor = txtNuevaCategoria.Text;
                        if (!string.IsNullOrWhiteSpace(valor))
                        {
                            byte[] imagenBytes = ImageToByteArray(pcbAgregarImagen.Image);
                            pcbAgregarImagen.Image = null;

                            string insertQuery = "INSERT INTO categoria (Nombre, Imagen, Disponible) VALUES (@Nombre, @Imagen, 1);";

                            using (MySqlCommand cmd = new MySqlCommand(insertQuery, conexionBD))
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

                    txtNuevaCategoria.Clear();
                    texprod1.Clear();
                    texprod2.Clear();
                    texprod3.Clear();
                    texprod4.Clear();
                    texprod5.Clear();
                    texprod6.Clear();
                    texprecio1.Clear();
                    texprecio2.Clear();
                    texprecio3.Clear();
                    texprecio4.Clear();
                    texprecio5.Clear();
                    texprecio6.Clear();
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

            string query = "SELECT Imagen FROM categoria WHERE ID = @CategoriaId;";

            using (MySqlCommand command = new MySqlCommand(query, Conexion.conexion))
            {
                // Establecer el parámetro @CategoriaId en la consulta SQL.
                command.Parameters.AddWithValue("@CategoriaId", categoriaId);

                try
                {
                    Conexion.conexion.Open();

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
                catch (Exception ex)
                {
                    // Manejar cualquier error que pueda ocurrir durante la consulta.
                    MessageBox.Show($"Error al obtener imagen desde la base de datos: {ex.Message}");
                }
                finally
                {
                    Conexion.conexion.Close();
                }
            }

            return null;

        }


        // Función para guardar un producto en la base de datos
        private void GuardarProducto(long categoriaId, string nombre, string precio)
        {
            try
            {
                // Si el nombre o el precio están vacíos o nulos, se detiene la inserción.
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(precio))
                {
                    return;
                }

                // Validar que el nombre solo contenga letras y espacios
                if (!nombre.All(char.IsLetterOrDigit) && !nombre.Any(char.IsWhiteSpace))
                {
                    MessageBox.Show("El nombre solo puede contener letras y espacios.");
                    return;
                }

                byte[] imagenBytes = ImageToByteArray(pcbAgregarImagen.Image);

                // Utilizar la instancia de Conexion para realizar la inserción
                Conexion.insertar($"INSERT INTO platos (Nombre, Precio, ID_Categoria, Disponible) VALUES ('{nombre}', '{precio}', '{categoriaId}', 1)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar producto: " + ex.Message);
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
            if (image == null)
            {
                // Si la imagen es nula, devolver un array de bytes vacío o manejar el caso según tus necesidades.
                return new byte[0];
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }



        // Función para validar entrada de caracteres en el cuadro de texto (solo letras)
        private void textBoxnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
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
