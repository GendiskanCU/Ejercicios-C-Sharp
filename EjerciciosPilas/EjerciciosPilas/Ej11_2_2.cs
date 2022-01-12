/*11.2.2) Crea un programa que pida al usuario el nombre de un fichero de texto y 
muestre en orden inverso las líneas que lo forma, empleando una pila.*/
using System;
using System.Collections;

public class EjercicioPilas
{
    public static void Main()
    {
        Console.Write("Introduce el nombre del fichero: ");
        string nombreFich = Console.ReadLine();
        Stack pila = new Stack();

        foreach(char c in nombreFich)
            pila.Push(c);

        int numeroCaracteres = pila.Count;

        Console.WriteLine("El nombre del fichero escrito al revés es: ");
        for(int i = 0; i < numeroCaracteres; i++)
            Console.Write(pila.Pop());
        Console.WriteLine();
        Console.ReadLine();
    }
}