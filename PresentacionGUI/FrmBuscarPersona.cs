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
    public partial class FrmBuscarPersona : Form
    {
        public FrmBuscarPersona()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            string identificacion = txtIdentificacion.Text;
            PersonaService personaService = new PersonaService();
           var(mensaje,personaBuscada) = personaService.Buscar(identificacion);
            if (mensaje.Equals($" Se encuentra Registrado {identificacion}"))
            {
                ActivarTabla(personaBuscada);
            }
            MessageBox.Show(mensaje);
            LimpiarTxtBox();
        }
        public void ActivarTabla(Persona personaBuscada)
        {
            dgvTabla.Visible = true;
            dgvTabla.Rows.Add(personaBuscada.Identificacion, personaBuscada.Nombre, personaBuscada.Edad, personaBuscada.Sexo, personaBuscada.Pulsacion);
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
            txtIdentificacion.Text="";
        }

     
    }
}
