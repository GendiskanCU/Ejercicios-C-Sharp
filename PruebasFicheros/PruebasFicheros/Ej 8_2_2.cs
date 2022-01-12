/*(8.2.3) Crea una versión alternativa del ejercicio 8.2.2, empleando la sintaxis 
alternativa de "using"*/

using System;
using System.IO;

public class PruebasFicheros
{
    public static void Main()
    {
        StreamReader miFichero;
        using (miFichero = new StreamReader("BDDocumentos.txt"))
        {
            for (int i = 1; i <= 3; i++)
                Console.WriteLine(miFichero.ReadlLine());
        }
    }
}