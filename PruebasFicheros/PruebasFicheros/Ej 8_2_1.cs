/*(8.2.1) Crea un programa que lea las tres primeras líneas del fichero creado en el 
ejercicio 8.1.1 y las muestre en pantalla. Usa OpenText para abrirlo*/

using System;
using System.IO;

public class EjerciciosFicheros1
{
    public static void Main()
    {
        StreamReader miFichero;
        miFichero = File.OpenText("BDDocumentos.txt");
        for (int i = 1; i <= 3; i++)
            Console.WriteLine(miFichero.ReadLine());
        miFichero.Close();
    }
}