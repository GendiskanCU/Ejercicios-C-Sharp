using System;
using System.Collections;

public class Ejemplo2HashTable
{
    public static void Main()
    {
        //Creamos e insertamos datos
        Hashtable miDiccio = new Hashtable(500);

        miDiccio.Add("byte", "8 bits");
        miDiccio.Add("kilobyte", "1024 bytes");
        miDiccio.Add("pc", "personal computer");

        //Mostramos algún dato
        Console.WriteLine("Número de palabras en el diccionario: {0}",
            miDiccio.Count);
        if (miDiccio.ContainsKey("pc"))
        {
            Console.WriteLine("Significado de la palabra PC: {0}",
                miDiccio["pc"]);
        }
        else
            Console.WriteLine("No existe la palabra PC");

        Console.ReadLine();
    }    
}