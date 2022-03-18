//Ejemplo para obtener los números enteros de un array mayores de 10

using System;
using System.Linq;

public class EjemploLinq
{
    public static void Main()
    {
        int[] datos = { 20, 5, 7, 4, 25, 18, 5, 8, 21, 2 };

        var result =
            from n in datos
            where n > 10
            select n;

        foreach (int i in result)
            Console.Write("{0}, ", i);
        Console.WriteLine();
    }
}
