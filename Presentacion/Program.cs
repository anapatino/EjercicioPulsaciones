using System;
using Logica;
using Entidad;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio Púlsaciones(Creacion de capas)");
            string nombre, identificacion, sexo;
            int edad;

            Console.Write("Digite su Identificacion:");
            identificacion = Console.ReadLine();
            Console.Write("Digite su Nombre:");
            nombre = Console.ReadLine();
            Console.Write("Digite su Edad:");
            edad = int.Parse(Console.ReadLine());
            Console.Write("Digite su Sexo:");
            sexo = Console.ReadLine();

            Persona persona = new Persona(nombre, identificacion, sexo, edad);
            persona.CalcularPulsacion();
            

            PersonaService personaService = new PersonaService();
            string mensaje=personaService.Guarda(persona);
            Console.WriteLine(mensaje);
            Console.WriteLine($"Se calculo la pulsacion de la persona {persona.Pulsacion}");

            var respuesta = personaService.Consultar();
            if (respuesta.Error)
            {
                Console.WriteLine(respuesta.Mensaje);
            }
            else
            {
                foreach (var item in respuesta.Personas)
                {
                   Console.WriteLine($"{item.Nombre};{item.Identificacion};{item.Sexo};{item.Edad};{item.Pulsacion};");
                }
            }
            
            Console.ReadKey();
        }
    }
}
