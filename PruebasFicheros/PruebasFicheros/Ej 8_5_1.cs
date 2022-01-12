/*(8.5.1) Crea un programa que pida al usuario pares de números enteros y escriba 
su suma (con el formato "20 + 3 = 23") en pantalla y en un fichero llamado 
"sumas.txt", que se encontrará en un subdirectorio llamado "resultados". Cada vez 
que se ejecute el programa, deberá añadir los nuevos resultados a continuación 
de los resultados de las ejecuciones anteriores*/

using System;
using System.IO;

public class SumasEnFichero
{
    public static void Main()
    {
        StreamWriter ficheroSumas = File.AppendText(@"resultados\sumas.txt");

        string num1, num2;
        bool salir=false;

        while (!salir)
        {
            Console.WriteLine("Introduzca un par de números enteros: (escriba salir cuando quiera finalizar) ");
            num1 = Console.ReadLine();
            num2 = Console.ReadLine();

            if (num1 == "salir" || num2 == "salir")
                    salir = true;
            else
            {
                try
                {
                    Console.WriteLine($"{num1} + {num2} = {Convert.ToInt32(num1) + Convert.ToInt32(num2)}");
                    ficheroSumas.WriteLine($"{num1} + {num2} = {Convert.ToInt32(num1) + Convert.ToInt32(num2)}");
                }
                catch (Exception error) { Console.WriteLine(error.Message); }
            }
        }

        ficheroSumas.Close();
    }
}