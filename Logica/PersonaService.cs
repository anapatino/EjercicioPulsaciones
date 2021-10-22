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
                if (personaRepository.Buscar(persona.Identificacion)==null)
                {
                    personaRepository.Guardar(persona);
                    return "Se ha Guardado los Datos Correctamente";
                }
                return $"No fue posible Guardar la información, porque ya existe un registro con la identificaion  {persona.Identificacion}";
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
        public (string mensaje, Persona persona) Eliminar(string identificacion)
        {
            try
            {
                var persona=personaRepository.Buscar(identificacion);
                if (persona!= null)
                {
                    personaRepository.Eliminar(identificacion);
                    return ($"Se Eliminó el registro de la persona con identificacion {identificacion}",persona);
                }
                return ($"No fue posible eliminar el registro, porque no existe la persona con la identificacion {identificacion}",persona);
            }
            catch (Exception e)
            {
                return ($"Error inesperado al Eliminar: {e.Message}",null);
            }
        }
        public (string mensaje,Persona persona) Buscar(string identificacion)
        {
            try
            {     
                var persona = personaRepository.Buscar(identificacion);
                if (persona == null)
                {
                   return ("No se encontró un registro con la identificacion Solicitada",persona);
                }
                return ($" Se encuentra Registrado {identificacion}",persona);
            }
            catch (Exception e)
            {
                return ($"Error inesperado al Buscar: {e.Message}",null);
            }
        }
       
        public string Modificiar(string identificacion, Persona personaNew)
        {
            try
            {
                if (personaRepository.Buscar(identificacion) == null)
                {
                    return $"No es posible realizar la Modificación, la persona con Identificacion {identificacion} no existe";
                }
                if (personaRepository.Buscar(personaNew.Identificacion) != null)
                {
                    return $"No es posible realizar la Modificación, La Nueva Identificación {personaNew.Identificacion} ya se encuentra asignada a otra persona";
                }
                personaRepository.Modificar(identificacion, personaNew);
                return "Se realizó la Modificación Satisfactoriamente";
            }
            catch (Exception e)
            {
                return $"Error inesperado al Modificar: {e.Message}";
            }
        }

        public PersonaConsultaResponse ConsultarPorSexo(string sexo)
        {
            try
            {
                return new PersonaConsultaResponse(personaRepository.FiltrarPorSexoConsulta(sexo));
            }
            catch (Exception e)
            {
                return new PersonaConsultaResponse("Se presento el siguiente: "+e.Message);
            }
        }

        public PersonaConsultaResponse ConsultarPorPalabra(string palabra)
        {
            try
            {
                return new PersonaConsultaResponse(personaRepository.FiltrarPorPalabraConsulta(palabra));
            }
            catch (Exception e)
            {
                return new PersonaConsultaResponse("Se presento el siguiente: " + e.Message);
            }
        }

        public PersonaConsultaResponse ConsultarPorAnio(int year)
        {
            try
            {
                return new PersonaConsultaResponse(personaRepository.FiltrarPorAnio(year));
            }
            catch (Exception e)
            {
                return new PersonaConsultaResponse("Se presento el siguiente: " + e.Message);
            }
        }
    }
}
