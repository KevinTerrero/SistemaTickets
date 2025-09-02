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
using System.Web;
using System.Windows.Forms;
using Xamarin.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SistemaTickets.Admin
{
    public partial class GestionEmpleados : Form
    {
        ConnectionClass con = new ConnectionClass();
        public GestionEmpleados()
        {
            InitializeComponent();
        }

        private void Filtrar()
        {
            try
            {
                if (string.IsNullOrEmpty(idTxtBox.Text))
                {
                    MessageBox.Show("Debe completar el campo");
                }
                else
                {
                    int id = Convert.ToInt32(idTxtBox.Text);
                    con.OpenConection();
                    SqlDataReader dr = con.DataReader("select * from Empleados where idEmpleado='" + id + "'");
                    if (dr.Read())
                    {

                        string Nombre = dr.GetString(1);
                        string Apellidos = dr.GetString(2);
                        string Correo = dr.GetString(3);
                        string Departamento = dr.GetString(5);
                        string Cliente = dr.GetString(6);
                        string Rol = dr.GetString(7);
                        string Estado = dr.GetString(8);
                        string Observaciones = dr.GetString(9);

                        nombreTxtBox.Text = Nombre;
                        apellidosTxtBox.Text = Apellidos;
                        correoTxtBox.Text = Correo;
                        departamentoTxTBox.Text = Departamento;
                        clienteTxtBox.Text = Cliente;
                        rolCombo.Text = Rol;
                        estadoCombo.Text = Estado;
                        razonTxtBox.Text = Observaciones;


                    }
                    else
                    {
                        MessageBox.Show("Valor no encontrado");
                    }

                }
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                MessageBox.Show(exception);

            }
        }

        private void Editar()
        {


            string Rol = rolCombo.Text;
            string Estado = estadoCombo.Text;
            try
            {
                
                con.OpenConection();
                con.ExecuteQueries("update Empleados SET Rol='" + Rol + "', Estado= '" + Estado + "' where idEmpleado = '" + idTxtBox.Text + "'");

                MessageBox.Show("Operación realizada con éxito");
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                MessageBox.Show(exception);
            }
        }

        private void Penalizar()
        {
            int id = Convert.ToInt32(idTxtBox.Text);
            string Rol = rolCombo.Text;
            string Razon = razonTxtBox.Text;
            string Penalizado = estadoCombo.Text;
            string si = "Si";
            DateTime fechaD = dateTimePicker1.Value;
            string fecha = fechaD.ToString("MM/dd/yyyy");

            DateTime FechaHoyD = DateTime.Now;
            string FechaHoy = FechaHoyD.ToString("MM/dd/yyyy");
            con.OpenConection();
            SqlDataReader dr = con.DataReader("select * from Penalizaciones where idEmpleado='" + idTxtBox.Text + "'");

            try
            {
                if (string.IsNullOrEmpty(Razon))
                {
                    MessageBox.Show("Debe introducir una razón");
                }
                else if (dr.Read())
                {
                    con.OpenConection();
                    con.ExecuteQueries("update Penalizaciones SET Motivo= '" + Razon + "', Vencimiento = '" + fecha + "', Penalizado = '" + si + "' where idEmpleado = '" + idTxtBox.Text + "'");
                    con.ExecuteQueries("update Empleados SET razonPenalizacion= '" + Razon + "', VencimientoPenalizacion = '" + fecha + "', Estado = '" + Penalizado + "' where idEmpleado = '" + idTxtBox.Text + "'");

                    MessageBox.Show("Penalizacion actualizada");
                }
                else
                {
                    con.OpenConection();
                    con.ExecuteQueries("update Empleados SET razonPenalizacion= '" + Razon + "', VencimientoPenalizacion = '" + fecha + "', Estado = '" + Penalizado + "' where idEmpleado = '" + idTxtBox.Text + "'");

                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = @"Data Source= MSI\SQLEXPRESS ;Initial Catalog=SistemaTickets;Integrated Security=True";
                    conn.Open();
                    string str = "INSERT Penalizaciones(idEmpleado, Penalizado, Motivo, FechaPenalizacion, Vencimiento) " +
                        "VALUES(@IDEmpleado, @estaPenalizado, @motivo, @fechaPenalizacion, @vencimiento)";

                    SqlCommand command2 = new SqlCommand(str);
                    command2.Parameters.AddWithValue("@IDEmpleado", id);
                    command2.Parameters.AddWithValue("@estaPenalizado", "Si");
                    command2.Parameters.AddWithValue("@motivo", Razon);
                    command2.Parameters.AddWithValue("@fechaPenalizacion", FechaHoy);
                    command2.Parameters.AddWithValue("@vencimiento", fecha);

                    command2.Connection = conn;
                    int numero = command2.ExecuteNonQuery();
                    if (numero > 0)
                    {
                        MessageBox.Show("Empleado penalizado");
                    }
                    conn.Close();
                }
                
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                MessageBox.Show(exception);
            }
        }

        private void penalizarBtn_Click(object sender, EventArgs e)
        {
            Penalizar();
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
                Editar();
        }
    }
}
