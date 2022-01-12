/*(11.4.1.1) Crea un programa que lea el contenido de un fichero de texto, lo 
almacene línea por línea en un ArrayList, y luego pregunte de forma repetitiva al 
usuario qué línea desea ver. Terminará cuando el usuario introduzca "-1*/
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

        if(File.Exists("registroDeUsuario.txt"))
            fichero = new StreamReader("registroDeUsuario.txt");
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

        Console.WriteLine("\nIntroduzca el número de línea que desea ver");
        Console.WriteLine("(Entre 1 y {0}, introduza -1 para salir)", frases.Count);
        int numeroFrase = Convert.ToInt32(Console.ReadLine());

        while(numeroFrase != -1)
        {
            if (numeroFrase < 1 || numeroFrase > frases.Count)
                Console.WriteLine("Error. Ese número de frase no existe");
            else
                Console.WriteLine(frases[numeroFrase - 1]);

            Console.WriteLine("\nIntroduzca el número de línea que desea ver");
            Console.WriteLine("(Entre 1 y {0}, introduza -1 para salir)", frases.Count);
            numeroFrase = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("\nFin del programa. Presione Intro para salir");
        Console.ReadLine();
    }
}