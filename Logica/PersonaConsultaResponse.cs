using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PersonaConsultaResponse
    {
        public List<Persona> Personas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public PersonaConsultaResponse(List<Persona> personas)
        {
            Personas = personas;
            Error = false;
        }
        public PersonaConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
