using System;
using System.Collections.Generic;
using Entidad;
using System.IO;

namespace Datos
{
    public class PersonaRepository
    {
        public string ruta = "ListaPersonas.txt";

        public void Guardar(Persona persona)
        {
            using StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine($"{persona.Nombre};{persona.Identificacion};{persona.Sexo};{persona.Edad};{persona.Pulsacion};");
        }
        public List <Persona> Consultar()
        {
            List<Persona> personas = new ();
            StreamReader lector = new(ruta);
            string linea;
            while ((linea=lector.ReadLine())!=null)
            {
                string []dato=linea.Split(';');
                Persona persona = new()
                {
                    Nombre = dato[0],
                    Identificacion = dato[1],
                    Sexo = dato[2],
                    Edad = int.Parse(dato[3]),
                    Pulsacion = decimal.Parse(dato[4])
                };
               personas.Add(persona);
            }
            lector.Close();
            return personas;
        }
        public void Modificar(string id,Persona personaNew)
        {
            List<Persona> personas = Consultar();
            File.Delete(ruta);

            foreach (var item in personas)
            {
                if (item.Identificacion.Equals(id))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(personaNew);
                }
            }
        }
        public void Eliminar(string id)
        {
            List<Persona> personas =Consultar();
            File.Delete(ruta);

            foreach (var item in personas)
            {
                if (item.Identificacion.Equals(id))
                {
                    Guardar(item);
                }
            }
        }

        public Persona Buscar(string identificacion)
        {
            List<Persona> personas = Consultar();
            foreach (var item in personas)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }

    }
}
