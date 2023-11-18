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

        private Conexion Conexion;

        public int CategoriaSeleccionadaId { get; private set; }

        private int idCategoria;


        public Ventan_categorias(string IdCategoria)
        {
            InitializeComponent();

            CategoriaSeleccionadaId = Convert.ToInt32(IdCategoria);

            txtNombreProd.KeyPress += new KeyPressEventHandler(txtNombreProd_KeyPress);
            txtPrecioProd.KeyPress += new KeyPressEventHandler(txtPrecioProd_KeyPress);

            Conexion = new Conexion("admin");

            dataGridView1.AutoGenerateColumns = true;

            string query = "SELECT * from categoria where ID = " + IdCategoria + ";";

            //string valor = "";
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            string valor = ObtenerNombreCategoria(IdCategoria);
            lblCategoria.Text = "Estás en la Categoría: " + valor;
            actualizarLista(IdCategoria);
        }

        private string ObtenerNombreCategoria(string idCategoria)
        {
            string sql = $"SELECT nombre FROM categoria WHERE ID = {idCategoria}";
            DataTable result = Conexion.consultar(sql);

            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["nombre"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontraron registros en la base de datos.");
                return string.Empty;
            }
        }

        private void actualizarLista(string idCategoria)
        {

            string sql = $"SELECT ID, Nombre, Precio FROM platos WHERE ID_Categoria = {idCategoria} AND Disponible = 1";
            DataTable result = Conexion.consultar(sql);

            dataGridView1.Rows.Clear();

            foreach (DataRow row in result.Rows)
            {
                int id = Convert.ToInt32(row["ID"]);
                string nombrePlato = row["Nombre"].ToString();
                string precioPlato = row["Precio"].ToString();

                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1, nombrePlato, precioPlato);
                fila.Tag = id;
                dataGridView1.Rows.Add(fila);
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                if (filaSeleccionada.Cells["Nombre"].Value != null)
                {
                    string nombreProducto = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    txtNombreProd.Text = nombreProducto;
                }
                else
                {
                    txtNombreProd.Text = string.Empty; // O asigna otro valor predeterminado
                }

                if (filaSeleccionada.Cells["Precio"].Value != null)
                {
                    string precio = filaSeleccionada.Cells["Precio"].Value.ToString();
                    txtPrecioProd.Text = precio;
                }
                else
                {
                    txtPrecioProd.Text = string.Empty; // O asigna otro valor predeterminado
                }
            }

        }
        
        private void btnAcetparModi_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Tag);
                string nuevoNombre = txtNombreProd.Text;
                string nuevoPrecio = txtPrecioProd.Text;

                dataGridView1.SelectedRows[0].Cells["Nombre"].Value = nuevoNombre;
                dataGridView1.SelectedRows[0].Cells["Precio"].Value = nuevoPrecio;

                string consulta = "UPDATE platos SET Nombre = @Nombre, Precio = @Precio WHERE ID = @ID";

                try
                {
                    Conexion.conexion.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(consulta, Conexion.conexion);

                    sqlCommand.Parameters.AddWithValue("@Nombre", nuevoNombre);
                    sqlCommand.Parameters.AddWithValue("@Precio", nuevoPrecio);
                    sqlCommand.Parameters.AddWithValue("@ID", id);

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    MessageBox.Show($"Error al actualizar: {ex.Message}");
                }
                finally
                {
                    if (Conexion.conexion.State == ConnectionState.Open)
                    {
                        Conexion.conexion.Close();
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
            string nuevoNombre = txtNombreProd.Text;
            string nuevoPrecio = txtPrecioProd.Text;

            try
            {
                // Verificar que se hayan ingresado datos válidos
                if (string.IsNullOrWhiteSpace(nuevoNombre) || string.IsNullOrWhiteSpace(nuevoPrecio))
                {
                    MessageBox.Show("Por favor, ingresa un nombre y un precio para el nuevo producto.");
                    return;
                }

                string consulta = "INSERT INTO platos (Nombre, Precio, ID_Categoria, Disponible) VALUES (@Nombre, @Precio, @ID_Categoria, 1)";

                MySqlCommand sqlCommand = new MySqlCommand(consulta, Conexion.conexion);

                sqlCommand.Parameters.AddWithValue("@Nombre", txtNombreProd);
                sqlCommand.Parameters.AddWithValue("@Precio", txtPrecioProd);
                sqlCommand.Parameters.AddWithValue("@ID_Categoria", CategoriaSeleccionadaId);

                // Abre y cierra la conexión automáticamente debido al using
                Conexion.conexion.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Error al agregar nuevo producto: {ex.Message}");
            }
            finally
            {
                if (Conexion.conexion.State == ConnectionState.Open)
                {
                    Conexion.conexion.Close();
                }
            }

            // Actualizar la lista después de agregar el nuevo producto
            actualizarLista(CategoriaSeleccionadaId.ToString());

            // Limpiar los campos de entrada
            txtNombreProd.Text = "";
            txtPrecioProd.Text = "";

            MessageBox.Show("Nuevo producto agregado correctamente.");

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevoNombre = txtNombreProd.Text;
                string nuevoPrecio = txtPrecioProd.Text;

                // Validar que se hayan ingresado datos válidos
                if (string.IsNullOrWhiteSpace(nuevoNombre) || string.IsNullOrWhiteSpace(nuevoPrecio))
                {
                    MessageBox.Show("Por favor, ingresa un nombre y un precio para el nuevo producto.");
                    return;
                }

                // Verificar si ya existe un producto con el mismo nombre pero está dado de baja
                int idExistente = ObtenerIdProductoDadoDeBajaPorNombre(nuevoNombre);

                if (idExistente != -1)
                {
                    // Preguntar al usuario si desea reactivar el producto existente
                    DialogResult result = MessageBox.Show("Ya existe un producto con el mismo nombre pero está dado de baja. ¿Deseas reactivarlo?",
                                                          "Producto Existente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Reactivar el producto existente
                        ReactivarProducto(idExistente);
                    }
                    else
                    {
                        return; // Si el usuario elige no reactivar, salir del método
                    }
                }
                else
                {
                    // Insertar un nuevo producto
                    InsertarNuevoProducto(nuevoNombre, nuevoPrecio);
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Error al agregar nuevo producto: {ex.Message}");
            }
            finally
            {
                if (Conexion.conexion.State == ConnectionState.Open)
                {
                    Conexion.conexion.Close();
                }
            }

            // Actualizar la lista después de agregar el nuevo producto o reactivar el existente
            actualizarLista(CategoriaSeleccionadaId.ToString());

            // Limpiar los campos de entrada
            txtNombreProd.Text = "";
            txtPrecioProd.Text = "";

            MessageBox.Show("Nuevo producto agregado correctamente.");
        }

        private int ObtenerIdProductoDadoDeBajaPorNombre(string nombre)
        {
            string sql = $"SELECT ID FROM platos WHERE Nombre = '{nombre}' AND Disponible = 0";
            DataTable result = Conexion.consultar(sql);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["ID"]);
            }

            return -1; // Retorna -1 si no se encuentra un producto dado de baja con el mismo nombre
        }

        private void ReactivarProducto(int idProducto)
        {
            // Lógica para reactivar el producto
            string consulta = $"UPDATE platos SET Disponible = 1 WHERE ID = @ID";

            try
            {
                // Utiliza la instancia existente de la clase Conexion
                Conexion.conexion.Open();
                MySqlCommand sqlCommand = new MySqlCommand(consulta, Conexion.conexion);
                sqlCommand.Parameters.AddWithValue("@ID", idProducto);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw new Exception($"Error al reactivar el producto: {ex.Message}");
            }
            finally
            {
                if (Conexion.conexion.State == ConnectionState.Open)
                {
                    Conexion.conexion.Close();
                }
            }
        }

        private void InsertarNuevoProducto(string nuevoNombre, string nuevoPrecio)
        {
            try
            {
                string consulta = "INSERT INTO platos (Nombre, Precio, ID_Categoria, Disponible) VALUES (@Nombre, @Precio, @ID_Categoria, 1)";

                MySqlCommand sqlCommand = new MySqlCommand(consulta, Conexion.conexion);

                sqlCommand.Parameters.AddWithValue("@Nombre", nuevoNombre);
                sqlCommand.Parameters.AddWithValue("@Precio", nuevoPrecio);
                sqlCommand.Parameters.AddWithValue("@ID_Categoria", CategoriaSeleccionadaId);

                // Abre y cierra la conexión automáticamente debido al using
                Conexion.conexion.Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                MessageBox.Show($"Error al agregar nuevo producto: {ex.Message}");
            }
            finally
            {
                if (Conexion.conexion.State == ConnectionState.Open)
                {
                    Conexion.conexion.Close();
                }
            }
        }

        private void eliminarProducto(int idProducto)
        {

            // Lógica para deshabilitar el producto
            string consulta = $"UPDATE platos SET Disponible = 0 WHERE ID = @ID";

            try
            {
                // Utiliza la instancia existente de la clase Conexion
                Conexion.conexion.Open();
                MySqlCommand sqlCommand = new MySqlCommand(consulta, Conexion.conexion);
                sqlCommand.Parameters.AddWithValue("@ID", idProducto);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw new Exception($"Error al deshabilitar el producto: {ex.Message}");
            }
            finally
            {
                if (Conexion.conexion.State == ConnectionState.Open)
                {
                    Conexion.conexion.Close();
                }
            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int idProducto = Convert.ToInt32(filaSeleccionada.Tag);

                // Llama a la función para deshabilitar el producto utilizando la clase Conexion
                eliminarProducto(idProducto);

                // Actualiza la lista después de deshabilitar el producto
                actualizarLista(CategoriaSeleccionadaId.ToString());

                MessageBox.Show("Producto deshabilitado correctamente." );
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila de la table.");
            }

        }


    }

}

