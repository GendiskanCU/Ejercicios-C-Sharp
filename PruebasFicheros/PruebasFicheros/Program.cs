using System;
using System.IO;

public class Ejemplo
{
    public static void Main()
    {
        //StreamWriter fichero;

        //fichero = File.CreateText("prueba.txt");
        //fichero = new StreamWriter("prueba2.txt");
        using (StreamWriter fichero = new StreamWriter("prueba3.txt"))
        {
            fichero.WriteLine("Esto es una línea");
            fichero.Write("Esto es otra");
            fichero.WriteLine(" y esto es continuación de la anterior");
        }
        //fichero.Close();
    }
}