/*(8.1.1) Crea un programa que vaya leyendo las frases que el usuario teclea y las 
guarde en un fichero de texto llamado "registroDeUsuario.txt". Terminará cuando 
la frase introducida sea "fin" (esa frase no deberá guardarse en el fichero).*/

using System;
using System.IO;

public class EjerciciosFicheros1
{
    public static void Main()
    {
        StreamWriter ficheroEscribir = new StreamWriter("registroDeUsuario.txt");
        string frase;
        do
        {
            Console.WriteLine("Frase que quieres guardar: ");
            frase = Console.ReadLine();
            if (frase != "fin")
                ficheroEscribir.WriteLine(frase);
        } while (frase != "fin");
        ficheroEscribir.Close();
    }
}