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
            MapearDatos();
        }
        public void MapearDatos()
        { 
            Persona persona = new Persona();
            persona.Identificacion = txtIdentificacion.Text;
            persona.Nombre = txtNombre.Text;
            persona.Edad = int.Parse(txtEdad.Text);
            persona.Sexo = cmbSexo.Text;
            persona.FechaNacimiento=dateTimePicker1.Value;
            persona.CalcularPulsacion();
            ActivarComponente();
            txtPulsaciones.Text = persona.Pulsacion.ToString();
            PersonaService personaService = new PersonaService();
            string mensaje = personaService.Guarda(persona);
            MessageBox.Show(mensaje);
            LimpiarTextoBox();
        }
        private void LimpiarTextoBox()
        {
            txtIdentificacion.Text="";
            txtNombre.Text = "";
            txtEdad.Text = "";
            cmbSexo.Text = null;
            txtPulsaciones.Text = "";
            lbPulsaciones.Visible = false;
            txtPulsaciones.Visible =false;
        }
        private void ActivarComponente()
        {
            lbPulsaciones.Visible = true;
            txtPulsaciones.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            LimpiarTextoBox();
        }

       
    }
}
