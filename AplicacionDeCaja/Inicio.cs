using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionDeCaja
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            this.ActiveControl = LogUsuario;
            LogUsuario.Focus();
        }

        private void AppCaja_Load(object sender, EventArgs e)
        {
           
        }
        private void LogUsuario_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogContraseña.Focus();
            }
        }
        private void LogUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInicio.PerformClick();
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (LogUsuario.Text == "Ylen" && LogContraseña.Text == "hola")
            {
                this.Hide();
                using (AppCaja appCaja = new AppCaja())
                {
                    appCaja.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Intentelo de nuevo!!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
