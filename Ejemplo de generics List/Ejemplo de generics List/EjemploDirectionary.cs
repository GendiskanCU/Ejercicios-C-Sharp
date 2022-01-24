using System;
using System.Collections.Generic;

public class EjemploDictionary
{
    public static void Main()
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();

        dic.Add("Uno", 1);
        dic.Add("Dos", 2);
        dic.Add("Tres", 3);
        dic.Add("Cuatro", 4);
        dic.Add("Cinco", 5);

        //Mostramos algún dato
        Console.WriteLine("Números en el diccionario: {0}", dic.Count);

        if (dic.ContainsKey("Tres"))
            Console.WriteLine("El número Tres se escribe: {0}", dic["Tres"]);
    }
}
