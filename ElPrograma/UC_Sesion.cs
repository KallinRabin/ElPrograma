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

        string basedeDatos = "baseDatosProyecto";
        string contrasenia = "contrasenia";
        public UC_Sesion(menuVertical menuVertical)
        {
            InitializeComponent();

            // Configurar el campo de contraseña para mostrar caracteres de contraseña.
            txtContraseña.UseSystemPasswordChar = true;

            this.menuVertical = menuVertical;
        }

        // Función para realizar el acceso al sistema.
        private void realizarAcceso()
        {
            // Indicar que se está procesando el acceso.
            procesando = true;


            MySqlConnection conexion = new MySqlConnection($"Server=localhost; Database=proyecto; Uid=root; Pwd=;");

            conexion.Open();

            // Crear comandos de MySQL.
            MySqlCommand comandos = new MySqlCommand();
            comandos.Connection = conexion;

            // Consulta SQL para verificar la contraseña ingresada.
            string consulta = "Select Contraseña From usuarios where Contraseña ='" + txtContraseña.Text + "'";

            comandos.CommandText = consulta;
            MySqlDataReader datos = comandos.ExecuteReader();

            if (datos.Read())
            {
                // Si la consulta tiene resultados, muestra un mensaje de bienvenida.
                MessageBox.Show("Bienvenido");
                // Crea y muestra el formulario de gestión (UC_Gestion) en el menú vertical.
                UC_Gestion uC_Gestion = new UC_Gestion();
                menuVertical.addUserControl(uC_Gestion);

                // Oculta el formulario de inicio de sesión.
                this.Hide();
            }
            else
            {
                // Si la consulta no tiene resultados, muestra un mensaje de acceso denegado y limpia el campo de contraseña.
                MessageBox.Show("Acceso Denegado");
                txtContraseña.Clear(); 
            }

            // Indicar que el proceso ha finalizado.
            procesando = false;
        }

        // Evento que se dispara al hacer clic en el botón de iniciar sesión.
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            realizarAcceso();
        }
        // Evento que se dispara al presionar la tecla Enter en el campo de contraseña.
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Realiza el acceso al presionar Enter.
                realizarAcceso();
            }
        }
    }
    }


