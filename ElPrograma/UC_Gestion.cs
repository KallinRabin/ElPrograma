using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElPrograma
{
    public partial class UC_Gestion : UserControl
    {
        Conexion conexion = new Conexion("admin");
        DataTable ConsultaOriginal;
        DataTable ConsultaActual;

        private int año;
        private int mes;

        public UC_Gestion()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.ShowUpDown = true;

            año = dateTimePicker1.Value.Year;
            mes = dateTimePicker1.Value.Month;

            GargarDatosOriginales();
            MostrarDatosEnDataGridView(ConsultaOriginal);

        }

        private void GargarDatosOriginales()
        {
            // Carga datos originales de la base de datos, filtrados por año y mes seleccionados.
            ConsultaOriginal = conexion.consultar($"SELECT P.Numero AS 'Número de Pedido', PL.Nombre AS 'Nombre del Plato', PP.Cantidad AS 'Cantidad', PL.Precio AS 'Precio Unitario', (PL.Precio * PP.Cantidad) AS 'Precio por Cantidad', P.Fecha as 'Fecha', F.Monto AS 'Total' FROM Pedidos AS P JOIN Pedidos_Platos AS PP ON P.Numero = PP.Numero_Pedido JOIN Platos AS PL ON PP.ID_Plato = PL.ID JOIN Factura AS F ON P.Numero = F.Número_Pedido WHERE YEAR(P.Fecha) = {año} AND MONTH(P.Fecha) = {mes}");
        }

        private void MostrarDatosEnDataGridView(DataTable data)
        {
            // Muestra el DataGridView
            dataGridView1.DataSource = data;
        }

        private void btnModifcarMenu_Click(object sender, EventArgs e)
        {
            ModificarMenu modificarMenu = new ModificarMenu();
            modificarMenu.ShowDialog();
        }


        private void btnGrafica_Click(object sender, EventArgs e)
        {
            Grafica grafica = new Grafica();
            grafica.ShowDialog();
        }

        private void btnMensual_Click(object sender, EventArgs e)
        {

            // Verifica si ya se están mostrando los datos mensuales
            if (ConsultaActual != ConsultaOriginal)
            {
                // Si ya se están mostrando los datos mensuales, vuelve a los datos originales
                ConsultaActual = ConsultaOriginal;
            }
            else
            {
                // Si no se están mostrando los datos mensuales, calcula la suma de ingresos mensuales
                // y actualiza ConsultaActual con los nuevos datos
                DataTable ConsultaMensual = conexion.consultar("SELECT YEAR(P.Fecha) AS 'Año', MONTH(P.Fecha) AS 'Mes', MONTHNAME(P.Fecha) AS 'Nombre del Mes', SUM(F.Monto) AS 'Total Mensual' FROM Pedidos AS P JOIN Factura AS F ON P.Numero = F.Número_Pedido GROUP BY MONTH(P.Fecha);");

                ConsultaActual = ConsultaMensual;
            }

            // Actualiza el DataGridView con los datos actuales
            dataGridView1.DataSource = ConsultaActual;

        }

       
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            // Actualisa el año seleccionado y el mes seleccionado cuando cambie el valor de DateTimePicker
            año = dateTimePicker1.Value.Year;
            mes = dateTimePicker1.Value.Month;

            // Recarga los datos originales con el filtrado actualizado.
            GargarDatosOriginales();

            // Muestra los datos filtrados en el DataGridView
            MostrarDatosEnDataGridView(ConsultaOriginal);
        }
    }
}
