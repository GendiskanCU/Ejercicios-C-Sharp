using System;
using System.Collections.Generic;

public class EjemploList
{
    public static void Main()
    {
        List<string> miLista = new List<string>();

        //Añadimos en orden
        miLista.Add("Hola,");
        miLista.Add("soy");
        miLista.Add("yo");

        //Mostramos lo que contiene
        Console.WriteLine("Contenido actual:");
        foreach(string mi in miLista)
            Console.WriteLine(mi);

        //Accedemos a una posición
        Console.WriteLine("La segunda palabra es: {0}", miLista[1]);

        //Insertamos en la segunda posición
        miLista.Insert(1, "Cómo estás?");

        //Mostramos de otra forma lo que contiene
        for(int i = 0; i < miLista.Count; i++)
        {
            Console.WriteLine(miLista[i]);
        }

        //Buscamos un elemento
        Console.WriteLine("La palabra \"yo\" está en la posición: {0}",
            miLista.IndexOf("yo"));

        //Ordenamos
        miLista.Sort();

        //Mostramos lo que contiene
        Console.WriteLine("Contenido ordenado:");
        foreach(string frase in miLista)
            Console.WriteLine(frase);

        //Buscamos con búsqueda binaria
        Console.WriteLine("Ahora la palabra \"yo\" está en la posición: {0}" +
            miLista.BinarySearch("yo"));

        //Invertimos la lista
        miLista.Reverse();

        //Borramos el segundo dato y la palabra "yo"
        miLista.RemoveAt(1);
        miLista.Remove("yo");

        //Mostramos nuevamente lo que contiene
        Console.WriteLine("Contenido después de darle la vuelta y eliminar dos");
        foreach (string frase in miLista)
            Console.WriteLine(frase);

        //Ordenamos y vemos dónde iría un nuevo dato
        miLista.Sort();
        Console.WriteLine("La frase \"Hasta luego\" ");
        int posicion = miLista.BinarySearch("Hasta luego");
        if (posicion >= 0)
            Console.WriteLine("Está en la posición {0}", posicion);
        else
            Console.WriteLine("No está. Iría en la posición {0}",
                ~posicion);
    }
}