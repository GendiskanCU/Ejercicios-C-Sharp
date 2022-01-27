/*(11.9.6.1) Crea una programa que pida al usuario 4 números reales, los almacene 
usando "stackalloc" y luego los recorra incrementando el puntero a partir de la 
posición del primer elemento.*/

using System;

public class EjercicioAritmeticaPunteros
{
    public unsafe static void Main()
    {
        const int n = 4;
        float* numerosReales = stackalloc float[n];

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Introduce un número real:");
            numerosReales[i] = Convert.ToSingle(Console.ReadLine());
        }

        //Recorremos el array utilizando la aritmética de punteros
        for(int j = 0; j < n; j++)
        {
            Console.WriteLine("En la posición de memoria {0} está el número {1}",
                (long)numerosReales, *numerosReales);
            numerosReales++;
        }
    }
}