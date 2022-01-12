/*(8.11.4) Abre una imagen en formato BMP y comprueba si está comprimida, 
mirando el valor del byte en la posición 30 (empezando a contar desde 0). Si ese 
valor es un 0 (que es lo habitual), indicará que el fichero no está comprimido.
Deberás leer toda la cabecera (los primeros 54 bytes) con una sola orden.*/

using System;
using System.IO;

public class EjercicioFicherosBinarios
{
    public static void Main()
    {
        FileStream fichero;

        Console.WriteLine("Introduce el nombre del fichero BMP a analizar:");
        string nombre = Console.ReadLine();

        try
        {
            fichero = new FileStream(nombre, FileMode.Open);
            byte[] bytesLeidos = new byte[55];

            fichero.Read(bytesLeidos, 0, 55);

            if (Convert.ToChar(bytesLeidos[0]) == 'B' && Convert.ToChar(bytesLeidos[1]) == 'M')
            {
                Console.WriteLine("Se trata de un fichero BMP");
                if (bytesLeidos[29] == 0)
                    Console.WriteLine("El fichero no está comprimido");
                else
                    Console.WriteLine("El fichero sí está comprimido");
            }
            else
                Console.WriteLine("No se trata de un fichero BMP");
            fichero.Close();
        }
        catch (Exception fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
    }
}