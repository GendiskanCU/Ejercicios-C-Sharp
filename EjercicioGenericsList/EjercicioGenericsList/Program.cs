/*11.8.2) Crea un programa que lea todo el contenido de un fichero, lo guarde en 
una lista de strings y luego lo muestre en orden inverso (de la última línea a la 
primera).*/
using System;
using System.Collections.Generic;
using System.IO;

public class EjercicioListas
{
    public static void Main()
    {
        StreamReader fichero;
        List<string> frasesQuijote = new List<string>();

        if(File.Exists("FrasesQuijote.txt"))
        {
            fichero = File.OpenText("FrasesQuijote.txt");

            string frase = fichero.ReadLine();

            while(frase != null)
            {
                frasesQuijote.Add(frase);
                frase = fichero.ReadLine();
            }

            frasesQuijote.Reverse();

            foreach(string f in frasesQuijote)
            {
                Console.WriteLine(f);
            }

            fichero.Close();
        }
        else
        {
            Console.WriteLine("No se ha encontrado el fichero");
        }
    }
}