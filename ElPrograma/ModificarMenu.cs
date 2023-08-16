using Google.Protobuf.WellKnownTypes;
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

        private void btnCargar_Click(object sender, EventArgs e)
        {

            string connectionString = "server=localhost;database=baseDato;user=root;password=contrasena;";
            long IDultimacategoria=-1;
            //creo una conexion 
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open(); //abro la conexion

                    //Seleccionamos los atributos de categoria y pedimos que los llene el usuario 
                    string insertQuery = "INSERT INTO `categoria` (`Nombre`) VALUES ('" + txtNuevaCategoria.Text + "');";  
                    //inserta los datos en la BD
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conexion))
                    {
                     
                        int rowsAffected = cmd.ExecuteNonQuery();

                        //pide la ultima ID agregada
                        IDultimacategoria = cmd.LastInsertedId;
                        

                        MessageBox.Show($"Nueva categoria agregada");
                    }
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Error: " + ex.Message);
                }            
                conexion.Close(); //cerramos la base de datos 

            }
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
 
                    if (IDultimacategoria != -1)
                    {
                        string insertQuery = "INSERT INTO `platos`(`Nombre`,`Descripcion`, `Precio`, `ID_Categoria`) VALUES ('" + texprod1.Text + "','hola'," + texprecio1.Text + "," + IDultimacategoria + "); ";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conexion))
                        {

                            int rowsAffected = cmd.ExecuteNonQuery();

                            MessageBox.Show($"Nuevo plato agregado ");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                conexion.Close();

            }
        }   
    }
}
