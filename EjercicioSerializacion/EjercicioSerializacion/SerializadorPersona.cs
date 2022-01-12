using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EjercicioSerializacion
{
    public class SerializadorPersona
    {
        public static void GuardaDatosPersona(PersonaDeUnaNacionalidad persona)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("datospersona.dat", FileMode.Create, FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, persona);

            stream.Close();
        }

        public static PersonaDeUnaNacionalidad CargaDatosPersona()
        {
            PersonaDeUnaNacionalidad persona;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("datospersona.dat", FileMode.Open, FileAccess.Read, FileShare.Read);

            persona = (PersonaDeUnaNacionalidad) formatter.Deserialize(stream);

            stream.Close();

            return persona;
        }
    }
}
