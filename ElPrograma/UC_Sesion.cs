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
    public partial class UC_Sesion : UserControl
    {
        menuVertical menuVertical; 
        public UC_Sesion(menuVertical menuVertical)
        {
            InitializeComponent();
            
            this.menuVertical = menuVertical;   
        }


        


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=baseDato; Uid=root; Pwd=contrasena;");
            conexion.Open();

            MySqlCommand comandos = new MySqlCommand();
            comandos.Connection = conexion;

            string consulta = "Select Contraseña From Usuarios where Contraseña ='" + txtContraseña.Text + "'";

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
            }
        }


    }
}
