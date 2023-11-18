using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ElPrograma
{
    public partial class UC_Menu : UserControl
    {
        Conexion Conexion = new Conexion("empleado");
        int PnlProductosX = 8;
        int PnlProductosY = 27;
        CheckBox checkPlatos = new CheckBox();
        int id;
        int cantidad;
        string nombre;
        int precio;
        int btnCount = 0;

        public UC_Menu()
        {
            InitializeComponent();

            // Crear un comando SQL para seleccionar datos de la tabla 'categoria' con ciertas condiciones
            DataTable Categorias = Conexion.consultar("SELECT ID,Nombre, Imagen, Disponible FROM categoria where Disponible=1;");

            int PanelPosicionY = 0;
            int PanelPosicionX = 0;

            // Reiterar a través de las filas del DataTable 'dt', que contiene información de categorías
            foreach (DataRow dr in Categorias.Rows)
            {

                // Crear un nuevo Panel para mostrar información de la categoría
                Panel panel_categoria = new Panel();
                panel_categoria.Width = 570;
                panel_categoria.Location = new Point(PanelPosicionX, PanelPosicionY);
                panel_categoria.Height = 90;
                panel_categoria.BackColor = System.Drawing.Color.White;
                panel_categoria.AutoScroll = true;

                // Crear una etiqueta para mostrar el nombre de la categoría
                Label Nombre_Categoria = new Label();
                Nombre_Categoria.Text = dr["Nombre"].ToString();
                Nombre_Categoria.Font = new System.Drawing.Font("Roboto Bk", 15);
                panel_categoria.Controls.Add(Nombre_Categoria);

                // Crear un PictureBox para mostrar una imagen de la categoría
                PictureBox Picture = new PictureBox();
                int ancho = 40;
                int alto = 60;
                MemoryStream transferencia = new MemoryStream((byte[])dr["Imagen"]);
                Bitmap foto = new Bitmap(transferencia);
                ancho = Convert.ToInt32(foto.Width * alto / foto.Height);
                Picture.Width = ancho;
                Picture.Height = alto;
                Picture.Image = foto;
                Picture.SizeMode = PictureBoxSizeMode.StretchImage;
                Picture.Location = new Point(0, 20);
                panel_categoria.Controls.Add(Picture);

                // Agregar el panel de categoría al formulario
                panel_menu.Controls.Add(panel_categoria);

                // Actualizar la posición Y para la siguiente categoría
                PanelPosicionY += 120;

                // Realizar una nueva consulta para obtener los platos de esta categoría
                DataTable Platos = Conexion.consultar("SELECT  ID, Nombre, Precio, Disponible FROM  Platos where Disponible=1 and ID_Categoria =" + dr["ID"] + " ORDER BY Nombre ASC;");

                int btn_PosicionX = 10;
                int btn_PosicionY = 100;

                // Iterar a través de las filas del DataTable 'dt2', que contiene información de platos
                foreach (DataRow dataRow in Platos.Rows)
                {
                    // Crear un botón para representar un plato
                    Button btn_platos = new Button();
                    btn_platos.Width = 80;
                    btn_platos.Height = 50;
                    btn_platos.Location = new Point(btn_PosicionX, btn_PosicionY);

                    // Obtener el ID, nombre y precio del plato
                    id = Convert.ToInt32(dataRow["ID"]);
                    nombre = dataRow["Nombre"].ToString();
                    precio = Convert.ToInt32(dataRow["Precio"]);

                    // Configurar el texto y etiqueta del botón
                    btn_platos.Text = nombre;

                    // Almacenar información adicional en el Tag del botón para su procesamiento posterior
                    btn_platos.Tag = new { ID = id, Nombre = nombre, Precio = precio };

                    // Asociar un evento Click al botón
                    btn_platos.Click += Button_Click;

                  

                    // Actualizar la posición X para el siguiente botón de plato
                    btn_PosicionX += 70;
                    btn_PosicionX += 20;

                    panel_categoria.Controls.Add(btn_platos);


                }

            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            dynamic producto = btn.Tag;

            int idPlato = producto.ID;

            checkPlatos = pnlProductos.Controls.OfType<CheckBox>().FirstOrDefault(chk => (int)chk.Tag == idPlato);

            if (checkPlatos == null)
            {
                // Crear una nueva casilla de verificación (CheckBox) para representar un plato
                CheckBox checkPlatos = new CheckBox();
                checkPlatos.Width = 200;
                checkPlatos.Height = 55;
                checkPlatos.Location = new Point(8, PnlProductosY);
                checkPlatos.BackColor = Color.White;
                checkPlatos.BringToFront();
                checkPlatos.Tag = producto.ID;

                // Crear una etiqueta para mostrar el nombre del plato
                Label lblNombre = new Label();
                lblNombre.Width = 280;
                lblNombre.Text = "Nombre: " + producto.Nombre;
                lblNombre.Location = new Point(17, 10);

                // Crear una etiqueta para mostrar el precio del plato
                Label lblPrecio = new Label();
                lblPrecio.Text = "Precio: $" + producto.Precio.ToString();
                lblPrecio.Location = new Point(17, 33);


                TextBox cantidadTextBox = new TextBox();
                cantidadTextBox.Name = "cantidadTextBox_" + idPlato; // Asignar un nombre único
                cantidadTextBox.Text = "1"; // Establecer el valor por defecto
                cantidadTextBox.Location = new Point(130, 30);
                cantidadTextBox.Width = 40;
                cantidadTextBox.KeyPress += CantidadTextBox_KeyPress; // Asociar un evento KeyPress


                // Agregar la casilla de verificación, etiquetas y cuadro de texto al panel de productos
                pnlProductos.Controls.Add(checkPlatos);
                checkPlatos.Controls.Add(lblNombre);
                checkPlatos.Controls.Add(lblPrecio);
                checkPlatos.Controls.Add(cantidadTextBox);


                // Establecer el valor vertical del panel de productos en 0 (posición inicial)
                pnlProductos.VerticalScroll.Value = 0;//Fix error de posicion de paneles

                // Actualizar la posición vertical para el siguiente conjunto de elementos
                PnlProductosY += 70;

            }

        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {

            // Check if there are no CheckBoxes in pnlProductos
            if (pnlProductos.Controls.OfType<CheckBox>().Count() == 0)
            {
                MessageBox.Show("No se han seleccionado platos para enviar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtB_NumMesa.Text))
            {
                MessageBox.Show("Debe ingresar el número de mesa antes de enviar el pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int NumeroMesa = Convert.ToInt32(txtB_NumMesa.Text);
            string fechaPedido = DateTime.Now.ToString("yyyy/MM/dd");
            Conexion.insertar("INSERT INTO Pedidos (Fecha, NumeroMesa) VALUES ('" + fechaPedido + "', " + NumeroMesa + ")");
            DataTable NumeroPedidos = Conexion.consultar("SELECT MAX(Numero) FROM Pedidos");
            int numeroPedido = 0;

            if (NumeroPedidos.Rows.Count > 0)
            {
                numeroPedido = Convert.ToInt32(NumeroPedidos.Rows[0]["MAX(Numero)"]);


                // Initialize the total price of the order
                int totalPedido = 0;

                // Iterate through the CheckBoxes within pnlProductos
                foreach (Control control in pnlProductos.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        // Get the ID of the Plato from the CheckBox's Tag
                        int idPlato = (int)checkBox.Tag;

                        // Find the TextBox associated with this CheckBox by name
                        TextBox cantidadTextBox = (TextBox)pnlProductos.Controls.Find("cantidadTextBox_" + idPlato, true).FirstOrDefault();

                        if (cantidadTextBox != null)
                        {
                            // Get the quantity entered in the TextBox
                            int cantidad = int.Parse(cantidadTextBox.Text);

                            // Retrieve the price of the Plato from the database
                            DataTable precioPlato = Conexion.consultar($"SELECT Precio FROM Platos WHERE ID = {idPlato}");

                            if (precioPlato.Rows.Count > 0)
                            {
                                int precioUnitario = Convert.ToInt32(precioPlato.Rows[0]["Precio"]);
                                totalPedido += precioUnitario * cantidad;

                            }

                            // Insert a record in the Pedidos_Platos table
                            Conexion.insertar("INSERT INTO Pedidos_Platos (Numero_Pedido, ID_Plato, Cantidad) " + $"VALUES ({numeroPedido}, {idPlato}, {cantidad})");


                        }
                    }
                }


                // Insert the total price, order number, and invoice number into the factura table
                Conexion.insertar($"INSERT INTO Factura (Número_Pedido, Monto) " +
                                 $"VALUES ({numeroPedido}, {totalPedido})");

                // Clear the CheckBoxes and associated controls within pnlProductos
                pnlProductos.Controls.Clear();

                // Reset PnlProductosY
                PnlProductosY = 27;

                txtB_NumMesa.Clear();

              

                GenerarPDFUltimoPedido(numeroPedido, Convert.ToDateTime(fechaPedido), NumeroMesa);
                ImprimirPDFEnImpresoraPos("UltimoPedidoTemp.pdf");
                MostrarPDF("UltimoPedidoTemp.pdf");
               
              
                
                
            }
            else
            {
                MessageBox.Show("Error al obtener el número de pedido. Los platos no se han enviado.");
            }

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            // Reitera a través de todos los controles dentro del panel 'pnlProductos'
            foreach (Control control in pnlProductos.Controls)
            {
                // Verificar si el control actual es una casilla de verificación (CheckBox)
                if (control is CheckBox)
                {

                    // Convertir el control actual en una casilla de verificación (CheckBox)
                    CheckBox checkBox = (CheckBox)control;

                    // Si la casilla de verificación está marcada (seleccionada)
                    if (checkBox.Checked)
                    {
                        // Eliminar el control (casilla de verificación) del panel 'pnlProductos'
                        pnlProductos.Controls.Remove(control);
                    }
                }
            }
        }

        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void GenerarPDFUltimoPedido(int numeroPedido, DateTime fechaPedido, int numeroMesa)
        {

            // Crear un documento PDF
            Document doc = new Document();

            // Especificar la ubicación y el nombre del archivo PDF temporal
            string pdfFilePath = "UltimoPedidoTemp.pdf";
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));

            doc.Open();

            // Agregar título
            Paragraph title = new Paragraph("Detalle del pedido: " + numeroPedido);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // Agregar el número de mesa
            Paragraph mesa = new Paragraph("Número de mesa: " + numeroMesa);
            doc.Add(mesa);

            // Agregar la fecha del pedido
            Paragraph fecha = new Paragraph("Fecha del pedido: " + fechaPedido.ToString("yyyy-MM-dd"));
            doc.Add(fecha);

            // Obtener los platos del último pedido en orden de cantidad
            DataTable platosPedido = Conexion.consultar($"SELECT p.Nombre AS NombrePlato, pp.Cantidad, p.Precio FROM Pedidos_Platos pp INNER JOIN Platos p ON pp.ID_Plato = p.ID WHERE pp.Numero_Pedido = {numeroPedido} ORDER BY pp.Cantidad DESC");

            // Crear una tabla para mostrar los detalles
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.AddCell("Nombre del Plato");
            table.AddCell("Cantidad");
            table.AddCell("Precio Unitario");
            table.AddCell("Precio Total");

            decimal total = 0;

            foreach (DataRow row in platosPedido.Rows)
            {
                string nombrePlato = row["NombrePlato"].ToString();
                int cantidad = Convert.ToInt32(row["Cantidad"]);
                decimal precioUnitario = Convert.ToDecimal(row["Precio"]);
                decimal precioTotal = cantidad * precioUnitario;

                table.AddCell(nombrePlato);
                table.AddCell(cantidad.ToString());
                table.AddCell(precioUnitario.ToString("C")); // Formato de moneda
                table.AddCell(precioTotal.ToString("C")); // Formato de moneda

                total += precioTotal;
            }

            doc.Add(table);

            // Agregar el total
            doc.Add(new Paragraph($"Total: {total.ToString("C")}")); // Formato de moneda

            doc.Add(new Paragraph("Este documento no es oficial. Debe pasar por la caja para realizar los pagos necesarios"));

            doc.Close();

            
            

        }

        private void ImprimirPDFEnImpresoraPos(string filePath)
        {
            try
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = "NobreDeImpresora"; // Reemplaza con el nombre de tu impresora POS
                printDocument.PrinterSettings.PrintToFile = true;
                printDocument.PrinterSettings.PrintFileName = filePath;
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir el PDF: " + ex.Message);
            }
        }

        private void MostrarPDF(string filePath)
        {
            try
            {
                // Abre el archivo PDF con la aplicación predeterminada para archivos PDF
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el archivo PDF: " + ex.Message);
            }
        }

    }

}