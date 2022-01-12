using System;
using System.Collections;

public class EjercicioPilas
{
    public static void Main()
    {
        Stack miPila = new Stack();

        Console.WriteLine("Introduce 5 números enteros en la pila:");

        int contador, numeroIntroducido;

        for(contador=0; contador<5; contador++)
        {
            Console.WriteLine("Número " + (contador + 1) + ": ");
            numeroIntroducido = Convert.ToInt32(Console.ReadLine());
            miPila.Push(numeroIntroducido);
        }

        Console.WriteLine("Sacamos los números de la pila, que tiene {0} elementos", miPila.Count);

        for(contador = 0; contador < 5; contador++)        
            Console.WriteLine(miPila.Pop());
        

        Console.ReadLine();
    }
}