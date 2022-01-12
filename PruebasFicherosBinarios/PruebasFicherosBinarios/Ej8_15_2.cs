/*(8.15.2) Crea un programa que "encripte" el contenido de un fichero BMP, 
volcando su contenido a un nuevo fichero, en el que intercambiará los dos 
primeros bytes. Para desencriptar, bastará con volver a intercambiar esos dos 
bytes, volcando a un tercer fichero.*/
using System;
using System.IO;
public class EncriptaFicheros
{
    public static void Main()
    {
        FileStream ficheroOriginal;
        BinaryWriter ficheroEncriptado;

        Console.WriteLine("Introduzca el nombre del fichero a encriptar");
        string nombreOriginal = Console.ReadLine();
        try
        {
            ficheroOriginal = File.OpenRead(nombreOriginal);
            ficheroEncriptado = new BinaryWriter(File.Create(nombreOriginal + ".encript"));

            byte[] datosOriginal = new byte[ficheroOriginal.Length];//Creamos un array de bytes que abarque todo el tamaño del fichero original

            long bytesLeidos = ficheroOriginal.Read(datosOriginal, 0, (int)ficheroOriginal.Length);//Leemos todos los bytes del fichero original

            byte temporal = datosOriginal[0];//Intercambiamos los dos primeros bytes
            datosOriginal[0] = datosOriginal[1];
            datosOriginal[1] = temporal;

            for(int i = 0; i < ficheroOriginal.Length; i++)
            {
                Console.WriteLine("Escribiendo... {0}", datosOriginal[i]);
                ficheroEncriptado.Write(datosOriginal[i]);
            }

            int primerByte, segundoByte;

            ficheroOriginal.Seek(0, SeekOrigin.Begin);
            primerByte = ficheroOriginal.ReadByte();
            segundoByte = ficheroOriginal.ReadByte();
            Console.WriteLine("Primeros dos bytes del fichero original: {0}, {1}", primerByte, segundoByte);

            ficheroOriginal.Close();
            ficheroEncriptado.Close();

            BinaryReader ficheroEncriptado2 = new BinaryReader(File.Open(nombreOriginal + ".encript", FileMode.Open));
            ficheroEncriptado2.BaseStream.Seek(0, SeekOrigin.Begin);
            primerByte = ficheroEncriptado2.ReadByte();
            segundoByte = ficheroEncriptado2.ReadByte();
            Console.WriteLine("Primeros dos bytes del fichero encriptado: {0}, {1}", primerByte, segundoByte);
            ficheroEncriptado2.Close();
        }
        catch(Exception fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
    }
}