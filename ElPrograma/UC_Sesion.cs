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
        private menuVertical menuVertical;
        private Conexion conexion;

        private bool procesando = false;

        public UC_Sesion(menuVertical menuVertical)
        {
            InitializeComponent();

            // Configurar el campo de contraseña para mostrar caracteres de contraseña.
            txtContraseña.UseSystemPasswordChar = true;

            this.menuVertical = menuVertical;
            this.conexion = new Conexion("empleado"); // Initialize the Conexion class
        }

        private void realizarAcceso()
        {
            // Indicar que se está procesando el acceso.
            procesando = true;

            try
            {
                // Use the Conexion class for database operations
                DataTable resultado = conexion.consultar($"SELECT CONTRASEÑA FROM USUARIOS WHERE CONTRASEÑA ='{txtContraseña.Text}'");

                // Check if the entered password matches the expected one
                if (resultado.Rows.Count > 0 && txtContraseña.Text == "LaTuerca2024")
                {
                    // If the query has results and the password matches, show a welcome message.
                    MessageBox.Show("Bienvenido");

                    // Create and show the management form (UC_Gestion) in the vertical menu.
                    UC_Gestion uC_Gestion = new UC_Gestion();
                    menuVertical.addUserControl(uC_Gestion);

                    // Hide the login form.
                    this.Hide();
                }
                else
                {
                    // If the query has no results or the password doesn't match, show an access denied message and clear the password field.
                    MessageBox.Show("Acceso Denegado.");
                    txtContraseña.Clear();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Indicar que el proceso ha finalizado.
                procesando = false;
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            realizarAcceso();
        }

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
