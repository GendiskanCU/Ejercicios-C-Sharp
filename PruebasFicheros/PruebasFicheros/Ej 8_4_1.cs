/*(8.4.1) Un programa que pida al usuario que teclee frases, y las almacene en el 
fichero "log.txt", que puede existir anteriormente (y que no deberá borrarse, sino 
añadir al final de su contenido). Cada sesión acabará cuando el usuario pulse Intro 
sin teclear nada*/
using System;
using System.IO;

public class PruebaFicheros
{
    public static void Main()
    {
        StreamWriter fichero;
        fichero = File.AppendText("log.txt");
        string frase;
        do
        {
            Console.WriteLine("\nEscribe una frase (deja en blanco para salir):");
            frase = Console.ReadLine();
            if (frase != "")
                fichero.WriteLine(frase);
        } while (frase != "");


        fichero.Close();
    }
}