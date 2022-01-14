using System;
using System.Collections;

public class EjemploTablaHash
{
    public static void Main()
    {
        //Creamos e insertamos datos
        Hashtable miDiccio = new Hashtable();
        miDiccio.Add("byte", "8 bits");
        miDiccio.Add("pc", "personal computer");
        miDiccio.Add("kilobyte", "1024 bytes");

        //Mostramos algún dato
        Console.WriteLine("Cantidad de palabras en el diccionario: {0}",
            miDiccio.Count);
        try
        {
            Console.WriteLine("El significado de PC es: {0}",
                miDiccio["pc"]);
        }
        catch(Exception)
        {
            Console.WriteLine("No existe esa palabra");
        }

        Console.ReadLine();
    }
}