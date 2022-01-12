using System;

namespace EjercicioSerializacion
{
    class Program
    {
        static void Main()
        {
            int opcion = 0;

            while (opcion != 3)
            {
                Console.Clear();
                Console.WriteLine("¿Qué deseas hacer:?");
                Console.WriteLine("1. Volcar los datos de una persona al fichero");
                Console.WriteLine("2. Cargar los datos de un persona del fichero");
                Console.WriteLine("3. Salir");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Introduce los datos de la persona:");
                        Console.WriteLine("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Edad: ");
                        int edad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Sexo:");
                        char sexo = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine("Nacionalidad: ");
                        string nacionalidad = Console.ReadLine();
                        Console.WriteLine("Idioma: ");
                        string idioma = Console.ReadLine();

                        PersonaDeUnaNacionalidad nuevaPersona = new PersonaDeUnaNacionalidad(nombre, edad, sexo, nacionalidad, idioma);
                        nuevaPersona.HablaPersona();

                        SerializadorPersona.GuardaDatosPersona(nuevaPersona);

                        Console.WriteLine("Datos volcados al fichero. Pulse una tecla para continuar...");
                        Console.ReadKey();

                        break;
                    case 2:
                        PersonaDeUnaNacionalidad persona = SerializadorPersona.CargaDatosPersona();
                        Console.WriteLine("Datos cargados:");
                        persona.HablaPersona();
                        Console.ReadKey();

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
