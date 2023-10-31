using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace ElPrograma
{
    internal class Conexion
    {

        MySqlConnection conexionBD = new MySqlConnection("Server=localhost; Database=proyecto; Uid=root; Pwd=");
        
        public DataTable consultar(string sql)
        {
            DataTable tabla = new DataTable();

            try
            {
                conexionBD.Open();

                MySqlCommand consulta = new MySqlCommand(sql, conexionBD);

                MySqlDataAdapter adaptador = new MySqlDataAdapter();
                adaptador.SelectCommand = consulta; //Obtiene retorno de datos
                adaptador.Fill(tabla);

                conexionBD.Close();
                return tabla;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al actualizar: " + ex.ToString());
                return tabla;
            }
        }

        public void insertar(string sql)
        {
            conexionBD.Open();

            MySqlCommand consulta = new MySqlCommand(sql, conexionBD);
            consulta.ExecuteNonQuery(); //Sin retorno de datos

            conexionBD.Close();
        }

      
    }
}
