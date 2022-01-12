/*(11.3.1) Crea un programa que pida al usuario 5 números reales de doble precisión,
los guarde en una cola y luego los muestre en pantalla.*/
using System;
using System.Collections;

public class EjerciciosColas
{
    public static void Main()
    {
        Queue colaReales = new Queue();
        double numeroReal;

        for(byte i = 0; i < 5; i++)
        {
            Console.Write("Escribe un número real: ");
            numeroReal = Convert.ToDouble(Console.ReadLine());
            colaReales.Enqueue(numeroReal);
        }

        Console.WriteLine("Sacamos los valores de la cola: ");

        for (byte i = 0; i < 5; i++)
        {
            numeroReal = (double) colaReales.Dequeue();
            Console.Write(numeroReal + " - ");
        }
    }
}