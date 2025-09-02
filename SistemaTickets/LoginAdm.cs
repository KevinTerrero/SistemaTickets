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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SistemaTickets
{
    public partial class LoginAdm : Form
    {
        public int id;
        public string UserName;
        public int ID;
        public string Rol;
        bool flag = false;
        DateTime fecha = DateTime.Now;
        ConnectionClass con = new ConnectionClass();
        public LoginAdm()
        {
            
            InitializeComponent();

        }
        private void Clear(TextBox t)
        {
            t.Clear();
        }

        private void MostrarError(TextBox t)
        {
            t.Text = "Tiene que llenar este campo";
            t.ForeColor = System.Drawing.Color.Red;

        }

        public void UserValue()
        {
            Users users = new Users();
            ConnectionClass con = new ConnectionClass();
            string Password = "";
            string Nombre = "";
            string Apellido = "";
            bool Exists = false;
            string estatus = "";
            string Rol = "";
            string correo = userTxtBox.Text;
            UserName = correo;
            string password = passTxtBox.Text;

            if (passTxtBox.Text == "")
            {
                MostrarError(passTxtBox);
            }

            if (userTxtBox.Text == "")
            {
                userTxtBox.PasswordChar = '\0';
                MostrarError(userTxtBox);
            }

            con.OpenConection();
            SqlDataReader dr = con.DataReader("select * from Empleados where Correo= '" + correo + "'");
            if (dr.Read())
            {
                Password = dr.GetString(4);
                estatus = dr.GetString(8);
                Nombre = dr.GetString(1);
                Apellido = dr.GetString(2);
                Rol = dr.GetString(7);
                Exists = true;

            }
            if (Exists)
            {
                if (estatus == "Inactivo")
                {
                    MessageBox.Show("Este usuario está inactivo");
                }
                else if (estatus == "Activo")
                {
                    if (Rol == "Administrador")
                    {
                        MessageBox.Show("Bienvenido, " + Nombre + " " + Apellido);
                        DashboardAdm dashboardAdm = new DashboardAdm();
                        dashboardAdm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No tienes acceso a este sistema");
                    }

                }
            }
            else
            {
                MessageBox.Show("Ha introducido datos incorrectos");
                flag = true;
            }
            con.CloseConnection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            UserValue();
        }

        private void userTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag == true)
            {
                Clear(userTxtBox);
                Clear(passTxtBox);
                passTxtBox.ForeColor = Color.Black;
                userTxtBox.ForeColor = Color.Black;
                flag = false;
            }
        }

        private void passTxtBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag == true)
            {
                Clear(userTxtBox);
                Clear(passTxtBox);
                passTxtBox.ForeColor = Color.Black;
                userTxtBox.ForeColor = Color.Black;
                flag = false;
            }

        }
    }
}
