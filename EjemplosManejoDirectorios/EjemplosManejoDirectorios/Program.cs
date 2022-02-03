using System;
using System.IO;
using System.Collections.Generic;

public class EjemploCrearDirectorio
{
    public static void Main()
    {
        string nuevoDirectorio = @"d:\temp\prueba02";
        if(!Directory.Exists(nuevoDirectorio))
            Directory.CreateDirectory(nuevoDirectorio);       


        Console.ReadKey();
    }
}