using SistemaTickets.Admin;
using SistemaTickets.Reportes;
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
    public partial class DashboardAdm : Form
    {
        public DashboardAdm()
        {
            InitializeComponent();
            MostrarMenu();

        }
        private void MostrarMenu()
        {
            SqlConnection con = new SqlConnection(@"Data Source= MSI\SQLEXPRESS; Initial Catalog = SistemaTickets; Integrated Security = True");
            string query = "Select idMenu, TipoMenu, Descripcion, Fecha, FechaLimite, Cantidad From Menus";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void BorrarMenu()
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quiere borrar el menú de la semana?", "Eliminar",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK) 
            {
                SqlConnection conn = new SqlConnection();
                SqlConnection conn2 = new SqlConnection();
                conn.ConnectionString = @"Data Source=MSI\SQLEXPRESS; ;Initial Catalog=SistemaTickets;Integrated Security=True";
                conn2.ConnectionString = @"Data Source=MSI\SQLEXPRESS; ;Initial Catalog=SistemaTickets;Integrated Security=True";

                conn.Open();
                conn2.Open();

                string str = "DELETE FROM Menus";
                string str2 = "DELETE FROM Tickets";

                SqlCommand command = new SqlCommand(str);
                command.Connection = conn;
                int numero = command.ExecuteNonQuery(); 
                SqlCommand command2 = new SqlCommand(str2);
                command2.Connection = conn2;
                int numero2 = command2.ExecuteNonQuery();
                if (numero > 0 ) //condicionnal
                {
                    MessageBox.Show("Se han eliminado los menús");
                    MostrarMenu();
                }
                if (numero2 > 0 ) 
                {
                    MessageBox.Show("Se han elimitado los tickets");
                    MostrarMenu();
                }

                conn.Close();//para cerrar la conexion en la base de datos
            }

        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            BorrarMenu();
        }
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            MostrarMenu();  
        }
        private void CrearMenu_Click(object sender, EventArgs e)
        {
            AdmMenu admMenu = new AdmMenu();
            admMenu.Show();
        }
        private void ReportesEmpBtn(object sender, EventArgs e)
        {
            ReportesEmp reportes = new ReportesEmp();
            reportes.Show();
        }

        private void menúsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteMenus reporteMenus = new ReporteMenus();
            reporteMenus.Show();
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesTickets reportesTickets = new ReportesTickets();
            reportesTickets.Show();
        }

        private void penalizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesPen reportesPen = new ReportesPen();
            reportesPen.Show();
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GestionEmpleados gestion = new GestionEmpleados();
            gestion.Show();
        }

        private void ticketsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EdicionMenus edicion = new EdicionMenus();
            edicion.Show();
        }

        private void MenuDropDown_Click(object sender, EventArgs e)
        {
            AdmMenu admMenu = new AdmMenu();
            admMenu.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("Esta seguro de que desea salir de la aplicación?", "Log-Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (opcion == DialogResult.OK)
            {
                System.Windows.Forms.Application.Exit();
            }
            
        }

        private void ticketsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GestionTickets tickets = new GestionTickets();
            tickets.Show();
        }
    }
}
