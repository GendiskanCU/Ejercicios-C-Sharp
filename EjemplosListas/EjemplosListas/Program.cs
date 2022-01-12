using System;
using System.Collections;

public class EjemploArrayList
{
    public static void Main()
    {
        ArrayList miLista = new ArrayList();
        //Añadimos en orden
        miLista.Add("Hola, ");
        miLista.Add("soy ");
        miLista.Add("yo.");

        //Mostramos lo que contiene
        Console.WriteLine("Contenido actual:");
        foreach(string frase in miLista)
            Console.WriteLine(frase);

        //Accedemos a una posición
        Console.WriteLine("La segunda palabra es {0}", miLista[1]);

        //Insertamos en la segunda posición
        miLista.Insert(1, "¿Cómo estás?");

        //Mostramos de otra forma lo que contiene
        Console.WriteLine("Contenido tras insertar:");
        for(int i= 0; i < miLista.Count; i++)
            Console.WriteLine(miLista[i]);

        //Buscamos un elemento
        Console.WriteLine("La parabra 'yo' está en la posición {0}", miLista.IndexOf("yo"));

        //Ordenamos
        miLista.Sort();

        //Mostramos lo que contiene
        Console.WriteLine("Contenido tras ordenar:");
        foreach (string frase in miLista)
            Console.WriteLine(frase);

        //Buscamos con búsqueda binaria
        Console.WriteLine("Ahora 'yo' está en la posición {0}", miLista.BinarySearch("yo"));

        //Invertimos la lista
        miLista.Reverse();

        //Borramos el segundo dato y la palabra yo
        miLista.Remove(1);
        miLista.Remove("yo");

        //Mostramos nuevamente lo que contiene
        Console.WriteLine("Contenido dar la vuelta y tras eliminar dos:");
        foreach (string frase in miLista)
            Console.WriteLine(frase);

        //Ordenamos y vemos dónde iría un nuevo dato
        miLista.Sort();
        string fraseBuscar = "Hasta luego";
        Console.WriteLine("La frase 'Hasta luego' ");
        int posicion = miLista.BinarySearch(fraseBuscar);
        if (posicion >= 0)
            Console.WriteLine("está en la posición {0}", posicion);
        else
            Console.WriteLine("no está. El dato inmediatamente mayor es el {0}: {1}", ~posicion, miLista[~posicion]);
    }
}