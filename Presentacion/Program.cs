using System;
using Logica;
using Entidad;

namespace Presentacion
{
    class Program
    {
        private static readonly PersonaService personaService = new PersonaService();
        static void Main(string[] args)
        {
            char seguir = 'S';
            do
            {
                int opcion = Menu();
                switch (opcion)
                {
                    case 1:Guardar();
                        break;
                    case 2:  Consultar();
                        break;
                    case 3:Eliminar();
                        break;
                    case 4:ConsultaPorIdentificacion();
                        break;
                    case 5:Modificar();
                        break;
                    case 6:seguir = 'N';
                        break;
                }

            } while (seguir=='S');
        }

        public static int Menu()
        {
            Console.Clear();
            int op;
            Console.WriteLine("----------Software de Registro de Pulsaciones----------");
            Console.WriteLine("......Programacion III .....");
            Console.WriteLine("1.Registrar");
            Console.WriteLine("2.Consultar");
            Console.WriteLine("3.Eliminar");
            Console.WriteLine("4.Salir");
            do
            {
                Console.Write("Escoja una Opción: ");
                op = int.Parse(Console.ReadLine());
            } while (op < 1 || op > 4);
            return op;
        }
        private static void Guardar()
        {
            Console.Clear();
            Console.WriteLine("---------Ingreso de Datos---------");
            var persona = CapturarDatos();
            string mensaje = personaService.Guarda(persona);
            Console.WriteLine(mensaje);
        }

        private static void Consultar()
        {
            Console.Clear();
            Console.WriteLine("---------Consulta de Datos-----------");
            var respuesta = personaService.Consultar();
            if (respuesta.Error)
            {
                Console.WriteLine(respuesta.Mensaje);
            }
            else
            {
                foreach (var item in respuesta.Personas)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("-------------------------");
                }
            }
        }
        private static void Eliminar()
        {
            Console.Clear();
            string identificacion;
            Console.WriteLine("--------Eliminando Datos-------");
            Console.Write("Identificiacion:");
            identificacion = Console.ReadLine();
            var (mensajeEliminacion,personaEliminar) = personaService.Eliminar(identificacion);
            Console.WriteLine(mensajeEliminacion);
        }

        private static Persona CapturarDatos()
        {
            Persona persona;
            string identificacion, nombre, sexo;
            int edad;
            Console.Write("Identificiacion: ");
            identificacion = Console.ReadLine();
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Edad: ");
            edad = int.Parse(Console.ReadLine());
            Console.Write("Sexo(F/M): ");
            sexo = Console.ReadLine();
            persona = new(identificacion, nombre, sexo, edad);
            persona.CalcularPulsacion();
            Console.WriteLine($"Pulsación Estimada por 10 Seg de Ejercicio: {persona.Pulsacion}");
            return persona;
        }
    }
}
