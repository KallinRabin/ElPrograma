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
    public partial class UC_Inicio : UserControl
    {
        public UC_Inicio()
        {
            InitializeComponent();
         

            // Llamamos al método para actualizar la hora y la fecha al inicio del formulario
            ActualizarHoraYFecha();

            timer_Inicio.Start();
        }


        private void timer_Inicio_Tick(object sender, EventArgs e)
        {
            // Cada vez que el temporizador hace tick, actualizamos la hora y la fecha
            ActualizarHoraYFecha();
        }
        private void ActualizarHoraYFecha()
        {
            // Obtener la hora y la fecha actuales
            DateTime ahora = DateTime.Now;

            // Formatear la hora y la fecha como cadena
            string horaYFecha = ahora.ToString("HH:mm:ss - dd/MM/yyyy");

            // Mostrar la cadena en el label
            lbl_Hora_Inicio.Text = horaYFecha;
        }

      
    }
}
