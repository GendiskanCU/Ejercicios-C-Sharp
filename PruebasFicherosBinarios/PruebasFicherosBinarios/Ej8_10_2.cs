/*(8.10.2) Crea un programa que cuente la cantidad de vocales que contiene un
fichero binario*/

using System;
using System.IO;

public class EjerciciosFicherosBinarios
{
    public static void Main()
    {
        Console.WriteLine("Escribe el nombre del archivo");
        string nombre = Console.ReadLine();

        FileStream fichero;

        try
        {
            fichero = File.OpenRead(nombre);
            int byteLeido;
            int numA =0, numE =0, numI =0, numO =0, numU = 0;
            for(int i = 0; i < fichero.Length; i++)
            {
                byteLeido = fichero.ReadByte();
                if (byteLeido == 65 || byteLeido == 97)
                    numA++;
                if (byteLeido == 69 || byteLeido == 101)
                    numE++;
                if (byteLeido == 73 || byteLeido == 105)
                    numI++;
                if (byteLeido == 79 || byteLeido == 111)
                    numO++;
                if (byteLeido == 85 || byteLeido == 117)
                    numU++;
            }

            fichero.Close();

            Console.WriteLine("Número de vocales encontradas: {0}", numA + numE + numI + numO + numU);
            Console.WriteLine("Total de A: {0}", numA);
            Console.WriteLine("Total de E: {0}", numE);
            Console.WriteLine("Total de I: {0}", numI);
            Console.WriteLine("Total de O: {0}", numO);
            Console.WriteLine("Total de U: {0}", numU);
        }
        catch (Exception fallo)
        {
            Console.WriteLine(fallo.Message);
            return;
        }
    }    
}