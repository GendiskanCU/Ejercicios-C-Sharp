/*(8.10.4) Crea un programa que extraiga a un fichero de texto todos los caracteres 
alfabéticos (códigos 32 a 127, además del 10 y el 13) que contenga un fichero 
binario*/

using System;
using System.IO;

public class EjerciciosFicherosBinarios
{
    public static void Main()
    {
        Console.WriteLine("Escribe el nombre del archivo");
        string nombreFuente = Console.ReadLine();

        FileStream ficheroFuente;
        StreamWriter ficheroDestino;

        try
        {
            ficheroFuente = File.OpenRead(nombreFuente);
            ficheroDestino = File.CreateText("ficherodestino.txt");
            int byteLeido;
            
            for(int i = 0; i < ficheroFuente.Length; i++)
            {
                byteLeido = ficheroFuente.ReadByte();
                if ((byteLeido >= 32 && byteLeido <= 127) || byteLeido == 10 || byteLeido == 13)
                    ficheroDestino.Write(Convert.ToChar(byteLeido));
            }

            ficheroFuente.Close();
            ficheroDestino.Close();
            
        }
        catch (Exception fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
    }    
}