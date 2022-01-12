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
        miLista.Add("yo");

        //Mostramos lo que contiene
        Console.WriteLine("Contenido actual: ");
        foreach(string frase in miLista)
        {
            Console.WriteLine(frase);
        }

        //Accedemos a una posición
        Console.WriteLine("La segunda palabra es: {0}", miLista[1]);

        //Insertamos en la segunda posición
        miLista.Insert(1, "¿cómo estás?, ");

        //Mostramos de otra forma lo que contiene
        Console.WriteLine("Contenido tras insertar: ");
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
        Console.WriteLine("Contenido tras ordenar:");
        foreach (string frase in miLista)
            Console.WriteLine(frase);

        //Buscamos utilizando la búsqueda binaria
        Console.WriteLine("Ahora \"yo\" está en la posición: {0}",
            miLista.BinarySearch("yo"));

        //Invertimos la lista
        miLista.Reverse();

        //Borramos el segunda dato y la palabra "yo"
        miLista.RemoveAt(1);
        miLista.Remove("yo");

        //Mostramos nuevamente lo que contiene
        Console.WriteLine("Contenido tras dar la vuelta y eliminar dos elementos:");
        foreach (string frase in miLista)
            Console.WriteLine(frase);

        //Ordenamos y vemos dónde iría un nuevo dato
        miLista.Sort();
        int posicion = miLista.BinarySearch("Hasta luego");

        if (posicion >= 0)
        {
            Console.WriteLine("La frase \"Hasta luego\" está en la posición: {0}", posicion);
        }
        else
        {
            Console.WriteLine("La frase \"Hasta luego\" no está");
            Console.WriteLine("En caso de haber existido, hubiera quedado en la posicion: {0}, justo antes de {1}",
                ~posicion - 1, miLista[~posicion]);
        }

        Console.ReadLine();
    }
}