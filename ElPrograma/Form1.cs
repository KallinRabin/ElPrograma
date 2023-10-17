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
        


        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        
        string basedeDatos = "Proyecto";
        string contrasenia = "contrasena";
        public menuVertical()
        {
            this.WindowState = FormWindowState.Maximized;
                      
            InitializeComponent();
            Responsive();
            

            MySqlConnection conexion = new MySqlConnection($"Server=localhost; Database={basedeDatos}; Uid=root; Pwd={contrasenia};");


            
            conexion.Open();


            MySqlCommand comandos = new MySqlCommand();
            comandos.Connection = conexion;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimixar_Click(object sender, EventArgs e)
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

      public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            UC_Inicio uc = new UC_Inicio();
            addUserControl(uc);

        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            UC_Menu uc = new UC_Menu();
            addUserControl(uc);
        }
            
        private void btnGestion_Click(object sender, EventArgs e)
        {
            
            UC_Sesion uc = new UC_Sesion(this);
            addUserControl(uc);
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Ajustar(object sender, EventArgs e)
        {
            Responsive();
        }

        private void Responsive()
        {
            panelTitulo.Width = this.Width;
            //MessageBox.Show(Convert.ToString(this.Width) + "x" + Convert.ToString(this.Height));
            //MessageBox.Show(Convert.ToString(panelTitulo.Width) + "x" + Convert.ToString(panelTitulo.Height));
            pnlOpciones.Width = Convert.ToInt32(this.Width * 0.4);
        }

    }

}
