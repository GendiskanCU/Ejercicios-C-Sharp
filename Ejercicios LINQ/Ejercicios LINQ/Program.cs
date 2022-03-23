/*(13.8.1) Crea un programa que pida al usuario varios números enteros, los guarde 
en una lista y luego muestre todos los que sean positivos, ordenados, empleando 
LINQ*/
using System;
using System.Linq;
using System.Collections.Generic;

public class EjercicioLinq
{
    public static void Main()
    {
        List<int> numerosEnteros = new List<int>();

        Console.WriteLine("¿Cuántos números enteros quieres añadir a la lista: ");

        int cantidad = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine("Introduce el número {0}: ", i + 1);
            int numero = Convert.ToInt32(Console.ReadLine());
            numerosEnteros.Add(numero);
        }

        var listaFiltrada =
            from num in numerosEnteros
            where num >= 0
            orderby num
            select num;
        
        Console.WriteLine("Resultado de filtrar y ordenar la lista de números:");

        foreach (int n in listaFiltrada)
        {
            Console.Write("{0} - ", n);
        }
    }
}