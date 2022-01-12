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
        StreamReader fichero;

        try
        {            
            fichero = File.OpenText("registroDeUsuario.txt");
        }
        catch(Exception error)
        {
            Console.WriteLine("Error al intentar abrir el fichero: {0}", error.Message);
            return;
        }

        ArrayList miLista = new ArrayList();

        string lineaLeida = fichero.ReadLine();

        while (lineaLeida != null)
        {
            miLista.Add(lineaLeida);
            lineaLeida = fichero.ReadLine();
        }

        int lineaLeer = 0;
        
        while (lineaLeer >= 0 && lineaLeer < miLista.Count)
        {
            Console.WriteLine("¿Qué línea quieres mostrar? (entre 0 y {0}, cualquier otro valor para salir)", miLista.Count - 1);
            lineaLeer = Convert.ToInt32(Console.ReadLine());
            if (lineaLeer >= 0 && lineaLeer < miLista.Count)
                Console.WriteLine("En la línea {0} he leído: {1}", lineaLeer, miLista[lineaLeer]);
        }
        

        fichero.Close();
    }
}