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

namespace SistemaTickets.Admin
{
    public partial class GestionTickets : Form
    {

        ConnectionClass con = new ConnectionClass();
        public GestionTickets()
        {
            InitializeComponent();
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
                    SqlDataReader dr = con.DataReader("select * from Tickets where idTicket='" + id + "'");
                    if (dr.Read())
                    {

                        string tipo = dr.GetString(3);
                        string razon = dr.GetString(9);
                        string estado = dr.GetString(6);

                        tipoMenu.Text = tipo;
                        razonTxtBox.Text = razon;
                        estadoTicket.Text = estado;
                    }
                    else
                    {
                        MessageBox.Show("Valor no encontrado");
                    }

                }
                catch (Exception ex)
                {
                    string exception = ex.ToString();
                    MessageBox.Show(exception);
                }
            }
        }

        private void Editar()
        {
            con.OpenConection();

            string id = idTxtBox.Text;
            string tipo = tipoMenu.Text;
            string razon = razonTxtBox.Text;
            string estado = estadoTicket.Text;  

            try
            {
                if (string.IsNullOrEmpty(razon))
                {
                    MessageBox.Show("Debe introducir una razón");
                }

                else
                {
                    con.OpenConection();
                    con.ExecuteQueries("update Tickets SET tipoMenu= '" + tipo + "', Razon = '" + razon + "', Estado = '" + estado + "' where idTicket = '" + idTxtBox.Text + "'");
                    con.CloseConnection();
                    MessageBox.Show("Ticket actualizado");

                }

            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                MessageBox.Show(exception);
            }
        }

        private void filtroBtn_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void editarBtn_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
