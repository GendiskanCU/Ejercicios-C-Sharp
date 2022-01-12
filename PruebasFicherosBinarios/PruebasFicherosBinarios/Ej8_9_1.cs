/*(8.9.1) Abre un fichero con extensión EXE (cuyo nombre introducirá el usuario) y 
comprueba si realmente se trata de un ejecutable, mirando si los dos primeros 
bytes del fichero son un 77 (que corresponde a una letra "M", según el estándar 
que marca el código ASCII) y un 90 (una letra "Z"), respectivamente.*/

using System;
using System.IO;

public class EjerciciosFicherosBinarios
{
    public static void Main()
    {
        FileStream fichero;

        Console.WriteLine("Introduce el nombre del archivo:");
        string nombreFichero = Console.ReadLine();

        try
        {
            fichero = new FileStream(nombreFichero, FileMode.Open);
            byte primero, segundo;
            primero = (byte)fichero.ReadByte();
            segundo = (byte)fichero.ReadByte();
            if (primero == 77 && segundo == 90)
                Console.WriteLine("Se trata de un fichero ejecutable");
            else
                Console.WriteLine("No se trata de un fichero ejecutable");

            fichero.Close();
        }
        catch (IOException fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
    }
}