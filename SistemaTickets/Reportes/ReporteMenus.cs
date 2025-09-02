using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SistemaTickets.Reportes
{
    public partial class ReporteMenus : Form
    {
        
        public ReporteMenus()
        {
            InitializeComponent();
            MostrarMenus();
            

        }

        private void MostrarMenus()
        {
            SqlConnection con = new SqlConnection(@"Data Source= MSI\SQLEXPRESS; Initial Catalog = SistemaTickets; Integrated Security = True");
            string query = "Select * From Historial_Menus";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Filtrar()
        {
            string TipoFiltro = tipoFiltro.Text; 
            if (string.IsNullOrEmpty(TipoFiltro))
            {
                MessageBox.Show("Debe de seleccionar un tipo de filtro");
            }
            else if (TipoFiltro == "ID")
            {
                try
                {
                    string id = filtroTxt.Text;
                    SqlConnection con = new SqlConnection(@"Data Source= MSI\SQLEXPRESS; Initial Catalog = SistemaTickets; Integrated Security = True");
                    string query = "select * from Historial_Menus where idHistorial = '" + id + "'";
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception)
                {

                    MessageBox.Show("Valor no encontrado");

                }
                
            }
            else if (TipoFiltro == "Fecha")
            {

                try
                {
                    DateTime fechaD = dateTimePicker1.Value;
                    string fecha = fechaD.ToString("MM/dd/yyyy");

                    SqlConnection con = new SqlConnection(@"Data Source= MSI\SQLEXPRESS; Initial Catalog = SistemaTickets; Integrated Security = True");
                    string query = "select * from Historial_Menus where Fecha = '" + fecha + "'";
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception)
                {

                    MessageBox.Show("Valor no encontrado");
                }
                
            }
            else if (TipoFiltro == "Tipo de Menú")
            {

                try
                {

                    string tipoMenu = filtroTxt.Text;
                    SqlConnection con = new SqlConnection(@"Data Source= MSI\SQLEXPRESS; Initial Catalog = SistemaTickets; Integrated Security = True");
                    string query = "select * from Historial_Menus where TipoMenu LIKE  " + "'%" + tipoMenu + "%'";
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Valor no encontrado");
                }

            }
        }

        private void GenerarReporte()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                string fechaHoy;
                DateTime fecha = DateTime.Now;
                fechaHoy = fecha.ToString("MM-dd-yyyy");
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (.pdf)|.pdf";
                save.FileName = "ReporteMenús " + fechaHoy;
                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)
                {

                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Hubo un error al escribir los datos en el disco" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value?.ToString());
                                }
                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                document.Open();
                                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                writer.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Se ha generado el reporte con exito", "info");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al exportar datos" + ex);
                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("No se encontro ningun registro", "Info");
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filtroBtn_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarMenus();
        }

        private void reporteBtn_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }
    }
}
