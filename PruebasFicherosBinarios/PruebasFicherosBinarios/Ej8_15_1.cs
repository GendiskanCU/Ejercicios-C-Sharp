/*(8.15.1) Crea una copia de un fichero EXE. La copia debe tener el mismo nombre y 
extensión BAK*/

using System;
using System.IO;

public class CopiaExe
{
    public static void Main()
    {
        FileStream ficheroOrigen;
        BinaryWriter ficheroDestino;

        Console.WriteLine("Escribe el nombre del fichero que deseas copiar:");
        string nombreFichero = Console.ReadLine();

        try
        {
            ficheroOrigen = new FileStream(nombreFichero, FileMode.Open);
            ficheroDestino = new BinaryWriter(File.Open(nombreFichero + ".BAK", FileMode.Create));

            int byteOrigen;
            long numBytesOrigen = ficheroOrigen.Length;

            for(int i=0; i<numBytesOrigen; i++)
            {
                byteOrigen = ficheroOrigen.ReadByte();
                ficheroDestino.Write((byte)byteOrigen);
            }

            ficheroOrigen.Close();
            ficheroDestino.Close();
            
        }
        catch (Exception fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
    }
}