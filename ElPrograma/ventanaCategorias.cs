using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElPrograma
{
    public partial class ventanaCategorias : Form
    {
        

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        string texto;
        public ventanaCategorias(string idCategoria, int numero)
        {
            
            InitializeComponent();

            string connectionString = "server=localhost;database=baseDatosMomentaria;user=root;password=contrasenia;";
            string query = "SELECT * from categoria where ID = "+ idCategoria + ";";

            string valor="";

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

            this.texto = valor;
            lblCategoria.Text = "Estas en la Categoria: "+valor;
            actualizarLista(idCategoria);
        }
    
        private void actualizarLista (string idCategoria ){

            string connectionString = "server=localhost;database=baseDatosMomentaria;user=root;password=contrasenia;";
            string query = "SELECT * from platos where ID_Categoria = " + idCategoria + ";";

            string valor = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    dgvProductos.Rows.Clear();
                    while (reader.Read())
                    {
                        
                        string NombrePlato = reader["Nombre"].ToString();
                        string PrecioPlato = reader["Precio"].ToString();
                        
                        dgvProductos.Rows.Add(NombrePlato, PrecioPlato);
                        //MessageBox.Show(valor);
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

       

      
        
    }
}
