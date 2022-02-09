//Ejemplo de llamadas al Sistema

using System;
using System.Diagnostics;

public class EjemploLlamadaOtraApp
{
    public static void Main()
    {
        Console.WriteLine("Lanzando el bloc de notas...");
        Process process = Process.Start("notepad.exe");
        Console.WriteLine("Esperando que se cierre el bloc de notas...");
        process.WaitForExit();
        Console.WriteLine("Bloc de notas cerrado. Continúa la ejecución del programa");
    }
}