using System;
using Logica;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio Púlsaciones(Creacion de capas)");
            string nombre, identificacion,sexo;
            int edad;
          
            Console.WriteLine("Digite su Identificacion:");
            identificacion = Console.ReadLine();
            Console.WriteLine("Digite su Nombre:");
            nombre = Console.ReadLine();
            Console.WriteLine("Digite su Edad:");
            edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite su Sexo:");
            sexo = Console.ReadLine();
            PersonaService control = new PersonaService();
           
            //Console.WriteLine($"Su Pulsacion es : {control.persona.Pulsacion}");
            Console.ReadKey();
        }
    }
}
