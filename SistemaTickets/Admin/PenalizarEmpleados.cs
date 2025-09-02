using System;
using System.CodeDom;
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

namespace SistemaTickets.Admin
{
    public partial class PenalizarEmpleados : Form
    {
        ConnectionClass con = new ConnectionClass();
        public PenalizarEmpleados()
        {
            InitializeComponent();
        }

        private void Penalizar()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source= MSI\SQLEXPRESS ;Initial Catalog=SistemaTickets;Integrated Security=True";
            conn.Open();

            DateTime fechaD = dateTimePicker1.Value;
            string fecha = fechaD.ToString("MM/dd/yyyy");

            string idEmpleado = idTxtBox.Text;
            string Penalizado = "Si";
            string motivo = razonTxtBox.Text; 
            DateTime fechaPenalizacionD = DateTime.Now;
            string fechaPenalizacion = fechaPenalizacionD.ToString("MM/dd/yyyy");


            string str = "INSERT Penalizaciones(idEmpleado, estaPenalizado, Motivo, FechaPenalizacion, Vencimiento) " +
                "VALUES(@IDEmpleado, @EstaPenalizado, @motivo, @FechaPenalizacion, @vencimiento)";

            SqlCommand command = new SqlCommand(str);
            command.Parameters.AddWithValue("@IDEmpleado", idEmpleado);
            command.Parameters.AddWithValue("@EstaPenalizado", Penalizado);
            command.Parameters.AddWithValue("@motivo", motivo);
            command.Parameters.AddWithValue("@FechaPenalizacion", fechaPenalizacion);
            command.Parameters.AddWithValue("@vencimiento", fecha);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void penalizarBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
