﻿using System;
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
            
        }

        private void UC_Gestion_Load(object sender, EventArgs e)
        {

        }
    }
}
