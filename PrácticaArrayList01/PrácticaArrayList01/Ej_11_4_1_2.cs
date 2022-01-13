/*(11.4.1.2) Crea un programa que lea el contenido de un fichero de texto, lo 
almacene línea por línea en un ArrayList, y luego pregunte de forma repetitiva al 
usuario qué texto desea buscar y muestre las líneas que contienen ese texto. 
Terminará cuando el usuario introduzca una cadena vacía.*/
using System;
using System.Collections;
using System.IO;

public class EjercicioArrayList
{
    public static void Main()
    {
        ArrayList frases = new ArrayList();

        StreamReader fichero;
        string frase;

        if(File.Exists("Quijote.txt"))
            fichero = new StreamReader("Quijote.txt");
        else
        {
            Console.WriteLine("Error. El fichero no existe");
            return;
        }

        try
        {
            frase = fichero.ReadLine();
            while(frase != null)
            {
                frases.Add(frase);
                frase = fichero.ReadLine();
            }

            fichero.Close();         
            
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
            return;
        }

        Console.WriteLine("Número total de frases leídas: {0}", frases.Count);
        //foreach(string lineaLeida in frases)
          //  Console.WriteLine(lineaLeida);
        
        Console.WriteLine("\nIntroduzca la frase a buscar");
        Console.WriteLine("(deje en blanco para salir)", frases.Count);
        string fraseBuscada = Console.ReadLine();
        string linea;
        bool encontrada;

        while(fraseBuscada != "")
        {
            encontrada = false;
            for(int i = 0; i < frases.Count; i++)
            {
               linea = (string)frases[i];
               if(linea.Contains(fraseBuscada))
                {
                    encontrada = true;
                    Console.WriteLine("Encontrada en la línea {0}\n{1}: ", i, frases[i]);
                }
            }
            if (!encontrada)
                Console.WriteLine("La frase no se encontró en ninguna línea");
            

            Console.WriteLine("\nIntroduzca una nueva frase a buscar");
            Console.WriteLine("(deje en blanco para salir)", frases.Count);
            fraseBuscada = Console.ReadLine();
        }

        Console.WriteLine("\nFin del programa. Presione Intro para salir");
        Console.ReadLine();
    }
}