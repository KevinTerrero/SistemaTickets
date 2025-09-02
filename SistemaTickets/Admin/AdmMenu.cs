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

namespace SistemaTickets
{
    public partial class AdmMenu : Form
    {
        ConnectionClass con = new ConnectionClass();

        public AdmMenu()
        {
            InitializeComponent();
        }

        private void Insertar()
        {

            DateTime fechaD = diaMenu.Value;
            string fecha = fechaD.ToString("MM/dd/yyyy");
            string diaSemana = fechaD.DayOfWeek.ToString();
            string sumaFecha = DateTime.Now.AddDays(+6).ToString("MM/dd/yyyy");
            string rango = DateTime.Now.ToString("MM/dd/yyyy") + " hasta " + sumaFecha.ToString();

            DateTime limiteD = limiteMenu.Value;
            string limite = limiteD.ToString("MM/dd/yyyy");

            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source= MSI\SQLEXPRESS ;Initial Catalog=SistemaTickets;Integrated Security=True";
                conn.Open();

                string str = "INSERT Menus(TipoMenu, Dia, Fecha, Descripcion, FechaLimite, Cantidad) " +
                    "VALUES(@tipoMenu, @dia, @fecha, @descripcion, @fechaLim, @Cantidad)";

                SqlCommand command = new SqlCommand(str);
                command.Parameters.AddWithValue("@tipoMenu", diaSemana + " " + tipoMenu.Text);
                command.Parameters.AddWithValue("@dia", diaSemana);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@descripcion", descripcionMenu.Text);
                command.Parameters.AddWithValue("@fechaLim", limite);
                command.Parameters.AddWithValue("@Cantidad", 0);

                string str2 = "INSERT Historial_Menus(TipoMenu, Dia, Fecha, Descripcion, FechaLimite, Rango, Cantidad) " +
                    "VALUES(@tipoMenu, @dia, @fecha, @descripcion, @fechaLim, @rango, @Cantidad)";

                SqlCommand command2 = new SqlCommand(str2);
                command2.Parameters.AddWithValue("@tipoMenu", diaSemana + " " + tipoMenu.Text);
                command2.Parameters.AddWithValue("@dia", diaSemana);
                command2.Parameters.AddWithValue("@fecha", fecha);
                command2.Parameters.AddWithValue("@descripcion", descripcionMenu.Text);
                command2.Parameters.AddWithValue("@fechaLim", limite);
                command2.Parameters.AddWithValue("@rango", rango);
                command2.Parameters.AddWithValue("@Cantidad", 0);


                command.Connection = conn;
                command2.Connection = conn;
                int numero = command.ExecuteNonQuery();
                int numero2 = command2.ExecuteNonQuery();
                if (numero > 0 & numero2 > 0) 
                {
                    MessageBox.Show("La operación se ha completado con éxito");
                }
                conn.Close();

            }
            catch (Exception ex)
            {

                string exception = ex.ToString();
                MessageBox.Show(exception);

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
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
                Insertar();

            }
        }

    }
}
