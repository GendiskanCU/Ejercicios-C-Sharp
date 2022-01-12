/*(8.13.3) El alto de un fichero BMP es un entero de 32 bits que se encuentra en la 
posición 22. Amplía el ejemplo 08_13d, para que muestre también el alto de ese 
fichero BMP.*/

using System;
using System.IO;

public class EjercicioFicherosBinarios
{
    public static void Main()
    {

        BinaryReader fichero;

        Console.WriteLine("Introduce el nombre del fichero BMP:");
        string nombre = Console.ReadLine();

        try
        {
            fichero = new BinaryReader(File.Open(nombre, FileMode.Open));

            int datoLeido;

            fichero.BaseStream.Seek(22, SeekOrigin.Begin);
            datoLeido = fichero.ReadInt32();

            Console.WriteLine($"El alto del fichero BMP es de: {datoLeido}");

            fichero.Close();
        }
        catch(Exception fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
    }
}