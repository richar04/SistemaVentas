using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;

namespace Views
{
    public partial class vLogin : Form
    {
        public vLogin()
        {
            InitializeComponent();
            this.txtUsuario.Focus();

        }

        private void vLogin_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Focus();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = EmpleadoController.Login(this.txtUsuario.Text,this.txtPassword.Text);
            //evaluar si existe el usuario
            if (Datos.Rows.Count==0)
            {
                MessageBox.Show("Usuario y/o Contraseña Incorrectos.", "Morcos Bikes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                vPrincipal view = new vPrincipal();
                view.IdEmpleado = Datos.Rows[0][0].ToString();
                view.Apeynom = Datos.Rows[0][1].ToString();
                view.Acceso = Datos.Rows[0][2].ToString();

                view.Show();
                this.Hide();
            }

        }
    }
}
