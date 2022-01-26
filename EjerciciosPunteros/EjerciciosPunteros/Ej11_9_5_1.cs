/*(11.9.5.1) Crea una programa que pida al usuario 5 números, los almacene usando 
"stackalloc" y luego los muestre en orden inverso*/

using System;

public class EjercicioReservaEspacio
{
    public unsafe static void Main()
    {
        int cantidad = 5;
        float* numeros = stackalloc float[cantidad];        

        for(int i = 0; i < cantidad; i++)
        {
            Console.WriteLine("Introduce un número:");
            numeros[i] = Convert.ToSingle(Console.ReadLine());
        }

        for(int i = cantidad - 1; i >= 0; i--)
        {
            Console.WriteLine(numeros[i]);
        }
    }
}