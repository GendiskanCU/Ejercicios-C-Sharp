using System;
using System.IO;

public class EjemploInformacionDirectorios
{
    public static void Main()
    {
        string directorio = @"c:\";

        DirectoryInfo directoryInfo = new DirectoryInfo(directorio);
        FileInfo [] infoFicheros = directoryInfo.GetFiles();

        foreach(FileInfo fi in infoFicheros)
        {
            Console.WriteLine("{0}\nTamaño: {1}. Fecha de creación: {2}\n=====",
                fi.Name, fi.Length, fi.CreationTime);
        }

        Console.ReadKey();
    }
}