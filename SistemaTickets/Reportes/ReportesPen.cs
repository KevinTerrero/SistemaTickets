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

namespace SistemaTickets
{
    public partial class ReportesPen : Form
    {
        public ReportesPen()
        {
            InitializeComponent();
            MostrarPenalizaciones();
        }

        private void Filtrar()
        {
            string TipoFiltro = tipoFiltro.Text;
            if (string.IsNullOrEmpty(TipoFiltro))
            {
                MessageBox.Show("Debe de seleccionar un tipo de filtro");
            }
            if (TipoFiltro == "Activo")
            {

                try
                {
                    string Activo = "Si";
                    SqlConnection con = new SqlConnection(@"Data Source= MSI\SQLEXPRESS; Initial Catalog = SistemaTickets; Integrated Security = True");
                    string query = "select * from Penalizaciones where Penalizado =" + "'" + Activo + "'";
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
            else if (TipoFiltro == "Inactivo")
            {

                try
                {
                    string Inactivo = "No";
                    SqlConnection con = new SqlConnection(@"Data Source= MSI\SQLEXPRESS; Initial Catalog = SistemaTickets; Integrated Security = True");
                    string query = "select * from Empleados where Penalizado =" + "'" + Inactivo + "'";
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
        private void MostrarPenalizaciones()
        {
            SqlConnection con = new SqlConnection(@"Data Source= MSI\SQLEXPRESS; Initial Catalog = SistemaTickets; Integrated Security = True");
            string query = "Select * From Penalizaciones";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
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
                save.FileName = "ReportePenalizaciones " + fechaHoy;
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
            MostrarPenalizaciones();
        }

        private void reporteBtn_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }
    }
}
