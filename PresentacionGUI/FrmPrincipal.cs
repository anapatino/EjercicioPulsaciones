using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionGUI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmGestionPersonacs().Show();
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmEliminarPersona().Show(); ;
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConsultarPersona().Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmBuscarPersona().Show(); ;
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmModificarPersona().Show(); ;
        }
    }
}
