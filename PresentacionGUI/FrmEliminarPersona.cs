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
    public partial class FrmEliminarPersona : Form
    {
        public FrmEliminarPersona()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Visualizar();
        }
        public void Visualizar()
        {
            Persona persona = new Persona();
            string identificacion = txtIdentificacion.Text;
            PersonaService personaService = new PersonaService();
            var (mensaje, personaEliminada) = personaService.Eliminar(identificacion);
            if (mensaje.Equals($"Se Eliminó el registro de la persona con identificacion {identificacion}"))
            {
                ActivarTabla(personaEliminada);
            }
            MessageBox.Show(mensaje);
            LimpiarTxtBox();
        }
        public void ActivarTabla(Persona personaEliminada)
        {
            dgvTabla.Visible = true;
            dgvTabla.Rows.Add(personaEliminada.Identificacion,personaEliminada.Nombre, personaEliminada.Edad,personaEliminada.Sexo,personaEliminada.Pulsacion);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTxtBox();
            dgvTabla.Visible = false;
        }

        public void LimpiarTxtBox()
        {
            txtIdentificacion.Text ="";
        }
    }
}
