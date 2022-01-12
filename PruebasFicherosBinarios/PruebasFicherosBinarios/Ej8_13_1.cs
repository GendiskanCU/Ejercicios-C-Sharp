/*(8.13.1) Abre un fichero con extensión EXE y comprueba si comienza con el entero 
corto 23117.*/

using System;
using System.IO;

public class EjercicioFicherosBinarios
{
    public static void Main()
    {
        BinaryReader fichero;

        Console.WriteLine("Nombre del fichero:");
        string nombre = Console.ReadLine();

        fichero = new BinaryReader(File.Open(nombre, FileMode.Open));

        short datoLeido = fichero.ReadInt16();

        if (datoLeido == 23117)
            Console.WriteLine("Correcto");
        else
            Console.WriteLine("Incorrecto");        
    }
}