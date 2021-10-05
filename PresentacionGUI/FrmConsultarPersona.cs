using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Logica;
namespace PresentacionGUI
{

    public partial class FrmConsultarPersona : Form
    {
        private static readonly PersonaService personaService = new PersonaService();
        public FrmConsultarPersona()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            
            var respuesta = personaService.Consultar();
            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                foreach (var item in respuesta.Personas)
                {
                    dgvTabla.Rows.Add(item.Identificacion,item.Nombre,item.Edad,item.Sexo,item.Pulsacion);
                }
            }
        }
    }
}
