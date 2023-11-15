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
        Conexion conexion = new Conexion();

        public UC_Gestion()
        {
            InitializeComponent();

            DataTable Consulta = conexion.consultar("SELECT P.Numero AS 'Número de Pedido', PL.Nombre AS 'Nombre del Plato', PP.Cantidad AS 'Cantidad', PL.Precio AS 'Precio Unitario', (PL.Precio * PP.Cantidad) AS 'Precio por Cantidad', P.Fecha as 'Fecha', F.Monto AS 'Total' FROM Pedidos AS P JOIN Pedidos_Platos AS PP ON P.Numero = PP.Numero_Pedido JOIN Platos AS PL ON PP.ID_Plato = PL.ID JOIN Factura AS F ON P.Numero = F.Número_Pedido");

            dtgvcomidas.DataSource = Consulta;

            
        }

        private void btnModifcarMenu_Click(object sender, EventArgs e)
        {
            ModificarMenu modificarMenu = new ModificarMenu();
            modificarMenu.ShowDialog(); 

        }


        private void UC_Gestion_Load(object sender, EventArgs e)
        {


        }

      
        

    }
}
