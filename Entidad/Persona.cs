using System;

namespace Entidad
{
    public class Persona
    {
        public Persona(string nombre, string identificacion, string sexo, int edad)
        {
            Nombre = nombre;
            Identificacion = identificacion;
            Sexo = sexo;
            Edad = edad;

        }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public decimal Pulsacion { get; set; }
        public void CalcularPulsacion()
        {
            if (Sexo.ToUpper().Equals("M"))
            {
               Pulsacion = (210 - Edad) / 10;
            }
            else if (Sexo.ToUpper().Equals("F"))
            {
                Pulsacion = (220 - Edad) / 10;
            }
            else
            {
                Pulsacion = 0;
            }
        }
    }
}
