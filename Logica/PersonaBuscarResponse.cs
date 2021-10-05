using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Logica
{
    public class PersonaBuscarResponse
    {
        public Persona Persona { get; set; }
        public string Mensaje { get; set; }
        public bool IsError { get; set; }

        public PersonaBuscarResponse(Persona persona)
        {
            Persona = persona;
            IsError = false;
        }
        public PersonaBuscarResponse(string mensaje)
        {
            Mensaje = mensaje;
            IsError = true;
        }
    }
}
