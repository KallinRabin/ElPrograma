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
using System.Windows.Forms.DataVisualization.Charting;

namespace ElPrograma
{
    public partial class Grafica : Form
    {
        private bool tituloAgregado = false;
        private Conexion conexion;
        private string nombreMes;

        public Grafica()
        {
            InitializeComponent();
            conexion = new Conexion("admin");

            timer1 = new Timer();
            timer1.Interval = 1000; // Intervalo en milisegundos 
            timer1.Tick += new EventHandler(ActualizarGrafica);
            timer1.Start(); // Iniciar el Timer

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);

            // Inicializar nombreMes con el mes actual
            nombreMes = DateTime.Now.ToString("MMMM");

        }

        private void ActualizarGrafica(object sender, EventArgs e)
        {

            try
            {
                using (MySqlConnection connection = conexion.conexion)
                {
                    connection.Open();

                    // Obtener el primer día y el último día del mes seleccionado
                    DateTime primerDiaDelMes = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1);
                    DateTime ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

                    string query = "SELECT DATE_FORMAT(p.Fecha, '%Y-%m-%d') AS dia, COALESCE(SUM(f.Monto), 0) AS total_dia FROM Pedidos p LEFT JOIN Factura f ON p.Numero = f.Número_Pedido WHERE p.Fecha BETWEEN @PrimerDia AND @UltimoDia GROUP BY dia ORDER BY dia";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        // Pasar parámetros para filtrar por el mes seleccionado
                        command.Parameters.AddWithValue("@PrimerDia", primerDiaDelMes);
                        command.Parameters.AddWithValue("@UltimoDia", ultimoDiaDelMes);

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Limpia cualquier serie anterior en el gráfico
                        chart1.Series[0].Points.Clear();

                        // Establece el tipo de gráfico
                        chart1.Series[0].ChartType = SeriesChartType.Pie;

                        // Agregar nuevos puntos a la serie
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string fecha = row["dia"].ToString();
                            decimal totalDia = row.Field<decimal>("total_dia");

                            DataPoint point = new DataPoint();
                            point.SetValueY(totalDia);
                            point.Label = $"{fecha}\n${totalDia}"; // Agrega la fecha y el total al etiquetado

                            // Agregar el punto al gráfico
                            chart1.Series[0].Points.Add(point);
                        }

                        // Si el título no se ha agregado, agrégalo
                        if (!tituloAgregado)
                        {
                            chart1.Titles.Add($"Ingresos Diarios - {nombreMes}");
                            tituloAgregado = true;
                        }

                        // Personaliza la paleta de colores
                        chart1.Palette = ChartColorPalette.Bright;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + ex.Message);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            nombreMes = dateTimePicker1.Value.ToString("MMMM");

            ActualizarGrafica(sender, e);

            if (tituloAgregado)
            {
                chart1.Titles.Clear(); // Elimina títulos anteriores
                chart1.Titles.Add($"Ingresos Diarios - {nombreMes}");
            }

        }

    }
}