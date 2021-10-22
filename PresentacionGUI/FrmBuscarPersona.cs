using Entidad;
using Logica;
using System;
using System.Windows.Forms;

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
            ValidarFiltro();
        }

        private void ValidarFiltro()
        {
            string filtro = cbItem.Text;
            if (filtro.Equals("Sexo"))
            {
                VisualizarSexo();
            }
            else if (filtro.Equals("Identificacion"))
            {
                VisualizarIdentificacion();
            }
            else if (filtro.Equals("Anio"))
            {
                VisualizarAnio();
            }
            else if (filtro.Equals("Palabra"))
            {
                VisualizarPalabra();
            }
        }

        public void VisualizarIdentificacion()
        {
            Persona persona = new Persona();
            string identificacion = txtBusqueda.Text;
            PersonaService personaService = new PersonaService();
            var (mensaje, personaBuscada) = personaService.Buscar(identificacion);
            if (mensaje.Equals($" Se encuentra Registrado {identificacion}"))
            {
                ActivarTabla(personaBuscada);
            }
            MessageBox.Show(mensaje);
        }

        public void VisualizarSexo()
        {
            PersonaConsultaResponse respuesta;
            PersonaService personaService = new PersonaService();
            string sexo = txtBusqueda.Text;
            respuesta = personaService.ConsultarPorSexo(sexo);
            AgregarRegistroPanel(respuesta);
        }

        public void AgregarRegistroPanel(PersonaConsultaResponse respuesta)
        {
            if (respuesta.Error)
            {
                MessageBox.Show(respuesta.Mensaje, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dgvTabla.Visible = true;
                foreach (var item in respuesta.Personas)
                {
                    dgvTabla.Rows.Add(item.Identificacion, item.Nombre, item.Edad, item.Sexo, item.Pulsacion, item.FechaNacimiento.Year);
                }

            }
        }

        public void VisualizarPalabra()
        {
            PersonaConsultaResponse respuesta;
            PersonaService personaService = new PersonaService();
            string palabra = txtBusqueda.Text;
            respuesta = personaService.ConsultarPorPalabra(palabra);
            AgregarRegistroPanel(respuesta);
        }

        public void VisualizarAnio()
        {
            PersonaConsultaResponse respuesta;
            PersonaService personaService = new PersonaService();
            int year = int.Parse(txtBusqueda.Text);
            respuesta = personaService.ConsultarPorAnio(year);
            AgregarRegistroPanel(respuesta);
        }
        public void ActivarTabla(Persona personaBuscada)
        {
            dgvTabla.Visible = true;
            dgvTabla.Rows.Add(personaBuscada.Identificacion, personaBuscada.Nombre, personaBuscada.Edad, personaBuscada.Sexo, personaBuscada.Pulsacion,personaBuscada.FechaNacimiento.Year);
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
            cbItem.Text = null;
            txtBusqueda.Text = null;
            dgvTabla.Rows.Clear();

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (cbItem.Text.Equals("Palabra"))
            {
                dgvTabla.Rows.Clear();
                VisualizarPalabra();
                
            }
        }
    }
}
