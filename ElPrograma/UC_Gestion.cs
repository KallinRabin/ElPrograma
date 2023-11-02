using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ElPrograma
{
    public partial class UC_Gestion : UserControl
    {
        private bool tituloAgregado = false;

        string basedeDatos = "Proyecto1";
        string contrasenia = "contrasena";
        public UC_Gestion()
        {
            InitializeComponent();

            // Configurar el Timer
            timer1 = new Timer();
            timer1.Interval = 1000; // Intervalo en milisegundos 
            timer1.Tick += new EventHandler(ActualizarGrafica);
            timer1.Start(); // Iniciar el Timer


        }

        private void btnModifcarMenu_Click(object sender, EventArgs e)
        {


            ModificarMenu modificarMenu = new ModificarMenu();
            modificarMenu.ShowDialog();

        }

        private void UC_Gestion_Load(object sender, EventArgs e)
        {

        }



        private void btnIngresos_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = $"Server=localhost;Database={basedeDatos};Uid=root;Pwd={contrasenia};";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Obtén la fecha actual en el formato adecuado (yyyy-MM-dd)
                    string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");

                    string query = $"SELECT SUM(total) AS total_general FROM pedidos WHERE fecha = '{fechaActual}'";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal totalGeneral = reader.GetDecimal("total_general");

                            MessageBox.Show($"Total del día {fechaActual}: {totalGeneral.ToString()}");
                        }
                        else
                        {
                            MessageBox.Show($"No se encontraron registros para el día {fechaActual}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + ex.Message);
            }
        }

        private void ActualizarGrafica(object sender, EventArgs e)
        {
            try
            {
                string connectionString = $"Server=localhost;Database={basedeDatos};Uid=root;Pwd={contrasenia};";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT DATE_FORMAT(fecha, '%Y-%m-%d') AS dia, SUM(total) AS total_dia " +
                        "FROM pedidos " +
                        "WHERE DATE_FORMAT(fecha, '%Y-%m') = DATE_FORMAT(CURDATE(), '%Y-%m') " +
                        "GROUP BY dia " +
                        "ORDER BY dia";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Limpia cualquier serie anterior en el gráfico
                        chart1.Series[0].Points.Clear(); // Limpiar los puntos en lugar de borrar la serie completa

                        // Establece el tipo de gráfico
                        chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                        // Deshabilita las etiquetas de datos dentro del gráfico de pastel
                        chart1.Series[0]["PieLabelStyle"] = "Disabled";

                        // Agregar nuevos puntos a la serie
                        foreach (DataRow row in dataTable.Rows)
                        {
                            DataPoint point = new DataPoint();
                            point.SetValueY(row.Field<decimal>("total_dia"));
                            point.AxisLabel = row["dia"].ToString();

                            // Agregar el punto al gráfico
                            chart1.Series[0].Points.Add(point);
                        }

                        // Si el título no se ha agregado, agrégalo
                        if (!tituloAgregado)
                        {
                            chart1.Titles.Add("Ganancias Diarias del Mes");
                            tituloAgregado = true;
                        }

                        // Personaliza el color de las barras
                        chart1.Series[0].Color = Color.Blue;

                        // Ajusta el ancho de las barras
                        chart1.Series[0]["PixelPointWidth"] = "10";

                        // Personaliza la paleta de colores
                        chart1.Palette = ChartColorPalette.SeaGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + ex.Message);
            }
        }

    }
    }



