using System;
using System.Collections;

public class EjemploCola
{
    public static void Main()
    {
        string palabra;

        Queue miCola = new Queue();
        miCola.Enqueue("Hola");
        miCola.Enqueue(", soy");
        miCola.Enqueue(" yo.");

        for (byte i =0; i<3; i++)
        {
            palabra = (string)miCola.Dequeue();
            Console.Write(palabra);
        }
            
    }
}