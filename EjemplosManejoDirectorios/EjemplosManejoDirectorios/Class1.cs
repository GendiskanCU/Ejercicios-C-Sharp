using System;
using System.IO;

public class EjemploLeerDirectorio
{
    public static void Main()
    {
        //Muestra los ficheros del directorio d:\temp
        string miDirectorio = @"d:\temp\";
        string[] ListaFicheros;

        ListaFicheros = Directory.GetFiles(miDirectorio,"*.exe");
        foreach (string nombreFichero in ListaFicheros)
            Console.WriteLine(nombreFichero);

        //Muestra los ficheros del directorio actual
        ListaFicheros = Directory.GetFiles(".", "*.*");
        foreach (string nombreFichero in ListaFicheros)
            Console.WriteLine(nombreFichero);

        Console.ReadKey();
    }
}