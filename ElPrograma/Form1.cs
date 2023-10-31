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
    public partial class menuVertical : Form
    {


        // Declaraciones de métodos externos para el arrastre de ventanas
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Constantes utilizadas para el arrastre de ventanas
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        // Variables para la base de datos
        string basedeDatos = "proyecto";
        string contrasenia = "";
        public menuVertical()
        {
                      
            InitializeComponent();
           
            

           MySqlConnection conexion = new MySqlConnection($"Server=localhost; Database=proyecto; Uid=root; Pwd=;");
            conexion.Open();
            MySqlCommand comandos = new MySqlCommand();
            comandos.Connection = conexion;


        }

        // Evento para cerrar la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Evento para minimizar la ventana (en desuso)
        private void btnMinimixar_Click(object sender, EventArgs e)
        {
           
        }

        // Evento de arrastre del panel de título para mover la ventana
        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Función para cambiar el control de usuario mostrado en el panel de contenido
        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(userControl);
            userControl.BringToFront();

        }

        // Mostrar el control de usuario "UC_Inicio" en el panel de contenido
        private void btnIniciar_Click(object sender, EventArgs e)
        {

            UC_Inicio uc = new UC_Inicio();
            addUserControl(uc);

        }

        // Mostrar el control de usuario "UC_Menu" en el panel de contenido
        private void btnMenu_Click(object sender, EventArgs e)
        {
            UC_Menu uc = new UC_Menu();
            addUserControl(uc);
        }

        // Mostrar el control de usuario "UC_Sesion" en el panel de contenido
        private void btnGestion_Click(object sender, EventArgs e)
        {
            
            UC_Sesion uc = new UC_Sesion(this);
            addUserControl(uc);
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }


       

    }

}
