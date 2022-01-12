/*(8.2.2) Crea una versión alternativa del ejercicio 8.2.1, usando el constructor de 
StreamReader*/

using System;
using System.IO;

public class EjerciciosFicheros
{
    public static void Main()
    {
        StreamReader fichero = new StreamReader("BDDocumentos.txt");
        for(int i = 1; i <= 3; i++)
        {
            Console.WriteLine(fichero.ReadLine());
        }
        fichero.Close();
    }
}