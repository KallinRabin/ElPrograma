using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElPrograma
{
    public partial class Ventan_categorias : Form
    {
        string basedeDatos = "proyecto";
        string contrasenia = "";

        public int CategoriaSeleccionadaId { get; private set; }

        private int idCategoria; 


        public Ventan_categorias(string IdCategoria)
        {
            InitializeComponent();

            CategoriaSeleccionadaId = Convert.ToInt32(IdCategoria);

            txtNombreProd.KeyPress += new KeyPressEventHandler(txtNombreProd_KeyPress);
            txtPrecioProd.KeyPress += new KeyPressEventHandler(txtPrecioProd_KeyPress);

            dataGridView1.AutoGenerateColumns = true;

            string connectionString = ($"Server=localhost; Database=proyecto; Uid=root; Pwd=;");
            string query = "SELECT * from categoria where ID = " + IdCategoria + ";";

            string valor = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        valor = reader["nombre"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros en la base de datos.");
                    }

                    reader.Close();

                }
            }

            lblCategoria.Text = "Estas en la Categoria: " + valor;
            actualizarLista(IdCategoria);
        }

        private void actualizarLista(string idCategoria)
        {

            string connectionString = ($"Server=localhost; Database=proyecto; Uid=root; Pwd=;");
            string query = "SELECT ID, Nombre, Precio FROM platos WHERE ID_Categoria = " + idCategoria + " AND Disponible = 1;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string NombrePlato = reader["Nombre"].ToString();
                        string PrecioPlato = reader["Precio"].ToString();

                        DataGridViewRow fila = new DataGridViewRow();
                        fila.CreateCells(dataGridView1, NombrePlato, PrecioPlato);
                        fila.Tag = id; 
                        dataGridView1.Rows.Add(fila);
                    }

                    reader.Close();
                }
            }


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pcbRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                string nombreProducto = filaSeleccionada.Cells["Nombre"].Value.ToString();
                string precio = filaSeleccionada.Cells["Precio"].Value.ToString();

                txtNombreProd.Text = nombreProducto;
                txtPrecioProd.Text = precio;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila en el DataGridView.");
            }

        }

        private void btnAcetparModi_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string connectionString = ($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");

                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Tag);

                string nuevoNombre = txtNombreProd.Text;
                string nuevoPrecio = txtPrecioProd.Text;

                dataGridView1.SelectedRows[0].Cells["Nombre"].Value = nuevoNombre;
                dataGridView1.SelectedRows[0].Cells["Precio"].Value = nuevoPrecio;

                string consulta = $"UPDATE platos SET Nombre = @Nombre, Precio = @Precio WHERE ID = @ID";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(consulta, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nuevoNombre);
                        command.Parameters.AddWithValue("@Precio", nuevoPrecio);
                        command.Parameters.AddWithValue("@ID", id);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Datos actualizados correctamente en la base de datos.");

                txtNombreProd.Text = "";
                txtPrecioProd.Text = "";
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila en el DataGridView.");
            }
        }

        private void txtNombreProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtPrecioProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void agregarNuevoProducto(string nombre, string precio, int idCategoria)
        {
            string connectionString = $"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO platos (Nombre, Precio, ID_Categoria) VALUES (@Nombre, @Precio, @ID_Categoria);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Precio", precio);
                    command.Parameters.AddWithValue("@ID_Categoria", idCategoria);

                    command.ExecuteNonQuery();
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNombreProd.Text;
            string nuevoPrecio = txtPrecioProd.Text;

            // Validar que se hayan ingresado datos válidos
            if (string.IsNullOrWhiteSpace(nuevoNombre) || string.IsNullOrWhiteSpace(nuevoPrecio))
            {
                MessageBox.Show("Por favor, ingresa un nombre y un precio para el nuevo producto.");
                return;
            }

            
            agregarNuevoProducto(nuevoNombre, nuevoPrecio, CategoriaSeleccionadaId);

            
            actualizarLista(CategoriaSeleccionadaId.ToString());

            
            txtNombreProd.Text = "";
            txtPrecioProd.Text = "";

            MessageBox.Show("Nuevo producto agregado correctamente.");
        }
        private void eliminarProducto(int idProducto)
        {
            //MessageBox.Show("ID del producto a eliminar: " + idProducto); 

            string connectionString = $"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string query = $"UPDATE platos SET Disponible = 0 WHERE ID = @ID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", idProducto);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Producto deshabilitado correctamente."); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al deshabilitar el producto: " + ex.Message); 
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Botón de eliminar presionado.");

            if (dataGridView1.SelectedRows.Count > 0)
            {
               
                int idProducto = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                eliminarProducto(idProducto);

                    
                    actualizarLista(CategoriaSeleccionadaId.ToString());

                    MessageBox.Show("Producto deshabilitado correctamente.");
                
                
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila en el DataGridView.");
            }


        }

       
    }

}
