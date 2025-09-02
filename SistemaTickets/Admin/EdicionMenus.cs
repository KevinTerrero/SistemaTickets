using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xamarin.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace SistemaTickets.Admin
{
    public partial class EdicionMenus : Form
    {
        ConnectionClass con = new ConnectionClass();

        public EdicionMenus()
        {
            InitializeComponent();
        }

        private void Editar()
        {

            DateTime fechaD = Fecha.Value;
            string fecha = fechaD.ToString("MM/dd/yyyy");
            string diaSemana = fechaD.DayOfWeek.ToString();
            string sumaFecha = DateTime.Now.AddDays(+6).ToString("MM/dd/yyyy");
            string rango = DateTime.Now.ToString("MM/dd/yyyy") + " hasta " + sumaFecha.ToString();

            DateTime limiteD = limiteMenu.Value;
            string limite = limiteD.ToString("MM/dd/yyyy");

            string Tipo = tipoMenu.Text;
            string Descripcion = descripcionMenu.Text;

            try
            {
                con.OpenConection();
                con.ExecuteQueries("update Menus SET TipoMenu='" + diaSemana + " " +Tipo + "', Descripcion= '" + Descripcion + "', Dia='" + diaSemana + "', Fecha= '" + fecha +
                    "', FechaLimite= '" + limite + "' where idMenu = '" + idTxtBox.Text + "'");

                con.ExecuteQueries("update Historial_Menus SET TipoMenu='" + diaSemana + " " + Tipo + "', Descripcion= '" + Descripcion + "', Dia='" + diaSemana + "', Fecha= '" + fecha +
                    "', FechaLimite= '" + limite + "', Rango='" + rango +"' where idHistorial = '" + idTxtBox.Text + "'");

                MessageBox.Show("Operación realizada con éxito");
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                MessageBox.Show(exception);
            }

        }
        private void Filtrar()
        {
            if (string.IsNullOrEmpty(idTxtBox.Text))
            {
                MessageBox.Show("Debe completar el campo");
            }
            else
            {
                try
                {
                    
                    int id = Convert.ToInt32(idTxtBox.Text);
                    con.OpenConection();
                    SqlDataReader dr = con.DataReader("select * from Menus where idMenu='" + id + "'");
                    if (dr.Read())
                    {
                        string tipo = dr.GetString(1);
                        string descripcion= dr.GetString(2);
                        string fecha = dr.GetString(4);
                        string fechalim = dr.GetString(5);

                        int i = tipo.IndexOf(" ") + 1;
                        string tipo2 = tipo.Substring(i);

                        var cultureInfo = new CultureInfo("en-US");


                        tipoMenu.Text = tipo2;
                        descripcionMenu.Text = descripcion;
                        DateTime parsedDate = DateTime.ParseExact(fecha, "MM/dd/yyyy", null);
                        Fecha.Value = parsedDate;
                        DateTime parsedDate2 = DateTime.ParseExact(fechalim, "MM/dd/yyyy", null);
                        limiteMenu.Value = parsedDate2;

                    }
                    else
                    {
                        MessageBox.Show("Valor no encontrado");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha habido un error");
                }
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

        private void editarBtn_Click(object sender, EventArgs e)
        {
                if (string.IsNullOrEmpty(descripcionMenu.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (string.IsNullOrEmpty(tipoMenu.Text))
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else
            {
                Editar();

            }
        }

        private void idTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tipoMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void descripcionMenu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void limiteMenu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Fecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
