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
    public partial class FrmGestionPersonacs : Form
    {
        public FrmGestionPersonacs()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.Identificacion = txtIdentificacion.Text;
            persona.Nombre = txtNombre.Text;
            persona.Edad =int.Parse( txtEdad.Text);
            persona.Sexo = cmbSexo.Text;
            persona.CalcularPulsacion();
            //txtPulsaciones.Text = persona.Pulsacion;
            PersonaService personaService = new PersonaService();
            string mensaje = personaService.Guarda(persona);
            MessageBox.Show(mensaje);
        }
    }
}
