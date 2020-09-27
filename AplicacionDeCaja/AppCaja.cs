using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionDeCaja
{
    public partial class AppCaja : Form
    {
        public AppCaja()
        {
            InitializeComponent();
        }

        private void AppCaja_Load(object sender, EventArgs e)
        {
            #region * Color Fondo del Mdi
            MdiClient oMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    oMDI = (MdiClient)ctl;
                    oMDI.BackColor = Color.CadetBlue;
                }
                catch (InvalidCastException exc)
                {
                }
            }
            #endregion

        }

        private void AppCaja_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            using(Inicio inicio = new Inicio())
            {
                inicio.ShowDialog();
            }
        }
    }
}
