using System;
using System.Collections;

public class EjemploSortedList
{
    public static void Main()
    {
        //Creamos e insertamos datos
        SortedList miDiccionario = new SortedList();
        miDiccionario.Add("Hola", "Hello");
        miDiccionario.Add("Adiós", "Good bye");
        miDiccionario.Add("Hasta luego", "See yo later");

        //Mostramos los datos
        Console.WriteLine("Cantidad de palabras en el diccionario: {0}", miDiccionario.Count);
        Console.WriteLine("Lista de palabras y su significado:");

        for(int i = 0; i<miDiccionario.Count; i++)
        {
            Console.WriteLine("{0}: {1}", miDiccionario.GetKey(i), miDiccionario.GetByIndex(i));
        }

        Console.WriteLine("Traducción de \"Hola\": {0}",
            miDiccionario.GetByIndex(miDiccionario.IndexOfKey("Hola")));

        Console.WriteLine("Que también se puede obtener con corchetes: {0}",
            miDiccionario["Hola"]);       
    }
}