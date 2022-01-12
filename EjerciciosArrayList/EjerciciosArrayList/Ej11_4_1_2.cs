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
            Console.WriteLine(lineaLeida);
            lineaLeida = fichero.ReadLine();
        }

        string textoBuscar;
        int posicion;
        
        do
        {
            Console.WriteLine("Introduce el texto a buscar dentro del fichero:");
            textoBuscar = Console.ReadLine();
            if (textoBuscar != "")
            {
                posicion = miLista.IndexOf(textoBuscar);
                Console.WriteLine(textoBuscar);
                Console.WriteLine(posicion);
                while (posicion >= 0)
                {
                    Console.WriteLine("{0} se encuentra en la frase: {1}", textoBuscar, miLista[posicion]);
                    posicion = miLista.IndexOf(textoBuscar);
                }
            }

        } while (textoBuscar != "");
        

        fichero.Close();
    }
}