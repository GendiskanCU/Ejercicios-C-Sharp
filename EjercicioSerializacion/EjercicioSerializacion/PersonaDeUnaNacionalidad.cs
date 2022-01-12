using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioSerializacion
{
    [Serializable]
    public class PersonaDeUnaNacionalidad : Persona
    {

        string nacionalidad;
        string idioma;


        public PersonaDeUnaNacionalidad()
        {
            nacionalidad = "Desconocida";
            idioma = "Desonocido";
        }

        public PersonaDeUnaNacionalidad(string nombrePersona, int edadPersona, char sexoPersona, string pais, string lengua) : base(nombrePersona, edadPersona, sexoPersona)
        {
            nacionalidad = pais;
            idioma = lengua;
        }

        public override void HablaPersona()
        {
            base.HablaPersona();
            Console.WriteLine("Soy de nacionalidad {0}", nacionalidad);
            Console.WriteLine("Y mi idioma es el {0}", idioma);
        }



    }

    
}
