/*(8.16.1) Crea un programa que "encripte" el contenido de un fichero BMP, 
intercambiando los dos primeros bytes (y modificando el mismo fichero). Para 
desencriptar, bastará con volver a intercambiar esos dos bytes*/
using System;
using System.IO;
public class EncriptaFicheros
{
    public static void Main()
    {
        FileStream fichero;
        byte[] datos = new byte[2];

        Console.WriteLine("Introduce el nombre del fichero a encriptar:");
        string nombre = Console.ReadLine();

        try
        {
            fichero = File.Open(nombre, FileMode.Open, FileAccess.ReadWrite);
            fichero.Read(datos, 0, 2);//Leemos los dos primeros bytes

            Console.WriteLine("Dos primeros bytes antes de encriptar: {0} - {1}", Convert.ToChar(datos[0]), Convert.ToChar(datos[1]));

            fichero.Seek(0, SeekOrigin.Begin);//Nos colocamos al principio del fichero

            fichero.WriteByte(datos[1]);//Intercambiamos los dos primeros bytes
            fichero.WriteByte(datos[0]);

            fichero.Seek(0, SeekOrigin.Begin);//Nos colocamos al principio del fichero

            fichero.Read(datos, 0, 2);//Leemos los dos primeros bytes

            Console.WriteLine("Dos primeros bytes antes de encriptar: {0} - {1}", Convert.ToChar(datos[0]), Convert.ToChar(datos[1]));

            fichero.Close();

        }
        catch(Exception fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
        
    }
}