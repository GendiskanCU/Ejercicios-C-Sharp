/*(8.10.1) Crea un programa que compruebe si un fichero (cuyo nombre introducirá 
el usuario) contiene una cierta letra (también escogida por el usuario).*/

using System;
using System.IO;

public class EjerciciosFicherosBinarios
{
    public static void Main()
    {
        FileStream fichero;
        try
        {
            Console.WriteLine("Introduce el nombre del fichero:");
            string nombreFichero = Console.ReadLine();
            Console.WriteLine("Introduce la letra que estás buscando:");
            char letra = Convert.ToChar(Console.ReadLine());
            int byteLeido;
            bool contiene = false;
        
            fichero = new FileStream(nombreFichero, FileMode.Open);
            do
            {
                byteLeido = fichero.ReadByte();                

                if ( byteLeido != -1 && Convert.ToChar(byteLeido) == letra)
                {
                    contiene = true;
                    byteLeido = -1;
                }

            } while (byteLeido != -1);

            if (contiene)
                Console.WriteLine("La letra {0} SÍ se ha encontrado en el fichero", letra);
            else
                Console.WriteLine("La letra {0} NO se ha encontrado en el fichero", letra);

        }
        catch (IOException fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
        catch (Exception fallo2)
        {
            Console.WriteLine(fallo2.Message);
            return;
        }
    }    
}