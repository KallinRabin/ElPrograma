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
    public partial class UC_Gestion : UserControl
    {
        public UC_Gestion()
        {
            InitializeComponent();
        }

        private void btnModifcarMenu_Click(object sender, EventArgs e)
        {
                
            
            ModificarMenu modificarMenu = new ModificarMenu();
            modificarMenu.ShowDialog(); 

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Asegúrate de que haya al menos una fila seleccionada
            if (dtgvcomidas.SelectedRows.Count > 0)
            {
                // Obtén la fila seleccionada
                DataGridViewRow row = dtgvcomidas.SelectedRows[0];

                // Elimina la fila
                dtgvcomidas.Rows.Remove(row);
            }
        }

        private void UC_Gestion_Load(object sender, EventArgs e)
        {

        }

        private void btnEnviar2_Click(object sender, EventArgs e)
        {
           
        }

        private void pruebad_Click(object sender, EventArgs e)
        {
            string nombrea = nomprueba.Text;
            string precioa = precprueba.Text;

            // Crear una nueva fila
            DataGridViewRow fila = new DataGridViewRow();

            // Agregar celdas de nombre y precio
            fila.Cells.Add(new DataGridViewTextBoxCell { Value = nombrea });
            fila.Cells.Add(new DataGridViewTextBoxCell { Value = precioa });

            // Agregar la fila al DataGridView
            dtgvcomidas.Rows.Add(fila);

            // Limpiar los TextBox después de agregar los datos
            nomprueba.Clear();
            precprueba.Clear();
        }
    }
    }

