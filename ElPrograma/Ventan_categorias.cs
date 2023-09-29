using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElPrograma
{
    public partial class Ventan_categorias : Form
    {
        public Ventan_categorias(string IdCategoria)
        {
            InitializeComponent();

            string connectionString = "server=localhost;database=Proyecto;user=root;password=contrasena;";
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

            label3.Text = "Estas en la Categoria: " + valor;
            actualizarLista(IdCategoria);
        }

        private void actualizarLista(string idCategoria)
        {

            string connectionString = "server=localhost;database=Proyecto;user=root;password=contrasena;";
            string query = "SELECT * from platos where ID_Categoria = " + idCategoria + ";";



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (reader.Read())
                    {

                        string NombrePlato = reader["Nombre"].ToString();
                        string PrecioPlato = reader["Precio"].ToString();

                        dataGridView1.Rows.Add(NombrePlato, PrecioPlato);
                        //MessageBox.Show(valor);
                    }


                    reader.Close();

                }
            }


        }



    }
    
}
