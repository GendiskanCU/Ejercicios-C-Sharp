using System;
using System.IO;//Para Stream
using System.Net;//Para System.Net.WebCliente

public class EjemploDescargarWeb
{
    public static void Main()
    {
        WebClient cliente = new WebClient();

        Stream conexion;
        try
        {
            conexion = cliente.OpenRead("https://www.google.es");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            return;
        }

        StreamReader lector = new StreamReader(conexion);

        string linea;
        int contador = 0;

        while( (linea = lector.ReadLine()) != null )
        {
            contador++;
            Console.WriteLine("{0}: {1}", contador, linea);
        }

        conexion.Close();
        Console.ReadKey();
    }
}
