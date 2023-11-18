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

            public MySqlConnection conexion;

            public Conexion(string tipo)
            {
                if (tipo.Equals("admin"))
                {
                    conexion = new MySqlConnection("Server=localhost; Database=proyecto; Uid=adminLaTuerca; Pwd=LaTuerca2023;");
                }
                else if (tipo.Equals("empleado"))
                {
                    conexion = new MySqlConnection("Server=localhost; Database=proyecto; Uid=empleado; Pwd=empleado;");
                }
            }

            public DataTable consultar(string sql)
            {
                DataTable tabla = new DataTable();

                try
                {
                    conexion.Open();

                    MySqlCommand consulta = new MySqlCommand(sql, conexion);

                    MySqlDataAdapter adaptador = new MySqlDataAdapter();
                    adaptador.SelectCommand = consulta; //Obtiene retorno de datos
                    adaptador.Fill(tabla);

                    conexion.Close();
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
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand(sql, conexion);
                consulta.ExecuteNonQuery(); //Sin retorno de datos
                conexion.Close();
            }

            public void actualizar(string sql)
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand(sql, conexion);
                consulta.ExecuteNonQuery();
                conexion.Close();
            }

        }
    }


