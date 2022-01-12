using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioSerializacion
{
    [Serializable]
    public class Persona
    {
        protected string nombre;
        protected int edad;
        protected char sexo;

        public Persona()
        {
            nombre = "Desconocido/a";
            edad = 0;
            sexo = '-';
        }

        public Persona(string nombrePersona, int edadPersona, char sexoPersona)
        {
            nombre = nombrePersona;
            edad = edadPersona;
            sexo = sexoPersona;
        }

        public virtual void HablaPersona()
        {
            Console.WriteLine("Mi nombre es {0}", nombre);
            Console.WriteLine("Tengo {0} años", edad);
            if( sexo == 'H')
                Console.WriteLine("Y soy un hombre");
            if(sexo == 'M')
                Console.WriteLine("Y soy una mujer");
        }
    }

    
}
