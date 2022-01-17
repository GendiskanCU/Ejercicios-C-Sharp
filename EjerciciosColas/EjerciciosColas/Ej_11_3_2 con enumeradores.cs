/*(11.3.2) Crea un programa que pida frases al usuario, hasta que introduzca una 
frase vacía. En ese momento, mostrará todas las frases que se habían introducido.*/
using System;
using System.Collections;

public class EjerciciosColas
{
    public static void Main()
    {
        Queue colaFrases = new Queue();

        string frase;

        do
        {
            Console.Write("Introduce una frase (deja en blanco para finalizar): ");
            frase = Console.ReadLine();
            if (frase != "")
                colaFrases.Enqueue(frase);

        } while (frase != "");

        Console.WriteLine("\nLas frases que has ido itroduciendo son:\n");
        IEnumerator enumerator = colaFrases.GetEnumerator();
        while(enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }
}