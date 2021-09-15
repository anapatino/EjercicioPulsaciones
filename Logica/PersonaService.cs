using Datos;
using Entidad;
using System;

namespace Logica
{
    public class PersonaService
    {


        readonly  PersonaRepository personaRepository;
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }

        public string Guarda(Persona persona)
        {
            try
            {
                personaRepository.Guardar(persona);
                return "Se ha Guardado los Datos Correctamente";
            }
            catch (Exception e)
            {
                return "Error al Guardar :"+e.Message;

            }
        }
        public PersonaConsultaResponse Consultar()
        {
            try
            {
                return new PersonaConsultaResponse(personaRepository.Consultar());
            }
            catch (Exception e)
            {
                return new PersonaConsultaResponse($"Error inesperado al Consultar: {e.Message}");
            }
        }
    }
}
