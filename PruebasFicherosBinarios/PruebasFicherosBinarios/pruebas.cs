/*(8.12.2) Abre una imagen en formato BMP y comprueba si está comprimida, 
mirando el valor del byte en la posición 30 (empezando a contar desde 0). Si ese 
valor es 0 (que es lo habitual), indicará que el fichero no está comprimido. Salta a 
esa posición directamente, sin leer toda la cabecera*/

using System;
using System.IO;

public class EjercicioFicherosBinarios
{
    public static void Main()
    {
        FileStream fichero;

        Console.WriteLine("Introduce el nombre del fichero BMP a analizar:");
        string nombre = Console.ReadLine();
        int datoLeido, otrodatoLeido;

        try
        {
            fichero = new FileStream(nombre, FileMode.Open);

            fichero.Seek(0, SeekOrigin.Begin);

            datoLeido = fichero.ReadByte();
            Console.WriteLine(Convert.ToChar(datoLeido));

            fichero.Seek(22, SeekOrigin.Begin);
            datoLeido = fichero.ReadByte();
            otrodatoLeido = fichero.ReadByte();

            Console.WriteLine(datoLeido + otrodatoLeido*256);

            if (datoLeido == 0)
                Console.WriteLine("El archivo no está comprimido");
            else
                Console.WriteLine("El archivo está comprimido");

            fichero.Close();
        }
        catch (Exception fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
    }
}