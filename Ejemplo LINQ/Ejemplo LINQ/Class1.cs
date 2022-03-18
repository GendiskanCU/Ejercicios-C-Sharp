//Ejemplo ordenar una lista de cadenas de texto
using System;
using System.Linq;
using System.Collections.Generic;

public class EjemploLinq2
{
    public static void Main()
    {
        List<string> nombres = new List<string>
        { "pan", "carne", "queso", "fruta", "verdura"};

        var resultadoOrdenado =
            from nombre in nombres
            orderby nombre
            select nombre;

        foreach (string n in resultadoOrdenado)
            Console.Write("{0}, ", n);
        Console.WriteLine();
    }
}