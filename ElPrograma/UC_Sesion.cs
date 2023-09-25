using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ElPrograma
{
    public partial class UC_Sesion : UserControl
    {
        menuVertical menuVertical;

        private bool procesoRealizado = false;

        private bool procesando = false;

        public UC_Sesion(menuVertical menuVertical)
        {
            InitializeComponent();

            txtContraseña.UseSystemPasswordChar = true;

            this.menuVertical = menuVertical;
        }
        

        private void realizarAcceso()
        {

            procesando = true;

            MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=Basedatos; Uid=root; Pwd=contrasena;");

           // MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=baseDato; Uid=root; Pwd=contrasenia;");

            conexion.Open();

            MySqlCommand comandos = new MySqlCommand();
            comandos.Connection = conexion;

            string consulta = "Select Contraseña From Usuario where Contraseña ='" + txtContraseña.Text + "'";

            comandos.CommandText = consulta;
            MySqlDataReader datos = comandos.ExecuteReader();

            if (datos.Read())
            {
                MessageBox.Show("Bienvenido");
                UC_Gestion uC_Gestion = new UC_Gestion();
                menuVertical.addUserControl(uC_Gestion);

                this.Hide();
            }
            else
            {
                MessageBox.Show("Acceso Denegado");
                txtContraseña.Clear(); 
            }

            procesando = false;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            realizarAcceso();
        }
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                realizarAcceso();
            }
        }
    }
    }


