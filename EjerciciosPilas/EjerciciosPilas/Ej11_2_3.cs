/*(11.2.3) Crea una clase que imite el comportamiento de una pila, pero usando 
internamente un array.*/
using System;
using System.Collections;

public class ImitacionPila
{
    int[] valoresPila;
    int posicion;

    public ImitacionPila()
    {
        valoresPila = new int[4];
        posicion = -1;
    }

    public void Push(int valor)
    {
        if (posicion >= 3)
            Console.WriteLine("No caben más elementos en la pila");
        else
            valoresPila[++posicion] = valor;
    }

    public int Pop()
    {
        if (posicion < 0)
        {
            Console.WriteLine("No hay elementos en la pila");
            return -1;
        }
        else
            return valoresPila[posicion--];
    }
}

public class EjercicioPilas
{
    public static void Main()
    {
        ImitacionPila pila = new ImitacionPila();

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("Introduce un valor para añadir a la pila: ");
            pila.Push(Convert.ToInt32(Console.ReadLine()));
        }

        Console.WriteLine("Los valores de la pila son:");
        for (int j = 0; j < 4; j++)
            Console.WriteLine(pila.Pop());

        Console.ReadLine();
        
    }
}