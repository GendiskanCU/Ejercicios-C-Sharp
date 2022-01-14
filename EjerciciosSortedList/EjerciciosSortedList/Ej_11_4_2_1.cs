/*(11.4.2.1) Crea un programa que, cuando el usuario introduzca el nombre de un 
número del 1 al 10 en español, diga su traducción en inglés */

using System;
using System.Collections;

public class EjercicioSortedList
{
    public static void Main()
    {
        SortedList diccioNum = new SortedList();
        diccioNum.Add("uno", "one");
        diccioNum.Add("dos", "two");
        diccioNum.Add("tres", "three");
        diccioNum.Add("cuatro", "four");
        diccioNum.Add("cinco", "five");
        diccioNum.Add("seis", "six");
        diccioNum.Add("siete", "seven");
        diccioNum.Add("ocho", "eight");
        diccioNum.Add("nueve", "nine");
        diccioNum.Add("diez", "ten");

        string numTraducir;

        Console.WriteLine("Escribe el número que quieres traducir:");
        numTraducir = Console.ReadLine();

        while(numTraducir != "")
        {            
            if(diccioNum.ContainsValue(numTraducir))
            {
                Console.WriteLine("La traducción de {0} es: {1}", numTraducir,
                    diccioNum.GetKey(diccioNum.IndexOfValue(numTraducir)));
            }
            else
            {
                Console.WriteLine("Número no encontrado");
            }

            Console.WriteLine("Escribe el número que quieres traducir:");
            numTraducir = Console.ReadLine();
        }
        
        diccioNum.Clear();
    }
}