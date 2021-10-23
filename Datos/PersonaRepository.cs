using System;
using System.Collections.Generic;
using Entidad;
using System.IO;
using System.Linq;

namespace Datos
{
    public class PersonaRepository
    {
        public string ruta = "ListaPersonas.txt";

        public void Guardar(Persona persona)
        {
            using StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine($"{persona.Nombre};{persona.Identificacion};{persona.Sexo};{persona.Edad};{persona.Pulsacion};{persona.FechaNacimiento}");
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
                    Pulsacion = decimal.Parse(dato[4]),
                    FechaNacimiento = DateTime.Parse(dato[5])
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

        public Persona Eliminar(string id)
        {
            bool resultado = File.Exists(ruta);
            if (resultado == true)
            {
                List<Persona> personas = Consultar();
                File.Delete(ruta);
                foreach (var item in personas)
                {
                    if (item.Identificacion.Equals(id))
                    {
                       return item; 
                    }
                    else
                    {
                        Guardar(item);
                    }
                }
            } 
            return null;
        }

        public Persona Buscar(string identificacion)
        {
            bool resultado = File.Exists(ruta);
            if (resultado==true)
            {
                List<Persona> personas = Consultar();
                foreach (var item in personas)
                {
                    if (item.Identificacion.Equals(identificacion))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public List<Persona> FiltrarPorSexoVersionLarga(string sexo)
        {
            List<Persona> personasFiltrada = new List<Persona>();
            foreach (var item in Consultar())
            {
                if (item.Sexo.Equals(sexo))
                {
                    personasFiltrada.Add(item);
                }
            }
            return personasFiltrada;
        }

        public List<Persona> FiltrarPorSexoConsulta(string sexo)
        {
            return  (from p in Consultar()
                    where p.Sexo.Equals(sexo) orderby p.Nombre ascending
                    select p).ToList();
        }

        public List<Persona> FiltrarPorSexoMetodo(string sexo)
        {
            return Consultar().Where(p => p.Sexo.Equals(sexo)).ToList();
        }

        public int ContarPorSexorMetodo(string sexo)
        {
            return Consultar().Count(p => p.Sexo.Equals(sexo));
            // Otra forma
            // return Consultar().Where(p => p.Sexo.Equals(sexo)).Count();
        }

        public double PromediarPorEdadMetodo()
        {
            return Consultar().Average(p => p.Edad);
        }

        public decimal SumarPorPulsacionesMetodo()
        {
            return Consultar().Sum(p => p.Pulsacion);
        }

        public List<Persona> FiltrarPorAnio(int year)
        {
            return Consultar().Where(p => p.FechaNacimiento.Year == year).ToList();
        }

        public List<Persona> FiltrarPorPalabraConsulta(string palabra)
        {
            return (from p in Consultar()
                    where p.Nombre.ToLower().Contains(palabra.ToLower()) 
                    select p).ToList();
        }

    }
}
