/*(12.3.1) Crea un programa que muestre en pantalla el contenido de un fichero de 
texto, cuyo nombre escoja el usuario. Si el usuario no sabe el nombre, podrá 
pulsar "Intro" y se le mostrará la lista de ficheros existentes en el directorio actual , 
para luego volver a preguntarle el nombre del fichero*/

using System;
using System.IO;

public class EjercicioDirectorios
{
    public static void Main()
    {
        string[] ficherosDeTexto;

        ficherosDeTexto = Directory.GetFiles(".", "*.txt");

        Console.WriteLine("Archivos de texto en el directorio actual:");
        foreach(string f in ficherosDeTexto)
        {
            Console.WriteLine(f);
        }

        Console.WriteLine("\nEscribe el nombre del fichero que quieres visualizar");

        string fichero = Console.ReadLine();

        if(!File.Exists(fichero))
        {
            Console.WriteLine("El fichero {0} no se ha encontrado", fichero);
        }
        else
        {
            StreamReader lecturaFichero = new StreamReader(fichero);
            string lineaLeida;

            Console.WriteLine("Contenido del fichero {0}:\n", fichero);

            lineaLeida = lecturaFichero.ReadLine();

            while(lineaLeida != null)
            {
                Console.WriteLine(lineaLeida);
                lineaLeida=lecturaFichero.ReadLine();
            }

            lecturaFichero.Close();
        }

        Console.ReadKey();
    }
}