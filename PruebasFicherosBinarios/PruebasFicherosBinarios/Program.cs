using System;
using System.IO;

public class EjemploFicheroBinario
{
    public static void Main()
    {
        Console.WriteLine("Introduzca el nombre del fichero");
        string nombre = Console.ReadLine();

        FileStream fichero = new FileStream(nombre, FileMode.Open);

        byte[] datos = new byte[10];
        int posicion = 0;
        int cantidadALeer = 10;
        int cantidadLeida = fichero.Read(datos, posicion, cantidadALeer);

        if (cantidadLeida < cantidadALeer)
            Console.WriteLine("No se han podido leer todos los datos");
        else
        {
            Console.WriteLine("El primer byte leído es: {0} - {1}", datos[0], Convert.ToChar(datos[0]));
            Console.WriteLine("El tercer byte leído es: {0} - {1}", datos[2], Convert.ToChar(datos[2]));
        }

        fichero.Close();
    }
}